using Compiler;
using Lab5;
using Lab7;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.Design.AxImporter;


namespace WinFormsApp1
{
    public partial class Compiler : Form
    {
        private bool textChanged = false;
        private FileLogic fileLogic = new FileLogic();
        private string openFilePath;
        private const string filePath = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\Help.html";
        private const string TaskFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\Task.html";
        private const string GrammarFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\Grammar.html";
        private const string ClassificationGrammarFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\ClassificationGrammar.html";
        private const string AnalyzeMethodFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\AnalyzeMethod.html";
        private const string LiteratureFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\Literature.html";
        private const string CodeFile = @"C:\Users\pakan\Desktop\������\6 �����\������ ���������� ������ � ������������\WinFormsApp1\Resources\Code.html";

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

        List<ParserError> _incorrectLexemes;

        private void start_Click(object sender, EventArgs e)
        {
            ParserDataGrid.Rows.Clear();
            LexicalAnalyzer analyzer = new LexicalAnalyzer();
            ReqParser reqParser = new ReqParser();
            reqParser.Input = input.Text;
            reqParser.Parse(analyzer.Analyze(input.Text));

            for (int i = 0; i < reqParser.Errors.Count; i++)
            {
                ParserDataGrid.Rows.Add(i + 1, reqParser.Errors[i].Position, reqParser.Errors[i].Message);
            }
            if (reqParser.Errors.Count == 0)
            {
                MessageBox.Show("������ �� ����������!");
            }
        }

        /*        void lab6Method()
                {
                    TextBoxLab6.Text = "";
                    ValidateNotZero(input.Text);
                    ValidatePyComments(input.Text);
                    ValidateRusCarsNumbers(input.Text);
                }

                void lab7Method()
                {
                    TextBoxLab7.Text = "";
                    WhileLexer whileLexer = new WhileLexer();
                    WhileParser whileParser = new WhileParser();

                   TextBoxLab7.Text += whileParser.Parse(whileLexer.Analyze(input.Text));
                }

                public void ValidateNotZero(string input)
                {
                    string pattern = @"\b\d*[1-9]\b";
                    Regex regex = new Regex(pattern);
                    foreach (Match m in Regex.Matches(input, pattern))
                    {
                        TextBoxLab6.Text += "�� �������: " + m.Index + " ������� ����� �� ��������������� �� 0: " + m.Value + '\n';
                    }
                }
                public void ValidatePyComments(string input)
                {
                    string pattern = @"#.*";
                    Regex regex = new Regex(pattern);

                    foreach (Match m in Regex.Matches(input, pattern))
                    {
                        TextBoxLab6.Text += "�� �������: " + m.Index + " ������ ������������ ����������� python: " + m.Value + '\n';
                    }
                }
                public void ValidateRusCarsNumbers(string input)
                {
                    string pattern = @"^[������������]{1}(?!000)\d{3}[������������]{2}" +
                                     "(0[1-9]|[1-7][0-9]|8[0-9]|9[0-1]|102|702|113|116|716|121|93|123|193|" +
                                     "124|125|126|134|136|138|91|139|142|147|90|150|190|750|790|550|" +
                                     "152|252|154|156|159|161|761|163|763|164|96|196|173|174|97|99|" +
                                     "177|197|199|777|797|799|977|98|178|198|186|94)$";

                    Regex regex = new Regex(pattern);

                    RegexOptions options = RegexOptions.Multiline;

                    foreach (Match m in Regex.Matches(input, pattern, options))
                    {
                        TextBoxLab6.Text += "�� �������: " + m.Index + " ������ �����: " + m.Value +  '\n';
                    }
                }


                public void PolishNotation(string text)
                {
                    try
                    {
                        PolishNotationCalculator calc = new PolishNotationCalculator(text);
                        polishTextBox.Text = "";
                        polishTextBox.Text += "�������� ���������:\n" + text + "\n";
                        polishTextBox.Text += "�������������� ��������� � �����:\n" + calc.postfixExpr + "\n";
                        polishTextBox.Text += "����������� ���������:\n�����: " + calc.Calc();
                    } catch (Exception ex)
                    {
                        polishTextBox.Text = ex.Message;
                    }
                }
                public void StartParse(string text)
                {
                    ParserDataGrid.Rows.Clear();
                    Parser parser = new Parser(text);
                    parser.Parse(text);
                    _incorrectLexemes = parser.Errors;
                    for (int i = 0; i < parser.Errors.Count; i++)
                    {
                        ParserDataGrid.Rows.Add(i + 1, parser.Errors[i].Position, parser.Errors[i].Message);
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
        */

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

        private void cleanErrors(object sender, EventArgs e)
        {
            if (_incorrectLexemes.Count > 0)
                input.Text = TextCleaner.RemoveIncorrectLexemes(input.Text, _incorrectLexemes);

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParserDataGrid.Rows.Clear();
            LexicalAnalyzer analyzer = new LexicalAnalyzer();
            ReqParser reqParser = new ReqParser();
            reqParser.Input = input.Text;
            reqParser.Parse(analyzer.Analyze(input.Text));

            for (int i = 0; i < reqParser.Errors.Count; i++)
            {
                ParserDataGrid.Rows.Add(i + 1, reqParser.Errors[i].Position, reqParser.Errors[i].Message);
            }
            if (reqParser.Errors.Count == 0)
            {
                MessageBox.Show("������ �� ����������!");
            }
        }

        private void Task_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(TaskFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(TaskFile) { UseShellExecute = true };
                p.Start();
            }

        }

        private void Grammar_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(GrammarFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(GrammarFile) { UseShellExecute = true };
                p.Start();
            }

        }

        private void ClassificationGrammar_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(ClassificationGrammarFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(ClassificationGrammarFile) { UseShellExecute = true };
                p.Start();
            }

        }

        private void AnalyzeMethod_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(AnalyzeMethodFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(AnalyzeMethodFile) { UseShellExecute = true };
                p.Start();
            }

        }

        private void Example_Click(object sender, EventArgs e)
        {
            input.Text = "const double PI = 3.14; \nconst double name_1 = 34;";
        }

        private void Literature_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(LiteratureFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(LiteratureFile) { UseShellExecute = true };
                p.Start();
            }

        }

        private void Code_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(CodeFile))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(CodeFile) { UseShellExecute = true };
                p.Start();
            }

        }
    }
}
