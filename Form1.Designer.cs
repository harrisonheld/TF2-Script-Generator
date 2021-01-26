namespace TF2SpamScriptGen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linesInputTextBox = new System.Windows.Forms.TextBox();
            this.scriptsFolderButton = new System.Windows.Forms.Button();
            this.scriptsFolderTextBox = new System.Windows.Forms.TextBox();
            this.waitTimeInput = new System.Windows.Forms.NumericUpDown();
            this.keyToBindTextbox = new System.Windows.Forms.TextBox();
            this.waitTimeLabel = new System.Windows.Forms.Label();
            this.keyToBindLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // linesInputTextBox
            // 
            this.linesInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linesInputTextBox.Location = new System.Drawing.Point(12, 69);
            this.linesInputTextBox.Multiline = true;
            this.linesInputTextBox.Name = "linesInputTextBox";
            this.linesInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.linesInputTextBox.Size = new System.Drawing.Size(760, 486);
            this.linesInputTextBox.TabIndex = 0;
            // 
            // scriptsFolderButton
            // 
            this.scriptsFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptsFolderButton.Location = new System.Drawing.Point(631, 9);
            this.scriptsFolderButton.Name = "scriptsFolderButton";
            this.scriptsFolderButton.Size = new System.Drawing.Size(141, 20);
            this.scriptsFolderButton.TabIndex = 1;
            this.scriptsFolderButton.Text = "Choose Scripts Folder";
            this.scriptsFolderButton.UseVisualStyleBackColor = true;
            this.scriptsFolderButton.Click += new System.EventHandler(this.scriptsFolderButton_Click);
            // 
            // scriptsFolderTextBox
            // 
            this.scriptsFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptsFolderTextBox.Location = new System.Drawing.Point(12, 9);
            this.scriptsFolderTextBox.Name = "scriptsFolderTextBox";
            this.scriptsFolderTextBox.ReadOnly = true;
            this.scriptsFolderTextBox.Size = new System.Drawing.Size(613, 20);
            this.scriptsFolderTextBox.TabIndex = 3;
            // 
            // waitTimeInput
            // 
            this.waitTimeInput.Location = new System.Drawing.Point(131, 38);
            this.waitTimeInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.waitTimeInput.Name = "waitTimeInput";
            this.waitTimeInput.Size = new System.Drawing.Size(75, 20);
            this.waitTimeInput.TabIndex = 4;
            // 
            // keyToBindTextbox
            // 
            this.keyToBindTextbox.Location = new System.Drawing.Point(286, 37);
            this.keyToBindTextbox.Name = "keyToBindTextbox";
            this.keyToBindTextbox.Size = new System.Drawing.Size(75, 20);
            this.keyToBindTextbox.TabIndex = 5;
            // 
            // waitTimeLabel
            // 
            this.waitTimeLabel.AutoSize = true;
            this.waitTimeLabel.Location = new System.Drawing.Point(12, 41);
            this.waitTimeLabel.Name = "waitTimeLabel";
            this.waitTimeLabel.Size = new System.Drawing.Size(113, 13);
            this.waitTimeLabel.TabIndex = 6;
            this.waitTimeLabel.Text = "Wait Time (In Frames):";
            // 
            // keyToBindLabel
            // 
            this.keyToBindLabel.AutoSize = true;
            this.keyToBindLabel.Location = new System.Drawing.Point(212, 41);
            this.keyToBindLabel.Name = "keyToBindLabel";
            this.keyToBindLabel.Size = new System.Drawing.Size(68, 13);
            this.keyToBindLabel.TabIndex = 7;
            this.keyToBindLabel.Text = "Key To Bind:";
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(672, 561);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 28);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Save Script";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.Location = new System.Drawing.Point(631, 35);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(141, 23);
            this.saveSettingsButton.TabIndex = 11;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadButton.Location = new System.Drawing.Point(12, 561);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(100, 28);
            this.loadButton.TabIndex = 12;
            this.loadButton.Text = "Load Script";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.keyToBindLabel);
            this.Controls.Add(this.waitTimeLabel);
            this.Controls.Add(this.keyToBindTextbox);
            this.Controls.Add(this.waitTimeInput);
            this.Controls.Add(this.scriptsFolderTextBox);
            this.Controls.Add(this.scriptsFolderButton);
            this.Controls.Add(this.linesInputTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TF2 Spam Script Generator";
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox linesInputTextBox;
        private System.Windows.Forms.Button scriptsFolderButton;
        private System.Windows.Forms.TextBox scriptsFolderTextBox;
        private System.Windows.Forms.NumericUpDown waitTimeInput;
        private System.Windows.Forms.TextBox keyToBindTextbox;
        private System.Windows.Forms.Label waitTimeLabel;
        private System.Windows.Forms.Label keyToBindLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button loadButton;
    }
}