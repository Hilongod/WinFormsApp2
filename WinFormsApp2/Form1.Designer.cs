namespace WinFormsApp2
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
            buttonShow = new Button();
            buttonBack = new Button();
            comboBoxDrives = new ComboBox();
            listBoxDirectories = new ListBox();
            listBoxFiles = new ListBox();
            labelCurrentPath = new Label();
            textBox1 = new TextBox();
            buttonSearch = new Button();
            listBoxSearch = new ListBox();
            labelSearch = new Label();
            SuspendLayout();
            // 
            // buttonShow
            // 
            buttonShow.Enabled = false;
            buttonShow.Location = new Point(184, 352);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(75, 23);
            buttonShow.TabIndex = 0;
            buttonShow.Text = "ПЕРЕЙТИ";
            buttonShow.UseVisualStyleBackColor = true;
            buttonShow.Click += buttonShow_Click;
            // 
            // buttonBack
            // 
            buttonBack.Enabled = false;
            buttonBack.Location = new Point(78, 352);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(75, 23);
            buttonBack.TabIndex = 1;
            buttonBack.Text = "НАЗАД";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // comboBoxDrives
            // 
            comboBoxDrives.FormattingEnabled = true;
            comboBoxDrives.Location = new Point(78, 35);
            comboBoxDrives.Name = "comboBoxDrives";
            comboBoxDrives.Size = new Size(121, 23);
            comboBoxDrives.TabIndex = 2;
            comboBoxDrives.SelectedIndexChanged += comboBoxDrives_SelectedIndexChanged;
            // 
            // listBoxDirectories
            // 
            listBoxDirectories.FormattingEnabled = true;
            listBoxDirectories.Location = new Point(12, 90);
            listBoxDirectories.Name = "listBoxDirectories";
            listBoxDirectories.Size = new Size(287, 244);
            listBoxDirectories.TabIndex = 3;
            listBoxDirectories.SelectedIndexChanged += listBoxDirectories_SelectedIndexChanged;
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.Location = new Point(335, 90);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(199, 244);
            listBoxFiles.TabIndex = 4;
            // 
            // labelCurrentPath
            // 
            labelCurrentPath.AutoSize = true;
            labelCurrentPath.Location = new Point(235, 38);
            labelCurrentPath.Name = "labelCurrentPath";
            labelCurrentPath.Size = new Size(87, 15);
            labelCurrentPath.TabIndex = 5;
            labelCurrentPath.Text = "Текущий путь:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(579, 353);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 23);
            textBox1.TabIndex = 6;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(614, 400);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 7;
            buttonSearch.Text = "НАЙТИ";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // listBoxSearch
            // 
            listBoxSearch.FormattingEnabled = true;
            listBoxSearch.Location = new Point(569, 90);
            listBoxSearch.Name = "listBoxSearch";
            listBoxSearch.Size = new Size(198, 244);
            listBoxSearch.TabIndex = 8;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(569, 43);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(107, 15);
            labelSearch.TabIndex = 9;
            labelSearch.Text = "Результаты поска:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelSearch);
            Controls.Add(listBoxSearch);
            Controls.Add(buttonSearch);
            Controls.Add(textBox1);
            Controls.Add(labelCurrentPath);
            Controls.Add(listBoxFiles);
            Controls.Add(listBoxDirectories);
            Controls.Add(comboBoxDrives);
            Controls.Add(buttonBack);
            Controls.Add(buttonShow);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonShow;
        private Button buttonBack;
        private ComboBox comboBoxDrives;
        private ListBox listBoxDirectories;
        private ListBox listBoxFiles;
        private Label labelCurrentPath;
        private TextBox textBox1;
        private Button buttonSearch;
        private ListBox listBoxSearch;
        private Label labelSearch;
    }
}
