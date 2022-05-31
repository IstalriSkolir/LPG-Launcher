
namespace LPG_Game_Configurator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.RemoveGameButton = new System.Windows.Forms.Button();
            this.AddGameButton = new System.Windows.Forms.Button();
            this.GamesBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(15, 15);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFileButton.TabIndex = 0;
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(95, 15);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveFileButton.TabIndex = 1;
            this.SaveFileButton.Text = "Save File";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // RemoveGameButton
            // 
            this.RemoveGameButton.Location = new System.Drawing.Point(15, 45);
            this.RemoveGameButton.Name = "RemoveGameButton";
            this.RemoveGameButton.Size = new System.Drawing.Size(75, 50);
            this.RemoveGameButton.TabIndex = 2;
            this.RemoveGameButton.Text = "Remove Game";
            this.RemoveGameButton.UseVisualStyleBackColor = true;
            this.RemoveGameButton.Click += new System.EventHandler(this.RemoveGameButton_Click);
            // 
            // AddGameButton
            // 
            this.AddGameButton.Location = new System.Drawing.Point(95, 45);
            this.AddGameButton.Name = "AddGameButton";
            this.AddGameButton.Size = new System.Drawing.Size(75, 50);
            this.AddGameButton.TabIndex = 3;
            this.AddGameButton.Text = "Add Game";
            this.AddGameButton.UseVisualStyleBackColor = true;
            this.AddGameButton.Click += new System.EventHandler(this.AddGameButton_Click);
            // 
            // GamesBox
            // 
            this.GamesBox.FormattingEnabled = true;
            this.GamesBox.ItemHeight = 15;
            this.GamesBox.Location = new System.Drawing.Point(15, 100);
            this.GamesBox.Name = "GamesBox";
            this.GamesBox.Size = new System.Drawing.Size(155, 349);
            this.GamesBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.GamesBox);
            this.Controls.Add(this.AddGameButton);
            this.Controls.Add(this.RemoveGameButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.LoadFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button RemoveGameButton;
        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.ListBox GamesBox;
    }
}

