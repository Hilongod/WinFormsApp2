using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private Stack<string> navigationHistory;
        private string currentPath;

        public Form1()
        {
            InitializeComponent();
            navigationHistory = new Stack<string>();
            LoadDrives();
        }

        private void LoadDrives()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                        comboBoxDrives.Items.Add(drive.Name);
                }

                if (comboBoxDrives.Items.Count > 0)
                    comboBoxDrives.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке дисков: " + ex.Message);
            }
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrives.SelectedItem != null)
            {
                currentPath = comboBoxDrives.SelectedItem.ToString();
                LoadDirectoryContents(currentPath);
                navigationHistory.Clear();
                buttonBack.Enabled = false;
            }
        }

        private void listBoxDirectories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Снимаем выделение с файлов, чтобы не было двух выделений одновременно
            listBoxFiles.ClearSelected();

            if (listBoxDirectories.SelectedItem != null)
            {
                string selected = listBoxDirectories.SelectedItem.ToString();
                bool isValid = (selected != "Нет доступных каталогов");
                buttonShow.Enabled = isValid;
                buttonProperties.Enabled = isValid;
            }
            else
            {
                buttonShow.Enabled = false;
                buttonProperties.Enabled = false;
            }
        }

        // НОВЫЙ обработчик — выбор файла в listBoxFiles
        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Снимаем выделение с папок
            listBoxDirectories.ClearSelected();
            buttonShow.Enabled = false;

            buttonProperties.Enabled = (listBoxFiles.SelectedItem != null);
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (listBoxDirectories.SelectedItem != null)
            {
                string selectedFolder = listBoxDirectories.SelectedItem.ToString();
                navigationHistory.Push(currentPath);

                string newPath = currentPath.EndsWith("\\")
                    ? currentPath + selectedFolder
                    : currentPath + "\\" + selectedFolder;

                currentPath = newPath;
                LoadDirectoryContents(currentPath);

                buttonBack.Enabled = true;
                buttonShow.Enabled = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (navigationHistory.Count > 0)
            {
                currentPath = navigationHistory.Pop();
                LoadDirectoryContents(currentPath);

                buttonBack.Enabled = (navigationHistory.Count > 0);
                buttonShow.Enabled = false;
                buttonProperties.Enabled = false;
            }
        }

        // НОВЫЙ обработчик — кнопка "Свойства"
        private void buttonProperties_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли папка
            if (listBoxDirectories.SelectedItem != null)
            {
                string dirName = listBoxDirectories.SelectedItem.ToString();
                string fullPath = currentPath.EndsWith("\\")
                    ? currentPath + dirName
                    : currentPath + "\\" + dirName;

                PropertiesForm form = new PropertiesForm(fullPath, isDirectory: true);
                form.ShowDialog();
            }
            // Проверяем, выбран ли файл
            else if (listBoxFiles.SelectedItem != null)
            {
                // В listBox файлы хранятся как "name.ext (123 KB)" — извлекаем только имя
                string fileEntry = listBoxFiles.SelectedItem.ToString();
                string fileName = fileEntry.Substring(0, fileEntry.LastIndexOf(" ("));
                string fullPath = currentPath.EndsWith("\\")
                    ? currentPath + fileName
                    : currentPath + "\\" + fileName;

                PropertiesForm form = new PropertiesForm(fullPath, isDirectory: false);
                form.ShowDialog();
            }
        }

        private void LoadDirectoryContents(string path)
        {
            try
            {
                labelCurrentPath.Text = "Текущий путь: " + path;

                listBoxDirectories.Items.Clear();
                listBoxFiles.Items.Clear();

                string[] directories = Directory.GetDirectories(path);
                foreach (string dir in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    listBoxDirectories.Items.Add(dirInfo.Name);
                }

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long sizeKB = fileInfo.Length / 1024;
                    listBoxFiles.Items.Add(fileInfo.Name + " (" + sizeKB + " KB)");
                }

                if (directories.Length == 0)
                    listBoxDirectories.Items.Add("Нет доступных каталогов");

                buttonProperties.Enabled = false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Нет доступа к этому каталогу");

                if (navigationHistory.Count > 0)
                {
                    currentPath = navigationHistory.Pop();
                    LoadDirectoryContents(currentPath);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}