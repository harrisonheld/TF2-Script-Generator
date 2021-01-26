using System;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TF2SpamScriptGen
{
    static class Program
    {
        const int defaultWaitTime = 200; //in case there are non-numeric characters in waitTime

        static string scriptsFolder;
        static string keyToBind;
        static string waitTime;

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

            try
            {
                waitTimeInput.Value = int.Parse(waitTime);
            }
            catch
            {
                waitTimeInput.Value = defaultWaitTime;
                waitTime = defaultWaitTime.ToString();
            }

            scriptsFolderTextBox.Text = scriptsFolder;
            keyToBindTextBox.Text = keyToBind;

            scriptsFolderButton.Click += new EventHandler(OnScriptsFolderButtonClick);
            generateButton.Click += new EventHandler(OnGenerateButtonClick);
            saveSettingsButton.Click += new EventHandler(OnSaveSettingsButtonClick);
            loadButton.Click += new EventHandler(OnLoadButtonClick);
            linesInputTextBox.KeyDown += new KeyEventHandler(OnLinesInputTextBoxKeyDown);

            Application.Run(form1);
        }
        static void OnLinesInputTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers.HasFlag(Keys.Control) && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                linesInputTextBox.SelectAll();
            }
        }
        static void OnScriptsFolderButtonClick(object sender, EventArgs e)
        {
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

            int lineCount = scriptLines.Length - 2;
            lineCount = (int)((float)lineCount * (5f / 6f)); 
            //^^this literally CANNOT be a good way to do this but it works

            string[] lines = new string[lineCount];

            for(int i = 0; i < lineCount; i++)
            {
                lines[i] = scriptLines[i + 2].Split('"')[1].Remove(0, 4);
            }
            return lines;
        }
    }
}