namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поГодуИзданияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поДиапозонуСтраницToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поГодуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поФамилииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поЧастиИмениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название книги:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.textBox2.Validated += new System.EventHandler(this.textBox2_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "УДК:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(193, 175);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            this.textBox3.Validated += new System.EventHandler(this.textBox3_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Год издания:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Автор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Издательство";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(38, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "CD";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(118, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 21);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "DVD";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(71, 230);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(219, 56);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(226, 289);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(36, 22);
            this.textBox4.TabIndex = 11;
            this.textBox4.Validating += new System.ComponentModel.CancelEventHandler(this.textBox4_Validating);
            this.textBox4.Validated += new System.EventHandler(this.textBox4_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Кол.во страниц:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 483);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(87, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доп. комплектация";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Дата поступления";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(324, 213);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(292, 292);
            this.textBox5.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 41);
            this.button3.TabIndex = 17;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(324, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 18;
            this.button4.Text = "из XML";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(405, 154);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 38);
            this.button5.TabIndex = 19;
            this.button5.Text = "в XML";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(705, 28);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискПоToolStripMenuItem,
            this.поГодуИзданияToolStripMenuItem,
            this.поДиапозонуСтраницToolStripMenuItem,
            this.поЧастиИмениToolStripMenuItem});
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // поискПоToolStripMenuItem
            // 
            this.поискПоToolStripMenuItem.Name = "поискПоToolStripMenuItem";
            this.поискПоToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.поискПоToolStripMenuItem.Text = "по издательству";
            this.поискПоToolStripMenuItem.Click += new System.EventHandler(this.поискПоToolStripMenuItem_Click);
            // 
            // поГодуИзданияToolStripMenuItem
            // 
            this.поГодуИзданияToolStripMenuItem.Name = "поГодуИзданияToolStripMenuItem";
            this.поГодуИзданияToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.поГодуИзданияToolStripMenuItem.Text = "по дате поступления";
            this.поГодуИзданияToolStripMenuItem.Click += new System.EventHandler(this.поГодуИзданияToolStripMenuItem_Click);
            // 
            // поДиапозонуСтраницToolStripMenuItem
            // 
            this.поДиапозонуСтраницToolStripMenuItem.Name = "поДиапозонуСтраницToolStripMenuItem";
            this.поДиапозонуСтраницToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.поДиапозонуСтраницToolStripMenuItem.Text = "по диап. страниц";
            this.поДиапозонуСтраницToolStripMenuItem.Click += new System.EventHandler(this.поДиапозонуСтраницToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поГодуToolStripMenuItem,
            this.поФамилииToolStripMenuItem});
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // поГодуToolStripMenuItem
            // 
            this.поГодуToolStripMenuItem.Name = "поГодуToolStripMenuItem";
            this.поГодуToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.поГодуToolStripMenuItem.Text = "по автору";
            this.поГодуToolStripMenuItem.Click += new System.EventHandler(this.поГодуToolStripMenuItem_Click);
            // 
            // поФамилииToolStripMenuItem
            // 
            this.поФамилииToolStripMenuItem.Name = "поФамилииToolStripMenuItem";
            this.поФамилииToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.поФамилииToolStripMenuItem.Text = "по году издания";
            this.поФамилииToolStripMenuItem.Click += new System.EventHandler(this.поФамилииToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // поЧастиИмениToolStripMenuItem
            // 
            this.поЧастиИмениToolStripMenuItem.Name = "поЧастиИмениToolStripMenuItem";
            this.поЧастиИмениToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.поЧастиИмениToolStripMenuItem.Text = "по части имени";
            this.поЧастиИмениToolStripMenuItem.Click += new System.EventHandler(this.поЧастиИмениToolStripMenuItem_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(529, 144);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 48);
            this.button6.TabIndex = 21;
            this.button6.Text = "Чистка XML";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 531);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Библиотека";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискПоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поГодуИзданияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поДиапозонуСтраницToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поГодуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поФамилииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поЧастиИмениToolStripMenuItem;
        private System.Windows.Forms.Button button6;
    }
}

