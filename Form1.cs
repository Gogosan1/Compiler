using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Compiler : Form
    {
        private bool textChanged = false;
        private FileLogic fileLogic = new FileLogic();
        private string openFilePath;
        private const string filePath = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Help.html";
 
        public Compiler()
        {
            InitializeComponent();
        }

        private void createNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                fileLogic.SaveFileAs(richTextBox.Text);
                PrintFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (textChanged == true)
                {
                    var result = MessageBox.Show("�� �������, ��� ������ ������� ����� ����?\n" +
                         " ������� ��������� �� ����������!", "��������������!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        fileLogic.OpenFile();

                        using (StreamReader reader = new StreamReader(fileLogic.OpenFilePath))
                        {
                            richTextBox.Text = reader.ReadToEnd();
                        }
                        PrintFileName();
                    }
                }
                else
                {
                    fileLogic.OpenFile();
                    using (StreamReader reader = new StreamReader(fileLogic.OpenFilePath))
                    {
                        richTextBox.Text = reader.ReadToEnd();
                    }
                    PrintFileName();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PrintFileName()
        {
            FileNameParser fileNameParser = new FileNameParser();

            tabControl1.TabPages[0].Text = fileNameParser.ParseFileName(fileLogic.OpenFilePath);
            textChanged = false;

        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                fileLogic.SaveFileChanges(richTextBox.Text);

                PrintFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backChanges_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void copyText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
                Clipboard.SetText(richTextBox.SelectedText);

        }

        private void cutText_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
            {
                // �������� ���������� ����� � ����� ������
                Clipboard.SetText(richTextBox.SelectedText);

                // ������� ���������� �����
                richTextBox.SelectedText = "";
            }
        }

        private void putText_Click(object sender, EventArgs e)
        {
            if (richTextBox.Focused && Clipboard.ContainsText())
            {
                int cursorPosition = richTextBox.SelectionStart; // ��������� ������� �������

                string text = richTextBox.Text;
                string textBeforeCursor = text.Substring(0, cursorPosition);
                string textAfterCursor = text.Substring(cursorPosition + richTextBox.SelectionLength, text.Length - cursorPosition - richTextBox.SelectionLength);

                richTextBox.Text = textBeforeCursor + Clipboard.GetText() + textAfterCursor;
                richTextBox.SelectionStart = cursorPosition + Clipboard.GetText().Length; // ������������� ����� ������� ������� ����� �������
            }
        }

        private void start_Click(object sender, EventArgs e)
        {

        }

        private void info_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(filePath))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(filePath) { UseShellExecute = true };
                p.Start();
            }
         }

        private void createdBy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�������� ������� ����� ���������\n" +
                "������� ������ ���-113", "�����");
        }


        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                saveChanges_Click(sender, e);

        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
                richTextBox.SelectedText = ""; // ������� ���������� ����� � �������� ��� � �����

        }


        private void Compiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChanged == true)
            {
                if (MessageBox.Show("�� �������, ��� ������ ������� ���������?\n" +
                    "������� ��������� �� ����������!", "����������� ��������", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true; 
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compiler_FormClosing(sender, (FormClosingEventArgs)e);
        }



       
    }
}
