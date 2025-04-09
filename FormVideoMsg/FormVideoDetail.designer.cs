namespace GetVideoDetails
{
    partial class FormVideoDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textB_VideoPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textB_OutputFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_SelectVideoPath = new System.Windows.Forms.Button();
            this.btn_SelectOutputPath = new System.Windows.Forms.Button();
            this.btn_CreatFile = new System.Windows.Forms.Button();
            this.richTB_Log = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textB_VideoPath
            // 
            this.textB_VideoPath.Location = new System.Drawing.Point(81, 9);
            this.textB_VideoPath.Name = "textB_VideoPath";
            this.textB_VideoPath.Size = new System.Drawing.Size(573, 20);
            this.textB_VideoPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "VideoPath";
            // 
            // textB_OutputFilePath
            // 
            this.textB_OutputFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textB_OutputFilePath.Location = new System.Drawing.Point(81, 35);
            this.textB_OutputFilePath.Name = "textB_OutputFilePath";
            this.textB_OutputFilePath.Size = new System.Drawing.Size(573, 20);
            this.textB_OutputFilePath.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "OutputFilePath";
            // 
            // btn_SelectVideoPath
            // 
            this.btn_SelectVideoPath.Location = new System.Drawing.Point(659, 9);
            this.btn_SelectVideoPath.Name = "btn_SelectVideoPath";
            this.btn_SelectVideoPath.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectVideoPath.TabIndex = 3;
            this.btn_SelectVideoPath.Text = "VideoPath";
            this.btn_SelectVideoPath.UseVisualStyleBackColor = true;
            this.btn_SelectVideoPath.Click += new System.EventHandler(this.btn_SelectVideoPath_Click);
            // 
            // btn_SelectOutputPath
            // 
            this.btn_SelectOutputPath.Location = new System.Drawing.Point(659, 33);
            this.btn_SelectOutputPath.Name = "btn_SelectOutputPath";
            this.btn_SelectOutputPath.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectOutputPath.TabIndex = 3;
            this.btn_SelectOutputPath.Text = "OutputPath";
            this.btn_SelectOutputPath.UseVisualStyleBackColor = true;
            this.btn_SelectOutputPath.Click += new System.EventHandler(this.btn_SelectOutputPath_Click);
            // 
            // btn_CreatFile
            // 
            this.btn_CreatFile.Location = new System.Drawing.Point(659, 62);
            this.btn_CreatFile.Name = "btn_CreatFile";
            this.btn_CreatFile.Size = new System.Drawing.Size(75, 23);
            this.btn_CreatFile.TabIndex = 4;
            this.btn_CreatFile.Text = "CreatFile";
            this.btn_CreatFile.UseVisualStyleBackColor = true;
            this.btn_CreatFile.Click += new System.EventHandler(this.btn_CreatFile_Click);
            // 
            // richTB_Log
            // 
            this.richTB_Log.Location = new System.Drawing.Point(2, 91);
            this.richTB_Log.Name = "richTB_Log";
            this.richTB_Log.Size = new System.Drawing.Size(732, 195);
            this.richTB_Log.TabIndex = 5;
            this.richTB_Log.Text = "";
            this.richTB_Log.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 291);
            this.Controls.Add(this.richTB_Log);
            this.Controls.Add(this.btn_CreatFile);
            this.Controls.Add(this.btn_SelectOutputPath);
            this.Controls.Add(this.btn_SelectVideoPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textB_OutputFilePath);
            this.Controls.Add(this.textB_VideoPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textB_VideoPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textB_OutputFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_SelectVideoPath;
        private System.Windows.Forms.Button btn_SelectOutputPath;
        private System.Windows.Forms.Button btn_CreatFile;
        private System.Windows.Forms.RichTextBox richTB_Log;
        private System.Windows.Forms.Label label3;
    }
}

