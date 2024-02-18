using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class FileLogic
    {
        public string OpenFilePath { get; private set; } = "";

        public void SaveFileChanges(string fileText)
        {
            if (OpenFilePath.Length == 0)
            {
               SaveFileAs(fileText);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(OpenFilePath))
                {
                    writer.WriteLine(fileText);
                }
                MessageBox.Show($"Измениения успешно сохранены.", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void SaveFileAs(string fileText)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    // Здесь можно записать нужные данные в файл
                    writer.WriteLine(fileText);
                }
                OpenFilePath = saveDialog.FileName;
                MessageBox.Show($"Файл {saveDialog.FileName} успешно сохранен.", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFilePath = openFileDialog.FileName;
            }
            else
            {
                throw new Exception("exeption");
            }
        }



    }
}
