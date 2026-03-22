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
                    {
                        comboBoxDrives.Items.Add(drive.Name);
                    }
                }

                if (comboBoxDrives.Items.Count > 0)
                {
                    comboBoxDrives.SelectedIndex = 0;
                }
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
            if (listBoxDirectories.SelectedItem != null)
            {
                string selected = listBoxDirectories.SelectedItem.ToString();
                buttonShow.Enabled = (selected != "Нет доступных каталогов");
            }
            else
            {
                buttonShow.Enabled = false;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (listBoxDirectories.SelectedItem != null)
            {
                string selectedFolder = listBoxDirectories.SelectedItem.ToString();
                navigationHistory.Push(currentPath);
                string newPath;
                if (currentPath.EndsWith("\\"))
                    newPath = currentPath + selectedFolder;
                else
                    newPath = currentPath + "\\" + selectedFolder;

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
                {
                    listBoxDirectories.Items.Add("Нет доступных каталогов");
                }
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
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string query = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Введите поисковый запрос");
                return;
            }

            if (string.IsNullOrEmpty(currentPath))
            {
                MessageBox.Show("Сначала выберите диск");
                return;
            }

            listBoxSearch.Items.Clear();
            labelSearch.Text = "Идёт поиск...";
            buttonSearch.Enabled = false;  // блокируем кнопку на время поиска

            await Task.Run(() => SearchFiles(currentPath, query));

            if (listBoxSearch.Items.Count == 0)
                listBoxSearch.Items.Add("Ничего не найдено");

            labelSearch.Text = $"Результатов найдено: {listBoxSearch.Items.Count}";
            buttonSearch.Enabled = true;  // разблокируем кнопку
        }

        private void SearchFiles(string path, string query)
        {
            try
            {
                string[] files = Directory.GetFiles(path, "*" + query + "*");
                foreach (string file in files)
                {
                    // Invoke нужен чтобы обращаться к UI из другого потока
                    listBoxSearch.Invoke(() =>
                    {
                        listBoxSearch.Items.Add("[Файл] " + file);
                    });
                }

                string[] dirs = Directory.GetDirectories(path, "*" + query + "*");
                foreach (string dir in dirs)
                {
                    listBoxSearch.Invoke(() =>
                    {
                        listBoxSearch.Items.Add("[Папка] " + dir);
                    });
                }

                string[] allDirs = Directory.GetDirectories(path);
                foreach (string dir in allDirs)
                {
                    SearchFiles(dir, query);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // пропускаем папки без доступа
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
