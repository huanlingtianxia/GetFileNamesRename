
namespace  GetFileNamesRename
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TxtB_PathName = new System.Windows.Forms.TextBox();
            this.TxtB_SearchName = new System.Windows.Forms.TextBox();
            this.Btn_GetFileName = new System.Windows.Forms.Button();
            this.Btn_SelectFullPath = new System.Windows.Forms.Button();
            this.TxtB_FilesCount = new System.Windows.Forms.TextBox();
            this.Btn_SetSuffix = new System.Windows.Forms.Button();
            this.TxtB_SuffixName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtB_SourceName = new System.Windows.Forms.TextBox();
            this.TxtB_ReplaceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Replace = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ComB_SearchMode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lba_ToSearch = new System.Windows.Forms.Label();
            this.Lab_ToSource = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 344);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // TxtB_PathName
            // 
            this.TxtB_PathName.Location = new System.Drawing.Point(82, 15);
            this.TxtB_PathName.Name = "TxtB_PathName";
            this.TxtB_PathName.Size = new System.Drawing.Size(560, 20);
            this.TxtB_PathName.TabIndex = 1;
            // 
            // TxtB_SearchName
            // 
            this.TxtB_SearchName.Location = new System.Drawing.Point(82, 41);
            this.TxtB_SearchName.Name = "TxtB_SearchName";
            this.TxtB_SearchName.Size = new System.Drawing.Size(244, 20);
            this.TxtB_SearchName.TabIndex = 1;
            this.TxtB_SearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtB_Format_KeyDown);
            // 
            // Btn_GetFileName
            // 
            this.Btn_GetFileName.Location = new System.Drawing.Point(592, 43);
            this.Btn_GetFileName.Name = "Btn_GetFileName";
            this.Btn_GetFileName.Size = new System.Drawing.Size(87, 23);
            this.Btn_GetFileName.TabIndex = 2;
            this.Btn_GetFileName.Text = "GetFileName";
            this.Btn_GetFileName.UseVisualStyleBackColor = true;
            this.Btn_GetFileName.Click += new System.EventHandler(this.Btn_GetFileName_Click);
            // 
            // Btn_SelectFullPath
            // 
            this.Btn_SelectFullPath.Location = new System.Drawing.Point(648, 15);
            this.Btn_SelectFullPath.Name = "Btn_SelectFullPath";
            this.Btn_SelectFullPath.Size = new System.Drawing.Size(31, 23);
            this.Btn_SelectFullPath.TabIndex = 2;
            this.Btn_SelectFullPath.Text = "...";
            this.Btn_SelectFullPath.UseVisualStyleBackColor = true;
            this.Btn_SelectFullPath.Click += new System.EventHandler(this.bBtn_SelectFullPath_Click);
            // 
            // TxtB_FilesCount
            // 
            this.TxtB_FilesCount.Location = new System.Drawing.Point(249, 65);
            this.TxtB_FilesCount.Name = "TxtB_FilesCount";
            this.TxtB_FilesCount.Size = new System.Drawing.Size(65, 20);
            this.TxtB_FilesCount.TabIndex = 1;
            // 
            // Btn_SetSuffix
            // 
            this.Btn_SetSuffix.Location = new System.Drawing.Point(711, 67);
            this.Btn_SetSuffix.Name = "Btn_SetSuffix";
            this.Btn_SetSuffix.Size = new System.Drawing.Size(77, 23);
            this.Btn_SetSuffix.TabIndex = 2;
            this.Btn_SetSuffix.Text = "SetSuffix";
            this.Btn_SetSuffix.UseVisualStyleBackColor = true;
            this.Btn_SetSuffix.Click += new System.EventHandler(this.Btn_SetSuffix_Click);
            // 
            // TxtB_SuffixName
            // 
            this.TxtB_SuffixName.Location = new System.Drawing.Point(711, 41);
            this.TxtB_SuffixName.Name = "TxtB_SuffixName";
            this.TxtB_SuffixName.Size = new System.Drawing.Size(77, 20);
            this.TxtB_SuffixName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "搜索文件名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SuffixName";
            // 
            // TxtB_SourceName
            // 
            this.TxtB_SourceName.Location = new System.Drawing.Point(393, 44);
            this.TxtB_SourceName.Name = "TxtB_SourceName";
            this.TxtB_SourceName.Size = new System.Drawing.Size(193, 20);
            this.TxtB_SourceName.TabIndex = 1;
            // 
            // TxtB_ReplaceName
            // 
            this.TxtB_ReplaceName.Location = new System.Drawing.Point(393, 68);
            this.TxtB_ReplaceName.Name = "TxtB_ReplaceName";
            this.TxtB_ReplaceName.Size = new System.Drawing.Size(193, 20);
            this.TxtB_ReplaceName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "原名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "替换名";
            // 
            // Btn_Replace
            // 
            this.Btn_Replace.Location = new System.Drawing.Point(592, 68);
            this.Btn_Replace.Name = "Btn_Replace";
            this.Btn_Replace.Size = new System.Drawing.Size(87, 23);
            this.Btn_Replace.TabIndex = 2;
            this.Btn_Replace.Text = "Repalce";
            this.Btn_Replace.UseVisualStyleBackColor = true;
            this.Btn_Replace.Click += new System.EventHandler(this.Btn_Replace_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "路径";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "搜索模式";
            // 
            // ComB_SearchMode
            // 
            this.ComB_SearchMode.FormattingEnabled = true;
            this.ComB_SearchMode.Items.AddRange(new object[] {
            "仅本路径",
            "包含子路径"});
            this.ComB_SearchMode.Location = new System.Drawing.Point(82, 67);
            this.ComB_SearchMode.Name = "ComB_SearchMode";
            this.ComB_SearchMode.Size = new System.Drawing.Size(109, 21);
            this.ComB_SearchMode.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lba_ToSearch);
            this.panel1.Controls.Add(this.Lab_ToSource);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtB_FilesCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 88);
            this.panel1.TabIndex = 5;
            // 
            // Lba_ToSearch
            // 
            this.Lba_ToSearch.AutoSize = true;
            this.Lba_ToSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lba_ToSearch.Location = new System.Drawing.Point(313, 31);
            this.Lba_ToSearch.Name = "Lba_ToSearch";
            this.Lba_ToSearch.Size = new System.Drawing.Size(36, 15);
            this.Lba_ToSearch.TabIndex = 3;
            this.Lba_ToSearch.Text = "<-------";
            this.Lba_ToSearch.Click += new System.EventHandler(this.Lba_ToSearch_Click);
            // 
            // Lab_ToSource
            // 
            this.Lab_ToSource.AutoSize = true;
            this.Lab_ToSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lab_ToSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_ToSource.Location = new System.Drawing.Point(313, 49);
            this.Lab_ToSource.Name = "Lab_ToSource";
            this.Lab_ToSource.Size = new System.Drawing.Size(39, 15);
            this.Lab_ToSource.TabIndex = 3;
            this.Lab_ToSource.Text = "-------->";
            this.Lab_ToSource.Click += new System.EventHandler(this.Lab_ToSource_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(12, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 359);
            this.panel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.ComB_SearchMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_SelectFullPath);
            this.Controls.Add(this.Btn_SetSuffix);
            this.Controls.Add(this.Btn_Replace);
            this.Controls.Add(this.Btn_GetFileName);
            this.Controls.Add(this.TxtB_SuffixName);
            this.Controls.Add(this.TxtB_ReplaceName);
            this.Controls.Add(this.TxtB_SourceName);
            this.Controls.Add(this.TxtB_SearchName);
            this.Controls.Add(this.TxtB_PathName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TxtB_PathName;
        private System.Windows.Forms.TextBox TxtB_SearchName;
        private System.Windows.Forms.Button Btn_GetFileName;
        private System.Windows.Forms.Button Btn_SelectFullPath;
        private System.Windows.Forms.TextBox TxtB_FilesCount;
        private System.Windows.Forms.Button Btn_SetSuffix;
        private System.Windows.Forms.TextBox TxtB_SuffixName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtB_SourceName;
        private System.Windows.Forms.TextBox TxtB_ReplaceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Replace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ComB_SearchMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lba_ToSearch;
        private System.Windows.Forms.Label Lab_ToSource;
    }
}

