
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TxtB_PathName = new System.Windows.Forms.TextBox();
            this.TxtB_SearchName = new System.Windows.Forms.TextBox();
            this.Btn_GetFileName = new System.Windows.Forms.Button();
            this.Btn_SelectFullPath = new System.Windows.Forms.Button();
            this.TxtB_FilesCount = new System.Windows.Forms.TextBox();
            this.Btn_SetExtension = new System.Windows.Forms.Button();
            this.TxtB_ExtensionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtB_SourceName = new System.Windows.Forms.TextBox();
            this.TxtB_ReplaceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Replace = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ComB_SearchMode = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lab_SubtractStar = new System.Windows.Forms.Label();
            this.Lab_AddStar = new System.Windows.Forms.Label();
            this.Btn_DeletePartName = new System.Windows.Forms.Button();
            this.TxtB_DeletePartName = new System.Windows.Forms.TextBox();
            this.Lab_ReplaceName = new System.Windows.Forms.Label();
            this.NumericUpD_SerialNumber = new System.Windows.Forms.NumericUpDown();
            this.TxtB_RepalceAddSuffix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckB_EnableSerialNumber = new System.Windows.Forms.CheckBox();
            this.CheckB_EnableCreatFile = new System.Windows.Forms.CheckBox();
            this.ComB_Order = new System.Windows.Forms.ComboBox();
            this.Lba_ToSearch = new System.Windows.Forms.Label();
            this.Lab_ToSource = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpD_SerialNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 168);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1183, 612);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // TxtB_PathName
            // 
            this.TxtB_PathName.Location = new System.Drawing.Point(82, 15);
            this.TxtB_PathName.Name = "TxtB_PathName";
            this.TxtB_PathName.Size = new System.Drawing.Size(1073, 20);
            this.TxtB_PathName.TabIndex = 1;
            // 
            // TxtB_SearchName
            // 
            this.TxtB_SearchName.Location = new System.Drawing.Point(70, 39);
            this.TxtB_SearchName.Name = "TxtB_SearchName";
            this.TxtB_SearchName.Size = new System.Drawing.Size(406, 20);
            this.TxtB_SearchName.TabIndex = 1;
            this.TxtB_SearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtB_Format_KeyDown);
            // 
            // Btn_GetFileName
            // 
            this.Btn_GetFileName.Location = new System.Drawing.Point(98, 120);
            this.Btn_GetFileName.Name = "Btn_GetFileName";
            this.Btn_GetFileName.Size = new System.Drawing.Size(79, 23);
            this.Btn_GetFileName.TabIndex = 2;
            this.Btn_GetFileName.Text = "GetFileName";
            this.Btn_GetFileName.UseVisualStyleBackColor = true;
            this.Btn_GetFileName.Click += new System.EventHandler(this.Btn_GetFileName_Click);
            // 
            // Btn_SelectFullPath
            // 
            this.Btn_SelectFullPath.Location = new System.Drawing.Point(1149, 7);
            this.Btn_SelectFullPath.Name = "Btn_SelectFullPath";
            this.Btn_SelectFullPath.Size = new System.Drawing.Size(31, 23);
            this.Btn_SelectFullPath.TabIndex = 2;
            this.Btn_SelectFullPath.Text = "...";
            this.Btn_SelectFullPath.UseVisualStyleBackColor = true;
            this.Btn_SelectFullPath.Click += new System.EventHandler(this.Btn_SelectFullPath_Click);
            // 
            // TxtB_FilesCount
            // 
            this.TxtB_FilesCount.Location = new System.Drawing.Point(1115, 127);
            this.TxtB_FilesCount.Name = "TxtB_FilesCount";
            this.TxtB_FilesCount.Size = new System.Drawing.Size(65, 20);
            this.TxtB_FilesCount.TabIndex = 1;
            // 
            // Btn_SetExtension
            // 
            this.Btn_SetExtension.Location = new System.Drawing.Point(471, 124);
            this.Btn_SetExtension.Name = "Btn_SetExtension";
            this.Btn_SetExtension.Size = new System.Drawing.Size(79, 23);
            this.Btn_SetExtension.TabIndex = 2;
            this.Btn_SetExtension.Text = "SetExtension";
            this.Btn_SetExtension.UseVisualStyleBackColor = true;
            this.Btn_SetExtension.Click += new System.EventHandler(this.Btn_SetExtension_Click);
            // 
            // TxtB_ExtensionName
            // 
            this.TxtB_ExtensionName.Location = new System.Drawing.Point(497, 98);
            this.TxtB_ExtensionName.Name = "TxtB_ExtensionName";
            this.TxtB_ExtensionName.Size = new System.Drawing.Size(53, 20);
            this.TxtB_ExtensionName.TabIndex = 1;
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
            this.label2.Location = new System.Drawing.Point(1054, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件数量";
            // 
            // TxtB_SourceName
            // 
            this.TxtB_SourceName.Location = new System.Drawing.Point(608, 39);
            this.TxtB_SourceName.Name = "TxtB_SourceName";
            this.TxtB_SourceName.Size = new System.Drawing.Size(535, 20);
            this.TxtB_SourceName.TabIndex = 1;
            this.TxtB_SourceName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TxtB_SourceName_MouseMove);
            // 
            // TxtB_ReplaceName
            // 
            this.TxtB_ReplaceName.Location = new System.Drawing.Point(608, 65);
            this.TxtB_ReplaceName.Name = "TxtB_ReplaceName";
            this.TxtB_ReplaceName.Size = new System.Drawing.Size(535, 20);
            this.TxtB_ReplaceName.TabIndex = 1;
            this.TxtB_ReplaceName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TxtB_ReplaceName_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "原名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(559, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "替换名";
            // 
            // Btn_Replace
            // 
            this.Btn_Replace.Location = new System.Drawing.Point(229, 120);
            this.Btn_Replace.Name = "Btn_Replace";
            this.Btn_Replace.Size = new System.Drawing.Size(79, 23);
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
            this.label7.Location = new System.Drawing.Point(9, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "搜索模式";
            // 
            // ComB_SearchMode
            // 
            this.ComB_SearchMode.FormattingEnabled = true;
            this.ComB_SearchMode.Items.AddRange(new object[] {
            "TopDirectoryOnly",
            "AllDirectories"});
            this.ComB_SearchMode.Location = new System.Drawing.Point(70, 68);
            this.ComB_SearchMode.Name = "ComB_SearchMode";
            this.ComB_SearchMode.Size = new System.Drawing.Size(109, 21);
            this.ComB_SearchMode.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lab_SubtractStar);
            this.panel1.Controls.Add(this.Lab_AddStar);
            this.panel1.Controls.Add(this.Btn_DeletePartName);
            this.panel1.Controls.Add(this.TxtB_DeletePartName);
            this.panel1.Controls.Add(this.Lab_ReplaceName);
            this.panel1.Controls.Add(this.NumericUpD_SerialNumber);
            this.panel1.Controls.Add(this.TxtB_SearchName);
            this.panel1.Controls.Add(this.TxtB_RepalceAddSuffix);
            this.panel1.Controls.Add(this.ComB_SearchMode);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CheckB_EnableSerialNumber);
            this.panel1.Controls.Add(this.CheckB_EnableCreatFile);
            this.panel1.Controls.Add(this.ComB_Order);
            this.panel1.Controls.Add(this.TxtB_ReplaceName);
            this.panel1.Controls.Add(this.Lba_ToSearch);
            this.panel1.Controls.Add(this.TxtB_SourceName);
            this.panel1.Controls.Add(this.Lab_ToSource);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtB_FilesCount);
            this.panel1.Controls.Add(this.Btn_Replace);
            this.panel1.Controls.Add(this.Btn_GetFileName);
            this.panel1.Controls.Add(this.Btn_SelectFullPath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Btn_SetExtension);
            this.panel1.Controls.Add(this.TxtB_ExtensionName);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 152);
            this.panel1.TabIndex = 5;
            // 
            // Lab_SubtractStar
            // 
            this.Lab_SubtractStar.AutoSize = true;
            this.Lab_SubtractStar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lab_SubtractStar.Location = new System.Drawing.Point(485, 69);
            this.Lab_SubtractStar.Name = "Lab_SubtractStar";
            this.Lab_SubtractStar.Size = new System.Drawing.Size(36, 15);
            this.Lab_SubtractStar.TabIndex = 17;
            this.Lab_SubtractStar.Text = "Rep-*";
            this.Lab_SubtractStar.Click += new System.EventHandler(this.Lab_SubtractStar_Click);
            // 
            // Lab_AddStar
            // 
            this.Lab_AddStar.AutoSize = true;
            this.Lab_AddStar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lab_AddStar.Location = new System.Drawing.Point(439, 69);
            this.Lab_AddStar.Name = "Lab_AddStar";
            this.Lab_AddStar.Size = new System.Drawing.Size(39, 15);
            this.Lab_AddStar.TabIndex = 17;
            this.Lab_AddStar.Text = "Rep+*";
            this.Lab_AddStar.Click += new System.EventHandler(this.Lab_AddStar_Click);
            // 
            // Btn_DeletePartName
            // 
            this.Btn_DeletePartName.Location = new System.Drawing.Point(320, 120);
            this.Btn_DeletePartName.Name = "Btn_DeletePartName";
            this.Btn_DeletePartName.Size = new System.Drawing.Size(79, 23);
            this.Btn_DeletePartName.TabIndex = 16;
            this.Btn_DeletePartName.Text = "DelPart";
            this.Btn_DeletePartName.UseVisualStyleBackColor = true;
            this.Btn_DeletePartName.Click += new System.EventHandler(this.Btn_DeletePartName_Click);
            // 
            // TxtB_DeletePartName
            // 
            this.TxtB_DeletePartName.Location = new System.Drawing.Point(608, 91);
            this.TxtB_DeletePartName.Name = "TxtB_DeletePartName";
            this.TxtB_DeletePartName.Size = new System.Drawing.Size(535, 20);
            this.TxtB_DeletePartName.TabIndex = 15;
            this.TxtB_DeletePartName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TxtB_DeletePartName_MouseMove);
            // 
            // Lab_ReplaceName
            // 
            this.Lab_ReplaceName.AutoSize = true;
            this.Lab_ReplaceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lab_ReplaceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab_ReplaceName.Location = new System.Drawing.Point(522, 67);
            this.Lab_ReplaceName.Name = "Lab_ReplaceName";
            this.Lab_ReplaceName.Size = new System.Drawing.Size(39, 15);
            this.Lab_ReplaceName.TabIndex = 13;
            this.Lab_ReplaceName.Text = "-------->";
            this.Lab_ReplaceName.Click += new System.EventHandler(this.Lab_ReplaceName_Click);
            // 
            // NumericUpD_SerialNumber
            // 
            this.NumericUpD_SerialNumber.Location = new System.Drawing.Point(229, 70);
            this.NumericUpD_SerialNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpD_SerialNumber.Name = "NumericUpD_SerialNumber";
            this.NumericUpD_SerialNumber.Size = new System.Drawing.Size(79, 20);
            this.NumericUpD_SerialNumber.TabIndex = 12;
            this.NumericUpD_SerialNumber.Tag = "0";
            // 
            // TxtB_RepalceAddSuffix
            // 
            this.TxtB_RepalceAddSuffix.Location = new System.Drawing.Point(229, 93);
            this.TxtB_RepalceAddSuffix.Name = "TxtB_RepalceAddSuffix";
            this.TxtB_RepalceAddSuffix.Size = new System.Drawing.Size(79, 20);
            this.TxtB_RepalceAddSuffix.TabIndex = 8;
            this.TxtB_RepalceAddSuffix.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TxtB_RepalceAddSuffix_MouseMove);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "SNEN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(317, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "导出";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(559, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "删除名";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Suffix";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "SN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "扩展名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "搜索排序";
            // 
            // CheckB_EnableSerialNumber
            // 
            this.CheckB_EnableSerialNumber.AutoSize = true;
            this.CheckB_EnableSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckB_EnableSerialNumber.Location = new System.Drawing.Point(354, 74);
            this.CheckB_EnableSerialNumber.Name = "CheckB_EnableSerialNumber";
            this.CheckB_EnableSerialNumber.Size = new System.Drawing.Size(74, 17);
            this.CheckB_EnableSerialNumber.TabIndex = 7;
            this.CheckB_EnableSerialNumber.Text = "EnableSN";
            this.CheckB_EnableSerialNumber.UseVisualStyleBackColor = true;
            this.CheckB_EnableSerialNumber.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckB_EnableSerialNumber_MouseMove);
            // 
            // CheckB_EnableCreatFile
            // 
            this.CheckB_EnableCreatFile.AutoSize = true;
            this.CheckB_EnableCreatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckB_EnableCreatFile.Location = new System.Drawing.Point(354, 96);
            this.CheckB_EnableCreatFile.Name = "CheckB_EnableCreatFile";
            this.CheckB_EnableCreatFile.Size = new System.Drawing.Size(70, 17);
            this.CheckB_EnableCreatFile.TabIndex = 7;
            this.CheckB_EnableCreatFile.Text = "Creat File";
            this.CheckB_EnableCreatFile.UseVisualStyleBackColor = true;
            // 
            // ComB_Order
            // 
            this.ComB_Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComB_Order.FormattingEnabled = true;
            this.ComB_Order.Items.AddRange(new object[] {
            "Name_Order",
            "Name_Reverse",
            "CreationTime_Order",
            "CreationTime_Reverse",
            "Modify_Order",
            "Modify_Reverse"});
            this.ComB_Order.Location = new System.Drawing.Point(68, 92);
            this.ComB_Order.Name = "ComB_Order";
            this.ComB_Order.Size = new System.Drawing.Size(109, 21);
            this.ComB_Order.TabIndex = 6;
            this.ComB_Order.TabStop = false;
            this.ComB_Order.Text = "Name_Order";
            this.ComB_Order.SelectedIndexChanged += new System.EventHandler(this.ComB_Order_SelectedIndexChanged);
            // 
            // Lba_ToSearch
            // 
            this.Lba_ToSearch.AutoSize = true;
            this.Lba_ToSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lba_ToSearch.Location = new System.Drawing.Point(482, 42);
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
            this.Lab_ToSource.Location = new System.Drawing.Point(522, 42);
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
            this.panel2.Location = new System.Drawing.Point(12, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1183, 631);
            this.panel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 793);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtB_PathName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpD_SerialNumber)).EndInit();
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
        private System.Windows.Forms.Button Btn_SetExtension;
        private System.Windows.Forms.TextBox TxtB_ExtensionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ComboBox ComB_Order;
        private System.Windows.Forms.CheckBox CheckB_EnableCreatFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtB_RepalceAddSuffix;
        private System.Windows.Forms.CheckBox CheckB_EnableSerialNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown NumericUpD_SerialNumber;
        private System.Windows.Forms.Label Lab_ReplaceName;
        private System.Windows.Forms.TextBox TxtB_DeletePartName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Btn_DeletePartName;
        private System.Windows.Forms.Label Lab_SubtractStar;
        private System.Windows.Forms.Label Lab_AddStar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

