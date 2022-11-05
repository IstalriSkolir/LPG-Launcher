
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
            this.label1 = new System.Windows.Forms.Label();
            this.GameNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GameDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.GameControlsComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GamePathButton = new System.Windows.Forms.Button();
            this.GamePathTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GameImageTextBox = new System.Windows.Forms.TextBox();
            this.GameImageButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.GameURLTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GameDescTextBox = new System.Windows.Forms.RichTextBox();
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
            this.GamesBox.SelectedIndexChanged += new System.EventHandler(this.GamesBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(200, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // GameNameTextBox
            // 
            this.GameNameTextBox.Enabled = false;
            this.GameNameTextBox.Location = new System.Drawing.Point(300, 75);
            this.GameNameTextBox.Name = "GameNameTextBox";
            this.GameNameTextBox.Size = new System.Drawing.Size(200, 23);
            this.GameNameTextBox.TabIndex = 6;
            this.GameNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameNameTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(200, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Game: ";
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameLabel.Location = new System.Drawing.Point(270, 15);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(0, 30);
            this.GameLabel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(200, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Released:";
            // 
            // GameDatePicker
            // 
            this.GameDatePicker.CustomFormat = "\"dd/MM/yyyy\"";
            this.GameDatePicker.Enabled = false;
            this.GameDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GameDatePicker.Location = new System.Drawing.Point(300, 125);
            this.GameDatePicker.Name = "GameDatePicker";
            this.GameDatePicker.Size = new System.Drawing.Size(200, 23);
            this.GameDatePicker.TabIndex = 10;
            this.GameDatePicker.ValueChanged += new System.EventHandler(this.GameDatePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(200, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Controls:";
            // 
            // GameControlsComboBox
            // 
            this.GameControlsComboBox.Enabled = false;
            this.GameControlsComboBox.FormattingEnabled = true;
            this.GameControlsComboBox.Items.AddRange(new object[] {
            "Keyboard/Mouse",
            "Xbox Controller"});
            this.GameControlsComboBox.Location = new System.Drawing.Point(300, 175);
            this.GameControlsComboBox.Name = "GameControlsComboBox";
            this.GameControlsComboBox.Size = new System.Drawing.Size(200, 23);
            this.GameControlsComboBox.TabIndex = 12;
            this.GameControlsComboBox.SelectedIndexChanged += new System.EventHandler(this.GameControlsComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(200, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Path:";
            // 
            // GamePathButton
            // 
            this.GamePathButton.Enabled = false;
            this.GamePathButton.Location = new System.Drawing.Point(300, 305);
            this.GamePathButton.Name = "GamePathButton";
            this.GamePathButton.Size = new System.Drawing.Size(100, 23);
            this.GamePathButton.TabIndex = 14;
            this.GamePathButton.Text = "Select .zip";
            this.GamePathButton.UseVisualStyleBackColor = true;
            this.GamePathButton.Click += new System.EventHandler(this.GamePathButton_Click);
            // 
            // GamePathTextBox
            // 
            this.GamePathTextBox.Enabled = false;
            this.GamePathTextBox.Location = new System.Drawing.Point(300, 275);
            this.GamePathTextBox.Name = "GamePathTextBox";
            this.GamePathTextBox.ReadOnly = true;
            this.GamePathTextBox.Size = new System.Drawing.Size(200, 23);
            this.GamePathTextBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(200, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Image:";
            // 
            // GameImageTextBox
            // 
            this.GameImageTextBox.Enabled = false;
            this.GameImageTextBox.Location = new System.Drawing.Point(300, 350);
            this.GameImageTextBox.Name = "GameImageTextBox";
            this.GameImageTextBox.ReadOnly = true;
            this.GameImageTextBox.Size = new System.Drawing.Size(200, 23);
            this.GameImageTextBox.TabIndex = 17;
            // 
            // GameImageButton
            // 
            this.GameImageButton.Enabled = false;
            this.GameImageButton.Location = new System.Drawing.Point(300, 380);
            this.GameImageButton.Name = "GameImageButton";
            this.GameImageButton.Size = new System.Drawing.Size(100, 23);
            this.GameImageButton.TabIndex = 18;
            this.GameImageButton.Text = "Select Image";
            this.GameImageButton.UseVisualStyleBackColor = true;
            this.GameImageButton.Click += new System.EventHandler(this.GameImageButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(200, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Itch URL:";
            // 
            // GameURLTextBox
            // 
            this.GameURLTextBox.Enabled = false;
            this.GameURLTextBox.Location = new System.Drawing.Point(300, 225);
            this.GameURLTextBox.Name = "GameURLTextBox";
            this.GameURLTextBox.Size = new System.Drawing.Size(200, 23);
            this.GameURLTextBox.TabIndex = 20;
            this.GameURLTextBox.TextChanged += new System.EventHandler(this.GameURLTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(525, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Description:";
            // 
            // GameDescTextBox
            // 
            this.GameDescTextBox.Enabled = false;
            this.GameDescTextBox.Location = new System.Drawing.Point(525, 100);
            this.GameDescTextBox.Name = "GameDescTextBox";
            this.GameDescTextBox.Size = new System.Drawing.Size(300, 303);
            this.GameDescTextBox.TabIndex = 22;
            this.GameDescTextBox.Text = "";
            this.GameDescTextBox.TextChanged += new System.EventHandler(this.GameDescTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.GameDescTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GameURLTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GameImageButton);
            this.Controls.Add(this.GameImageTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GamePathTextBox);
            this.Controls.Add(this.GamePathButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GameControlsComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GameDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GamesBox);
            this.Controls.Add(this.AddGameButton);
            this.Controls.Add(this.RemoveGameButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.LoadFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button RemoveGameButton;
        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.ListBox GamesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GameNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker GameDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GameControlsComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button GamePathButton;
        private System.Windows.Forms.TextBox GamePathTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox GameImageTextBox;
        private System.Windows.Forms.Button GameImageButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GameURLTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox GameDescTextBox;
    }
}

