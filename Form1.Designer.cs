namespace WinFormsApp1
{
    partial class Compiler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compiler));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            CloseToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            отменToolStripMenuItem = new ToolStripMenuItem();
            повторитьToolStripMenuItem = new ToolStripMenuItem();
            вырезатьToolStripMenuItem = new ToolStripMenuItem();
            копироватьToolStripMenuItem = new ToolStripMenuItem();
            вставитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            выделитьToolStripMenuItem = new ToolStripMenuItem();
            текстToolStripMenuItem = new ToolStripMenuItem();
            Task = new ToolStripMenuItem();
            Grammar = new ToolStripMenuItem();
            ClassificationGrammar = new ToolStripMenuItem();
            AnalyzeMethod = new ToolStripMenuItem();
            Example = new ToolStripMenuItem();
            Literature = new ToolStripMenuItem();
            Code = new ToolStripMenuItem();
            пускToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            вызовСправкиToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            createNewFile = new ToolStripButton();
            openFile = new ToolStripButton();
            saveChanges = new ToolStripButton();
            backChanges = new ToolStripButton();
            repeat = new ToolStripButton();
            copyText = new ToolStripButton();
            putText = new ToolStripButton();
            cutText = new ToolStripButton();
            start = new ToolStripButton();
            info = new ToolStripButton();
            createdBy = new ToolStripButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            input = new RichTextBox();
            splitContainer1 = new SplitContainer();
            tabControl2 = new TabControl();
            parser1 = new TabPage();
            ParserDataGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl2.SuspendLayout();
            parser1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ParserDataGrid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, текстToolStripMenuItem, пускToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 28);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, CloseToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(192, 26);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += createNewFile_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(192, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += openFile_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(192, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += saveChanges_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new Size(192, 26);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            сохранитьКакToolStripMenuItem.Click += createNewFile_Click;
            // 
            // CloseToolStripMenuItem
            // 
            CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            CloseToolStripMenuItem.Size = new Size(192, 26);
            CloseToolStripMenuItem.Text = "Выход";
            CloseToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменToolStripMenuItem, повторитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem, удалитьToolStripMenuItem, выделитьToolStripMenuItem });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(74, 24);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменToolStripMenuItem
            // 
            отменToolStripMenuItem.Name = "отменToolStripMenuItem";
            отменToolStripMenuItem.Size = new Size(186, 26);
            отменToolStripMenuItem.Text = "Отменить";
            отменToolStripMenuItem.Click += backChanges_Click;
            // 
            // повторитьToolStripMenuItem
            // 
            повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            повторитьToolStripMenuItem.Size = new Size(186, 26);
            повторитьToolStripMenuItem.Text = "Повторить";
            повторитьToolStripMenuItem.Click += repeat_Click;
            // 
            // вырезатьToolStripMenuItem
            // 
            вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            вырезатьToolStripMenuItem.Size = new Size(186, 26);
            вырезатьToolStripMenuItem.Text = "Вырезать";
            вырезатьToolStripMenuItem.Click += cutText_Click;
            // 
            // копироватьToolStripMenuItem
            // 
            копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            копироватьToolStripMenuItem.Size = new Size(186, 26);
            копироватьToolStripMenuItem.Text = "Копировать";
            копироватьToolStripMenuItem.Click += copyText_Click;
            // 
            // вставитьToolStripMenuItem
            // 
            вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            вставитьToolStripMenuItem.Size = new Size(186, 26);
            вставитьToolStripMenuItem.Text = "Вставить";
            вставитьToolStripMenuItem.Click += putText_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(186, 26);
            удалитьToolStripMenuItem.Text = "Удалить";
            удалитьToolStripMenuItem.Click += Delete_Click;
            // 
            // выделитьToolStripMenuItem
            // 
            выделитьToolStripMenuItem.Name = "выделитьToolStripMenuItem";
            выделитьToolStripMenuItem.Size = new Size(186, 26);
            выделитьToolStripMenuItem.Text = "Выделить все";
            выделитьToolStripMenuItem.Click += selectAll_Click;
            // 
            // текстToolStripMenuItem
            // 
            текстToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Task, Grammar, ClassificationGrammar, AnalyzeMethod, Example, Literature, Code });
            текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            текстToolStripMenuItem.Size = new Size(59, 24);
            текстToolStripMenuItem.Text = "Текст";
            // 
            // Task
            // 
            Task.Name = "Task";
            Task.Size = new Size(288, 26);
            Task.Text = "Постановка задачи";
            Task.Click += Task_Click;
            // 
            // Grammar
            // 
            Grammar.Name = "Grammar";
            Grammar.Size = new Size(288, 26);
            Grammar.Text = "Грамматика";
            Grammar.Click += Grammar_Click;
            // 
            // ClassificationGrammar
            // 
            ClassificationGrammar.Name = "ClassificationGrammar";
            ClassificationGrammar.Size = new Size(288, 26);
            ClassificationGrammar.Text = "Классификация грамматики";
            ClassificationGrammar.Click += ClassificationGrammar_Click;
            // 
            // AnalyzeMethod
            // 
            AnalyzeMethod.Name = "AnalyzeMethod";
            AnalyzeMethod.Size = new Size(288, 26);
            AnalyzeMethod.Text = "Метод анализа";
            AnalyzeMethod.Click += AnalyzeMethod_Click;
            // 
            // Example
            // 
            Example.Name = "Example";
            Example.Size = new Size(288, 26);
            Example.Text = "Тестовый пример";
            Example.Click += Example_Click;
            // 
            // Literature
            // 
            Literature.Name = "Literature";
            Literature.Size = new Size(288, 26);
            Literature.Text = "Список литературы";
            Literature.Click += Literature_Click;
            // 
            // Code
            // 
            Code.Name = "Code";
            Code.Size = new Size(288, 26);
            Code.Text = "Исходный код программы";
            Code.Click += Code_Click;
            // 
            // пускToolStripMenuItem
            // 
            пускToolStripMenuItem.Name = "пускToolStripMenuItem";
            пускToolStripMenuItem.Size = new Size(55, 24);
            пускToolStripMenuItem.Text = "Пуск";
            пускToolStripMenuItem.Click += пускToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вызовСправкиToolStripMenuItem, оПрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // вызовСправкиToolStripMenuItem
            // 
            вызовСправкиToolStripMenuItem.Name = "вызовСправкиToolStripMenuItem";
            вызовСправкиToolStripMenuItem.Size = new Size(197, 26);
            вызовСправкиToolStripMenuItem.Text = "Вызов справки";
            вызовСправкиToolStripMenuItem.Click += info_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(197, 26);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += createdBy_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(40, 40);
            toolStrip1.Items.AddRange(new ToolStripItem[] { createNewFile, openFile, saveChanges, backChanges, repeat, copyText, putText, cutText, start, info, createdBy });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(984, 47);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // createNewFile
            // 
            createNewFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            createNewFile.Image = Properties.Resources.create_file;
            createNewFile.ImageTransparentColor = Color.Magenta;
            createNewFile.Name = "createNewFile";
            createNewFile.Size = new Size(44, 44);
            createNewFile.Text = "Создать";
            createNewFile.Click += createNewFile_Click;
            // 
            // openFile
            // 
            openFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openFile.Image = Properties.Resources.open_file;
            openFile.ImageTransparentColor = Color.Magenta;
            openFile.Name = "openFile";
            openFile.Size = new Size(44, 44);
            openFile.Text = "Открыть";
            openFile.Click += openFile_Click;
            // 
            // saveChanges
            // 
            saveChanges.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveChanges.Image = Properties.Resources.save_file;
            saveChanges.ImageTransparentColor = Color.Magenta;
            saveChanges.Name = "saveChanges";
            saveChanges.Size = new Size(44, 44);
            saveChanges.Text = "Сохранить";
            saveChanges.Click += saveChanges_Click;
            // 
            // backChanges
            // 
            backChanges.DisplayStyle = ToolStripItemDisplayStyle.Image;
            backChanges.Image = Properties.Resources.back_change;
            backChanges.ImageTransparentColor = Color.Magenta;
            backChanges.Name = "backChanges";
            backChanges.Size = new Size(44, 44);
            backChanges.Text = "Отменить";
            backChanges.Click += backChanges_Click;
            // 
            // repeat
            // 
            repeat.DisplayStyle = ToolStripItemDisplayStyle.Image;
            repeat.Image = Properties.Resources._return;
            repeat.ImageTransparentColor = Color.Magenta;
            repeat.Name = "repeat";
            repeat.Size = new Size(44, 44);
            repeat.Text = "Повторить";
            repeat.Click += repeat_Click;
            // 
            // copyText
            // 
            copyText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyText.Image = Properties.Resources.copy_text;
            copyText.ImageTransparentColor = Color.Magenta;
            copyText.Name = "copyText";
            copyText.Size = new Size(44, 44);
            copyText.Text = "Копировать";
            copyText.Click += copyText_Click;
            // 
            // putText
            // 
            putText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            putText.Image = Properties.Resources.put_text;
            putText.ImageTransparentColor = Color.Magenta;
            putText.Name = "putText";
            putText.Size = new Size(44, 44);
            putText.Text = "Вставить";
            putText.Click += putText_Click;
            // 
            // cutText
            // 
            cutText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutText.Image = Properties.Resources.cut_text;
            cutText.ImageTransparentColor = Color.Magenta;
            cutText.Name = "cutText";
            cutText.Size = new Size(44, 44);
            cutText.Text = "Вырезать";
            cutText.Click += cutText_Click;
            // 
            // start
            // 
            start.DisplayStyle = ToolStripItemDisplayStyle.Image;
            start.Image = Properties.Resources.start;
            start.ImageTransparentColor = Color.Magenta;
            start.Name = "start";
            start.Size = new Size(44, 44);
            start.Text = "Пуск";
            start.Click += start_Click;
            // 
            // info
            // 
            info.DisplayStyle = ToolStripItemDisplayStyle.Image;
            info.Image = Properties.Resources.question;
            info.ImageTransparentColor = Color.Magenta;
            info.Name = "info";
            info.Size = new Size(44, 44);
            info.Text = "Вызов справки";
            info.Click += info_Click;
            // 
            // createdBy
            // 
            createdBy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            createdBy.Image = Properties.Resources.info;
            createdBy.ImageTransparentColor = Color.Magenta;
            createdBy.Name = "createdBy";
            createdBy.Size = new Size(44, 44);
            createdBy.Text = "О программе";
            createdBy.Click += createdBy_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 221);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(input);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 188);
            tabPage1.TabIndex = 0;
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // input
            // 
            input.Dock = DockStyle.Fill;
            input.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            input.Location = new Point(3, 3);
            input.Name = "input";
            input.Size = new Size(970, 182);
            input.TabIndex = 1;
            input.Text = "";
            input.TextChanged += richTextBox_TextChanged;
            input.KeyDown += richTextBox_KeyDown;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 75);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl2);
            splitContainer1.Size = new Size(984, 447);
            splitContainer1.SplitterDistance = 221;
            splitContainer1.TabIndex = 13;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(parser1);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(984, 222);
            tabControl2.TabIndex = 1;
            // 
            // parser1
            // 
            parser1.Controls.Add(ParserDataGrid);
            parser1.Location = new Point(4, 29);
            parser1.Name = "parser1";
            parser1.Padding = new Padding(3);
            parser1.Size = new Size(976, 189);
            parser1.TabIndex = 0;
            parser1.Text = "Парсер";
            parser1.UseVisualStyleBackColor = true;
            // 
            // ParserDataGrid
            // 
            ParserDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ParserDataGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn3 });
            ParserDataGrid.Dock = DockStyle.Fill;
            ParserDataGrid.Location = new Point(3, 3);
            ParserDataGrid.Name = "ParserDataGrid";
            ParserDataGrid.RowHeadersWidth = 51;
            ParserDataGrid.Size = new Size(970, 183);
            ParserDataGrid.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.FillWeight = 15F;
            dataGridViewTextBoxColumn1.HeaderText = "№";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.FillWeight = 50F;
            dataGridViewTextBoxColumn5.HeaderText = "местоположение";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.FillWeight = 280.748657F;
            dataGridViewTextBoxColumn3.HeaderText = "сообщение";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Compiler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 522);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Compiler";
            Text = "Компилятор";
            FormClosing += Compiler_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            parser1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ParserDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripMenuItem CloseToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem отменToolStripMenuItem;
        private ToolStripMenuItem повторитьToolStripMenuItem;
        private ToolStripMenuItem вырезатьToolStripMenuItem;
        private ToolStripMenuItem копироватьToolStripMenuItem;
        private ToolStripMenuItem вставитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem выделитьToolStripMenuItem;
        private ToolStripMenuItem текстToolStripMenuItem;
        private ToolStripMenuItem Task;
        private ToolStripMenuItem Grammar;
        private ToolStripMenuItem ClassificationGrammar;
        private ToolStripMenuItem AnalyzeMethod;
        private ToolStripMenuItem Example;
        private ToolStripMenuItem Literature;
        private ToolStripMenuItem Code;
        private ToolStripMenuItem пускToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem вызовСправкиToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton createNewFile;
        private ToolStripButton openFile;
        private ToolStripButton saveChanges;
        private ToolStripButton backChanges;
        private ToolStripButton repeat;
        private ToolStripButton copyText;
        private ToolStripButton cutText;
        private ToolStripButton putText;
        private ToolStripButton start;
        private ToolStripButton info;
        private ToolStripButton createdBy;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox input;
        private SplitContainer splitContainer1;
        private TabControl tabControl2;
        private TabPage parser1;
        private DataGridView ParserDataGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
