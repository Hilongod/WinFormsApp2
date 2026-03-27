namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            buttonShow = new Button();
            buttonBack = new Button();
            buttonProperties = new Button();  // НОВОЕ
            comboBoxDrives = new ComboBox();
            listBoxDirectories = new ListBox();
            listBoxFiles = new ListBox();
            labelCurrentPath = new Label();
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
            // buttonProperties  НОВОЕ
            // 
            buttonProperties.Enabled = false;
            buttonProperties.Location = new Point(290, 352);  // правее buttonShow
            buttonProperties.Name = "buttonProperties";
            buttonProperties.Size = new Size(90, 23);
            buttonProperties.TabIndex = 6;
            buttonProperties.Text = "СВОЙСТВА";
            buttonProperties.UseVisualStyleBackColor = true;
            buttonProperties.Click += buttonProperties_Click;
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
            listBoxFiles.SelectedIndexChanged += listBoxFiles_SelectedIndexChanged;  // НОВОЕ
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelCurrentPath);
            Controls.Add(listBoxFiles);
            Controls.Add(listBoxDirectories);
            Controls.Add(comboBoxDrives);
            Controls.Add(buttonBack);
            Controls.Add(buttonShow);
            Controls.Add(buttonProperties);  // НОВОЕ
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonShow;
        private Button buttonBack;
        private Button buttonProperties;  // НОВОЕ
        private ComboBox comboBoxDrives;
        private ListBox listBoxDirectories;
        private ListBox listBoxFiles;
        private Label labelCurrentPath;
    }
}