namespace File_Mover
{
    partial class MainForm
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
            this.fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.fileSelectTextBox = new System.Windows.Forms.TextBox();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.fileSelectLabel = new System.Windows.Forms.Label();
            this.dirSelectLabel = new System.Windows.Forms.Label();
            this.dirSelectButton = new System.Windows.Forms.Button();
            this.dirSelectTextBox = new System.Windows.Forms.TextBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.dirSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // fileSelector
            // 
            this.fileSelector.Multiselect = true;
            this.fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.fileSelector_FileOk);
            // 
            // fileSelectTextBox
            // 
            this.fileSelectTextBox.Location = new System.Drawing.Point(87, 28);
            this.fileSelectTextBox.Name = "fileSelectTextBox";
            this.fileSelectTextBox.ReadOnly = true;
            this.fileSelectTextBox.Size = new System.Drawing.Size(362, 20);
            this.fileSelectTextBox.TabIndex = 0;
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(455, 25);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(31, 23);
            this.fileSelectButton.TabIndex = 1;
            this.fileSelectButton.Text = "...";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // fileSelectLabel
            // 
            this.fileSelectLabel.AutoSize = true;
            this.fileSelectLabel.Location = new System.Drawing.Point(8, 31);
            this.fileSelectLabel.Name = "fileSelectLabel";
            this.fileSelectLabel.Size = new System.Drawing.Size(73, 13);
            this.fileSelectLabel.TabIndex = 2;
            this.fileSelectLabel.Text = "Files to Move:";
            // 
            // dirSelectLabel
            // 
            this.dirSelectLabel.AutoSize = true;
            this.dirSelectLabel.Location = new System.Drawing.Point(8, 70);
            this.dirSelectLabel.Name = "dirSelectLabel";
            this.dirSelectLabel.Size = new System.Drawing.Size(64, 26);
            this.dirSelectLabel.TabIndex = 5;
            this.dirSelectLabel.Text = "Directory to \r\nmove to:";
            // 
            // dirSelectButton
            // 
            this.dirSelectButton.Location = new System.Drawing.Point(455, 70);
            this.dirSelectButton.Name = "dirSelectButton";
            this.dirSelectButton.Size = new System.Drawing.Size(31, 23);
            this.dirSelectButton.TabIndex = 4;
            this.dirSelectButton.Text = "...";
            this.dirSelectButton.UseVisualStyleBackColor = true;
            this.dirSelectButton.Click += new System.EventHandler(this.dirSelectButton_Click);
            // 
            // dirSelectTextBox
            // 
            this.dirSelectTextBox.Location = new System.Drawing.Point(87, 73);
            this.dirSelectTextBox.Name = "dirSelectTextBox";
            this.dirSelectTextBox.ReadOnly = true;
            this.dirSelectTextBox.Size = new System.Drawing.Size(362, 20);
            this.dirSelectTextBox.TabIndex = 3;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(411, 119);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 6;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 273);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.dirSelectLabel);
            this.Controls.Add(this.dirSelectButton);
            this.Controls.Add(this.dirSelectTextBox);
            this.Controls.Add(this.fileSelectLabel);
            this.Controls.Add(this.fileSelectButton);
            this.Controls.Add(this.fileSelectTextBox);
            this.Name = "MainForm";
            this.Text = "File-Mover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileSelector;
        private System.Windows.Forms.TextBox fileSelectTextBox;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.Label fileSelectLabel;
        private System.Windows.Forms.Label dirSelectLabel;
        private System.Windows.Forms.Button dirSelectButton;
        private System.Windows.Forms.TextBox dirSelectTextBox;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.FolderBrowserDialog dirSelector;
    }
}

