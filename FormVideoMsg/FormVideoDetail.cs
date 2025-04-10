using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syntronic.IniReader;


namespace GetVideoDetails
{
    public partial class FormVideoDetail : Form
    {
        public FormVideoDetail()
        {
            InitializeComponent();
            Init_Component();
        }
        //handle init component
        private void Init_Component()
        {
            //assigning control ref to Property
            _tB_VideoPath = textB_VideoPath;
            _tB_OutputFilePath = textB_OutputFilePath;

            //init control value
            GetFiles.IniFiles();
            GetFiles.IniRead_Data();
            _tB_VideoPath.Text = GetFiles.Ini_VideoParam.PathSource;
            _tB_OutputFilePath.Text = GetFiles.Ini_VideoParam.PathOut;
        }
        //private nember
        private GetFilesMessage _getFiles;
        
        //Property
        internal GetFilesMessage GetFiles
        {
            get
            {
                return _getFiles == null ? _getFiles = new GetFilesMessage() : _getFiles;
            }
            set
            {
                _getFiles = value;
            }
        }
        private TextBox _tB_VideoPath { get; set; }
        private TextBox _tB_OutputFilePath { get; set; }

        // button
        private void btn_SelectVideoPath_Click(object sender, EventArgs e)
        {
            textB_VideoPath.Text = SelectPath();
        }
        private void btn_SelectOutputPath_Click(object sender, EventArgs e)
        {
            textB_OutputFilePath.Text = SelectPath();
        }
        private async void btn_CreatFile_Click(object sender, EventArgs e)
        {
            //_traverseClassAttributes.TestTraverseObject();
            richTB_Log.Text = "";
            string msg = string.Empty;
            await Task.Run(() => 
            {
                GetFiles.GetFilesMsg(_tB_VideoPath.Text, _tB_OutputFilePath.Text, ref msg);
            });
            
            //write ini
            GetFiles.Ini_VideoParam.PathSource = _tB_VideoPath.Text;
            GetFiles.Ini_VideoParam.PathOut = _tB_OutputFilePath.Text;
            GetFiles.IniWrite_Data(GetFiles.Ini_VideoParam);
            richTB_Log.Text = msg;
        }

        //function
        private string SelectPath()
        {
            // 创建一个 FolderBrowserDialog 实例
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // 设置初始路径（可选）
            folderBrowserDialog.SelectedPath = @"E:\labview\《Labview从入门到精通》视频教程\";

            // 显示文件夹选择对话框
            DialogResult result = folderBrowserDialog.ShowDialog();

            // 如果用户选择了一个文件夹
            if (result == DialogResult.OK)
            {
                // 获取用户选择的文件夹路径
                string folderPath = folderBrowserDialog.SelectedPath;

                // 将文件夹路径显示到 TextBox 中
                return folderPath;
            }
            return string.Empty;
        }
    }
}
