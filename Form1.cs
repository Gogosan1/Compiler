using Compiler;
using Lab5;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;
using static System.Windows.Forms.Design.AxImporter;


namespace WinFormsApp1
{
    public partial class Compiler : Form
    {
        private bool textChanged = false;
        private FileLogic fileLogic = new FileLogic();
        private string openFilePath;
        private const string filePath = @"C:\Users\pakan\Desktop\Универ\6 семак\Теория формальных языков и компиляторов\WinFormsApp1\Help.html";

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
                    var result = MessageBox.Show("Вы уверены, что хотите открыть новый файл?\n" +
                         " Текущие изменения не сохранятся!", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                // Копируем выделенный текст в буфер обмена
                Clipboard.SetText(input.SelectedText);

                // Удаляем выделенный текст
                input.SelectedText = "";
            }
        }

        private void putText_Click(object sender, EventArgs e)
        {
            if (input.Focused && Clipboard.ContainsText())
            {
                int cursorPosition = input.SelectionStart; // сохраняем позицию курсора

                string text = input.Text;
                string textBeforeCursor = text.Substring(0, cursorPosition);
                string textAfterCursor = text.Substring(cursorPosition + input.SelectionLength, text.Length - cursorPosition - input.SelectionLength);

                input.Text = textBeforeCursor + Clipboard.GetText() + textAfterCursor;
                input.SelectionStart = cursorPosition + Clipboard.GetText().Length; // устанавливаем новую позицию курсора после вставки
            }
        }

        private void start_Click(object sender, EventArgs e)
        {

            // Lexer(input.Text);
            //StartParse(input.Text);
            // PolishNotation(input.Text);
            lab6Method();
        }

        void lab6Method()
        {
            TextBoxLab6.Text = "";
            ValidateNotZero(input.Text);
            ValidatePyComments(input.Text);
            ValidateRusCarsNumbers(input.Text);
        }

        public void ValidateNotZero(string input)
        {
            string pattern = @"\b\d*[1-9]\b";
            Regex regex = new Regex(pattern);
            foreach (Match m in Regex.Matches(input, pattern))
            {
                TextBoxLab6.Text += "На позиции: " + m.Index + " найдено число не заканчивающееся на 0: " + m.Value + '\n';
            }
        }

        public void ValidatePyComments(string input)
        {
            string pattern = @"#.*";
            Regex regex = new Regex(pattern);

            foreach (Match m in Regex.Matches(input, pattern))
            {
                TextBoxLab6.Text += "На позиции: " + m.Index + " найден однострочный комментарий python: " + m.Value + '\n';
            }
        }

        public void ValidateRusCarsNumbers(string input)
        {
            string pattern = @"^[АВЕКМНОРСТУХ]{1}(?!000)\d{3}[АВЕКМНОРСТУХ]{2}" +
                             "(0[1-9]|[1-7][0-9]|8[0-9]|9[0-1]|102|702|113|116|716|121|93|123|193|" +
                             "124|125|126|134|136|138|91|139|142|147|90|150|190|750|790|550|" +
                             "152|252|154|156|159|161|761|163|763|164|96|196|173|174|97|99|" +
                             "177|197|199|777|797|799|977|98|178|198|186|94)$";

            Regex regex = new Regex(pattern);

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                TextBoxLab6.Text += "На позиции: " + m.Index + " найден номер: " + m.Value +  '\n';
            }
        }

        private List<Match> GetMatchesWithPositions(string input, Regex regex)
        {
            List<Match> matches = [.. regex.Matches(input).Cast<Match>()];
            return matches;
        }

        List<ParserError> _incorrectLexemes;


        public void PolishNotation(string text)
        {
            try
            {
                PolishNotationCalculator calc = new PolishNotationCalculator(text);
                polishTextBox.Text = "";
                polishTextBox.Text += "Исходное выражение:\n" + text + "\n";
                polishTextBox.Text += "Арифметическое выражение в ПОЛИЗ:\n" + calc.postfixExpr + "\n";
                polishTextBox.Text += "Подсчитаное выражение:\nОтвет: " + calc.Calc();
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
                MessageBox.Show("Ошибок не обнаружено!");
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
            MessageBox.Show("Выполнил Зеленев Павел Андреевич\n" +
                "студент группы АВТ-113", "Автор");
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
                input.SelectedText = ""; // Удаляем выделенный текст и помещаем его в буфер

        }

        private void Compiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChanged == true)
            {
                if (MessageBox.Show("Вы уверены, что хотите закрыть программу?\n" +
                    "Текущие изменения не сохранятся!", "Подтвердите закрытие", MessageBoxButtons.YesNo) != DialogResult.Yes)
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
    }
}
