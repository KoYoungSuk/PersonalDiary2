﻿
namespace PersonalDiary2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendArrangementDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendArrangementAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sFTPServerSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homePageHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalMemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naverBlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutPersonalDiaryAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(17, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show Detail of Selected Diary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(18, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 60);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete Selected Diary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(18, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 60);
            this.button3.TabIndex = 3;
            this.button3.Text = "Write Diary";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(18, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Engravers MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "MyDiary";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "STATUS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "SELECTED DIARY TITLE:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "This is not Copyrighted.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(201, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "VER 2.8 2023-05-27";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(19, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 60);
            this.button5.TabIndex = 13;
            this.button5.Text = "RELOAD";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.dataBaseDToolStripMenuItem,
            this.aboutAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileFToolStripMenuItem.Text = "File(F)";
            // 
            // dummyToolStripMenuItem
            // 
            this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
            this.dummyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.dummyToolStripMenuItem.Text = "Dummy";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // exitXToolStripMenuItem
            // 
            this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            this.exitXToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitXToolStripMenuItem.Text = "Exit(X)";
            this.exitXToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
            // 
            // dataBaseDToolStripMenuItem
            // 
            this.dataBaseDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descendArrangementDToolStripMenuItem,
            this.ascendArrangementAToolStripMenuItem});
            this.dataBaseDToolStripMenuItem.Name = "dataBaseDToolStripMenuItem";
            this.dataBaseDToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.dataBaseDToolStripMenuItem.Text = "DataBase(D)";
            // 
            // descendArrangementDToolStripMenuItem
            // 
            this.descendArrangementDToolStripMenuItem.Name = "descendArrangementDToolStripMenuItem";
            this.descendArrangementDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.descendArrangementDToolStripMenuItem.Text = "Descend Arrangement(D)";
            this.descendArrangementDToolStripMenuItem.Click += new System.EventHandler(this.descendArrangementDToolStripMenuItem_Click);
            // 
            // ascendArrangementAToolStripMenuItem
            // 
            this.ascendArrangementAToolStripMenuItem.Name = "ascendArrangementAToolStripMenuItem";
            this.ascendArrangementAToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.ascendArrangementAToolStripMenuItem.Text = "Ascend Arrangement(A)";
            this.ascendArrangementAToolStripMenuItem.Click += new System.EventHandler(this.ascendArrangementAToolStripMenuItem_Click);
            // 
            // aboutAToolStripMenuItem
            // 
            this.aboutAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sFTPServerSettingToolStripMenuItem,
            this.homePageHToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutPersonalDiaryAToolStripMenuItem});
            this.aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            this.aboutAToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutAToolStripMenuItem.Text = "Help(H)";
            this.aboutAToolStripMenuItem.Click += new System.EventHandler(this.aboutAToolStripMenuItem_Click);
            // 
            // sFTPServerSettingToolStripMenuItem
            // 
            this.sFTPServerSettingToolStripMenuItem.Name = "sFTPServerSettingToolStripMenuItem";
            this.sFTPServerSettingToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.sFTPServerSettingToolStripMenuItem.Text = "SFTP Server Setting";
            this.sFTPServerSettingToolStripMenuItem.Click += new System.EventHandler(this.sFTPServerSettingToolStripMenuItem_Click);
            // 
            // homePageHToolStripMenuItem
            // 
            this.homePageHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalMemoToolStripMenuItem,
            this.naverBlogToolStripMenuItem});
            this.homePageHToolStripMenuItem.Name = "homePageHToolStripMenuItem";
            this.homePageHToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.homePageHToolStripMenuItem.Text = "Home Page(H)";
            // 
            // personalMemoToolStripMenuItem
            // 
            this.personalMemoToolStripMenuItem.Name = "personalMemoToolStripMenuItem";
            this.personalMemoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.personalMemoToolStripMenuItem.Text = "PersonalMemo";
            this.personalMemoToolStripMenuItem.Click += new System.EventHandler(this.personalMemoToolStripMenuItem_Click);
            // 
            // naverBlogToolStripMenuItem
            // 
            this.naverBlogToolStripMenuItem.Name = "naverBlogToolStripMenuItem";
            this.naverBlogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.naverBlogToolStripMenuItem.Text = "Naver Blog";
            this.naverBlogToolStripMenuItem.Click += new System.EventHandler(this.naverBlogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 6);
            // 
            // aboutPersonalDiaryAToolStripMenuItem
            // 
            this.aboutPersonalDiaryAToolStripMenuItem.Name = "aboutPersonalDiaryAToolStripMenuItem";
            this.aboutPersonalDiaryAToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.aboutPersonalDiaryAToolStripMenuItem.Text = "About PersonalDiary(A)";
            this.aboutPersonalDiaryAToolStripMenuItem.Click += new System.EventHandler(this.aboutPersonalDiaryAToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "DIARY NUMBER:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Your OS Version:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 350);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Click);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(583, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 367);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 75);
            this.panel2.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(151, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 23);
            this.textBox1.TabIndex = 16;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 484);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(783, 43);
            this.panel3.TabIndex = 20;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 529);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "MyDiary 2.8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dummyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPersonalDiaryAToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem dataBaseDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendArrangementDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascendArrangementAToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem sFTPServerSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homePageHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalMemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naverBlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

