using Compiler;
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
                fileLogic.SaveFileAs(input.Text);
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
                            input.Text = reader.ReadToEnd();
                        }
                        PrintFileName();
                    }
                }
                else
                {
                    fileLogic.OpenFile();
                    using (StreamReader reader = new StreamReader(fileLogic.OpenFilePath))
                    {
                        input.Text = reader.ReadToEnd();
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
                fileLogic.SaveFileChanges(input.Text);

                PrintFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backChanges_Click(object sender, EventArgs e)
        {
            input.Undo();
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            input.Redo();
        }

        private void copyText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(input.SelectedText))
                Clipboard.SetText(input.SelectedText);

        }

        private void cutText_Click(object sender, EventArgs e)
        {
            if (input.SelectedText != "")
            {
                // �������� ���������� ����� � ����� ������
                Clipboard.SetText(input.SelectedText);

                // ������� ���������� �����
                input.SelectedText = "";
            }
        }

        private void putText_Click(object sender, EventArgs e)
        {
            if (input.Focused && Clipboard.ContainsText())
            {
                int cursorPosition = input.SelectionStart; // ��������� ������� �������

                string text = input.Text;
                string textBeforeCursor = text.Substring(0, cursorPosition);
                string textAfterCursor = text.Substring(cursorPosition + input.SelectionLength, text.Length - cursorPosition - input.SelectionLength);

                input.Text = textBeforeCursor + Clipboard.GetText() + textAfterCursor;
                input.SelectionStart = cursorPosition + Clipboard.GetText().Length; // ������������� ����� ������� ������� ����� �������
            }
        }

        private void start_Click(object sender, EventArgs e)
        {

           // Lexer(input.Text);
            StartParse(input.Text);
        }

        public void StartParse(string text)
        {
            ParserDataGrid.Rows.Clear();
            Parser parser = new Parser(text);
            parser.Parse(text);
            for (int i = 0; i < parser.Errors.Count; i++)
            {
                ParserDataGrid.Rows.Add(i+1, parser.Errors[i].Position, parser.Errors[i].Message);
            }
            if (parser.Errors.Count == 0)
            {
                MessageBox.Show("������ �� ����������!");
            }
        }

        public void Lexer(string text)
        {
            LexerDataGrid.Rows.Clear();
            List<Lexeme> lexemes = new List<Lexeme>();
            LexicalAnalyzer analyzer = new LexicalAnalyzer();
            lexemes = analyzer.Analyze(text);
            for (int i = 0; i < lexemes.Count; i++)
            {
                LexerDataGrid.Rows.Add(i + 1, lexemes[i].LexemeId, lexemes[i].LexemeName, lexemes[i].Value, lexemes[i].Position);
            }
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
            input.SelectAll();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(input.SelectedText))
                input.SelectedText = ""; // ������� ���������� ����� � �������� ��� � �����

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
