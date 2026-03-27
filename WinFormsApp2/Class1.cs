using System.Windows.Forms;

namespace WinFormsApp2
{
    public class PropertiesForm : Form
    {
        public PropertiesForm(string fullPath, bool isDirectory)
        {
            this.Text = "Свойства";
            this.Size = new System.Drawing.Size(420, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            ListView listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };

            listView.Columns.Add("Свойство", 150);
            listView.Columns.Add("Значение", 230);

            try
            {
                if (isDirectory)
                {
                    DirectoryInfo dir = new DirectoryInfo(fullPath);

                    // Считаем размер папки рекурсивно
                    long totalSize = GetDirectorySize(dir);
                    int fileCount = dir.GetFiles("*", SearchOption.AllDirectories).Length;
                    int dirCount = dir.GetDirectories("*", SearchOption.AllDirectories).Length;

                    listView.Items.Add(new ListViewItem(new[]
                        { "Тип", "Папка" }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Имя", dir.Name }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Полный путь", dir.FullName }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Размер", FormatSize(totalSize) }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Файлов внутри", fileCount.ToString() }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Папок внутри", dirCount.ToString() }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Создан", dir.CreationTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Изменён", dir.LastWriteTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Открыт", dir.LastAccessTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Атрибуты", dir.Attributes.ToString() }));
                }
                else
                {
                    FileInfo file = new FileInfo(fullPath);

                    listView.Items.Add(new ListViewItem(new[]
                        { "Тип", "Файл" }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Имя", file.Name }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Расширение", file.Extension }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Полный путь", file.FullName }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Размер", FormatSize(file.Length) }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Создан", file.CreationTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Изменён", file.LastWriteTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Открыт", file.LastAccessTime.ToString("dd.MM.yyyy HH:mm:ss") }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Атрибуты", file.Attributes.ToString() }));
                    listView.Items.Add(new ListViewItem(new[]
                        { "Только чтение", file.IsReadOnly ? "Да" : "Нет" }));
                }
            }
            catch (Exception ex)
            {
                listView.Items.Add(new ListViewItem(new[]
                    { "Ошибка", ex.Message }));
            }

            Button btnClose = new Button
            {
                Text = "Закрыть",
                Dock = DockStyle.Bottom,
                Height = 35
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(listView);
            this.Controls.Add(btnClose);
        }

        // Рекурсивный подсчёт размера папки
        private long GetDirectorySize(DirectoryInfo dir)
        {
            long size = 0;
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                    size += file.Length;

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                    size += GetDirectorySize(subDir);
            }
            catch (UnauthorizedAccessException) { /* пропускаем недоступные */ }
            return size;
        }

        // Форматирование размера: B / KB / MB / GB
        private string FormatSize(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} Б";
            else if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:F2} КБ";
            else if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / (1024.0 * 1024):F2} МБ";
            else
                return $"{bytes / (1024.0 * 1024 * 1024):F2} ГБ";
        }
    }
}