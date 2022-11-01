using System;
using System.Windows.Forms;
using System.IO;

namespace lab2.ch_m
{
    public partial class Form1 : Form
    {
        private string dirName = "Q:\\2";
        string[] files;
        string[] folders;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Directory.Exists(dirName))
            {
                DirShow();
            }
        }

        public void DirShow()
        {
            if (Directory.GetParent(dirName) == null)
            {
                назадToolStripMenuItem.Enabled = false;
            }
            else
            {
                назадToolStripMenuItem.Enabled = true;
            }
            lvDir.Clear();
            files = Directory.GetFiles(dirName);
            folders = Directory.GetDirectories(dirName);
            foreach (string file in files)
            {
                string[] s = file.Split('\\');
                lvDir.Items.Add(s[s.Length - 1]);
            }
            foreach (string folder in folders)
            {
                string[] s = folder.Split('\\');
                lvDir.Items.Add(s[s.Length - 1]);
            }
            lbActive.Text = dirName;
            удалитьToolStripMenuItem.Enabled = false;
        }

        private void Del(string target)
        {
            string[] filer;
            try
            {
                foreach (string file in files)
                {
                    filer = file.Split('\\');
                    if (filer[filer.Length - 1] == target) File.Delete(file);
                }
                foreach (string dir in folders)
                {
                    filer = dir.Split('\\');
                    if (filer[filer.Length - 1] == target) Directory.Delete(dir);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка. Каталог не найден.");
            }
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void оНасToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Состав команды:\n" +
                "Зиатдинов Ильназ\n" +
                "Камалутдинов Ирек\n"+
                "Ковалёв Роман");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(lvDir.SelectedItems.Count == 1)
                {
                    if (!Directory.Exists(dirName + "\\" + lvDir.SelectedItems[0].Text))
                    {
                        throw new DirException("Ошибка");
                    }
                    else
                    {
                        dirName += "\\" + lvDir.SelectedItems[0].Text;
                        MessageBox.Show("Каталог успешно изменён!");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка. Не выбрана папка, либо выбрано больше одной папки!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка. Заданный каталог не существует.");
            }
            finally
            {
                DirShow();
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.GetParent(dirName) == null)
                {
                    throw new DirException("Ошибка. Это родительский каталог");
                }
                else
                {
                    dirName = Directory.GetParent(dirName).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка. Это родительский каталог!");
            }
            finally
            {
                DirShow();
            }
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDir.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lvDir.SelectedItems.Count; i++)
                {
                    Del(lvDir.SelectedItems[i].Text);
                }
                MessageBox.Show("Удаление успешно!");
                DirShow();
            }
            else
            {
                MessageBox.Show("Выберите файлы для удаления");
            }
        }
        private void ItemSelectionChanged(object sender, EventArgs e)
        {
            if (lvDir.SelectedItems.Count > 0)
            {
                удалитьToolStripMenuItem.Enabled = true;
            }
            else
            {
                удалитьToolStripMenuItem.Enabled = false;
            }
        }
    }
}
