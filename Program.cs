using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TF2ScriptGen
{
    static class Program
    {
        // use this wait time if the one the user enters isn't valid
        // (for instance, if it contains a letter instead of a number)
        const int DEFAULT_WAIT_TIME = 200;

        // settings for generated script
        static string scriptsFolder;
        static string keyToBind;
        static string waitTime;

        // form elements
        static TextBox linesInputTextBox;
        static TextBox scriptsFolderTextBox;
        static Button scriptsFolderButton;
        static NumericUpDown waitTimeInput;
        static TextBox keyToBindTextBox;
        static Button generateButton;
        static Button saveSettingsButton;
        static Button loadButton;

        [STAThread]
        static void Main(string[] args)
        {
            // set settings
            scriptsFolder = ConfigurationManager.AppSettings.Get("scriptsFolder");
            keyToBind = ConfigurationManager.AppSettings.Get("keyToBind");
            waitTime = ConfigurationManager.AppSettings.Get("waitTime");

            Form1 form1 = new Form1();

            linesInputTextBox = (TextBox)form1.Controls.Find("linesInputTextBox", false)[0];
            scriptsFolderTextBox = (TextBox)form1.Controls.Find("scriptsFolderTextBox", false)[0];
            scriptsFolderButton = (Button)form1.Controls.Find("scriptsFolderButton", false)[0];
            waitTimeInput = (NumericUpDown)form1.Controls.Find("waitTimeInput", false)[0];
            keyToBindTextBox = (TextBox)form1.Controls.Find("keyToBindTextBox", false)[0];
            generateButton = (Button)form1.Controls.Find("generateButton", false)[0];
            saveSettingsButton = (Button)form1.Controls.Find("saveSettingsButton", false)[0];
            loadButton = (Button)form1.Controls.Find("loadButton", false)[0];

            // set wait time box value
            try
            {
                waitTimeInput.Value = int.Parse(waitTime);
            }
            catch
            {
                waitTimeInput.Value = DEFAULT_WAIT_TIME;
                waitTime = DEFAULT_WAIT_TIME.ToString();
            }

            // set other input boxes text
            scriptsFolderTextBox.Text = scriptsFolder;
            keyToBindTextBox.Text = keyToBind;

            // add events
            scriptsFolderButton.Click += new EventHandler(OnScriptsFolderButtonClick);
            generateButton.Click += new EventHandler(OnGenerateButtonClick);
            saveSettingsButton.Click += new EventHandler(OnSaveSettingsButtonClick);
            loadButton.Click += new EventHandler(OnLoadButtonClick);
            linesInputTextBox.KeyDown += new KeyEventHandler(OnLinesInputTextBoxKeyDown);

            // run form
            Application.Run(form1);
        }

        static void OnLinesInputTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            // allow the use of ctrl-A to select all, which usually possible by default
            if(e.Modifiers.HasFlag(Keys.Control) && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                linesInputTextBox.SelectAll();
            }
        }

        static void OnScriptsFolderButtonClick(object sender, EventArgs e)
        {
            // change script folder

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = scriptsFolder;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                dialog.InitialDirectory = dialog.FileName;
                scriptsFolderTextBox.Text = dialog.FileName;
            }
        }

        static void OnSaveSettingsButtonClick(object sender, EventArgs e)
        {
            UpdateSettingsVars();
            ConfigurationManager.AppSettings.Set("scriptsFolder", scriptsFolder);
            ConfigurationManager.AppSettings.Set("keyToBind", keyToBind);
            ConfigurationManager.AppSettings.Set("waitTime", waitTime);
        }

        static void OnGenerateButtonClick(object sender, EventArgs e)
        {
            CommonSaveFileDialog dialog = new CommonSaveFileDialog();
            dialog.InitialDirectory = scriptsFolder;
            dialog.DefaultExtension = "cfg";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                UpdateSettingsVars();
                string[] lines = linesInputTextBox.Lines;
                string[] scriptLines = GenerateScriptLines(lines);

                File.WriteAllLines(dialog.FileName, scriptLines);
            }
        }

        static void OnLoadButtonClick(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = scriptsFolder;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                linesInputTextBox.Lines = GetInputFromScript(dialog.FileName);
            }
        }

        static void UpdateSettingsVars()
        {
            scriptsFolder = scriptsFolderTextBox.Text;
            keyToBind = keyToBindTextBox.Text;
            waitTime = waitTimeInput.Value.ToString();
        }

        static string[] GenerateScriptLines(string[] lines)
        {
            int setLineCount;
            if (lines.Length % 5 == 0)
                setLineCount = lines.Length / 5;
            else
                setLineCount = (int)Math.Ceiling((double)lines.Length / 5.0);

            string[] scriptLines = new string[lines.Length + setLineCount +1];

            scriptLines[0] = "bind " + keyToBind + " \"spamSet0\"";

            for (int i = 0; i < lines.Length; i++)
            {
                scriptLines[i + 1] = "alias spam" + (i) + " \"say " + lines[i].Replace("\"", "'") + "\"";
            }

            for (int i = 0; i < setLineCount; i++)
            {
                string newLine = "alias spamSet" + i + " \"";
                for (int o = 0; o < 5; o++)
                {
                    newLine += "spam" + ((i * 5) + o) + "; wait " + waitTime + "; ";

                    if ((i * 5) + o >= lines.Length - 1)
                        break;
                }
                if (i != setLineCount - 1)
                    newLine += "spamSet" + (i + 1) + ";";
                newLine += "\"";

                scriptLines[lines.Length + 1 + i] = newLine;
            }
            return scriptLines;
        }

        static string[] GetInputFromScript(string scriptFilePath)
        {
            string[] scriptLines = File.ReadAllLines(scriptFilePath);

            // modify the script line count to get the line count of the plain text.
            int lineCount = scriptLines.Length - 2;
            lineCount = (int)((float)lineCount * (5f / 6f)); 

            string[] lines = new string[lineCount];

            for(int i = 0; i < lineCount; i++)
            {
                // turn from a script line back to just the plain text
                lines[i] = scriptLines[i + 2].Split('"')[1].Remove(0, 4);
            }
            return lines;
        }
    }
}
