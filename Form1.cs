//#define SHIELD_EXTRACTION // 屏蔽 导出功能

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
using System.Globalization;

namespace  GetFileNamesRename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TxtB_PathName.Text = @"D:\training_datum\testreplace";
            TxtB_SearchName.Text = "*";
            TxtB_FilesCount.ReadOnly = true;
            ComB_SearchMode.SelectedIndex = 0;
        }

        #region 参数定义
        // 已屏蔽 导出功能： //_GetModifyFile.ExtractAllFileName(_pathName + @"\" + _outFileName, richTextBox1.Text);// 将文件名提取到指定文件中
#if SHIELD_EXTRACTION
        string _outFileName = "01_ExtractAllFileName.txt"; // 路径中的所有文件名到处到该文件中
#endif

        private string _pathName = string.Empty; // 文件夹路径
        private string _searchFileName = string.Empty; // 查找 文件夹路径

        private string _sourceName = string.Empty; // 原名（被替换名）
        private string _replaceName = string.Empty; // 替换名
        private string _suffixName = string.Empty; // 后缀名
        private bool _searchMode = false; // false：仅包含本路径； true： 包含 本路径 + 子路径
        //private int _filesCount = -1;

        private GetModifyFile _GetModifyFile = new GetModifyFile(); // 修改文件名
        private CDebugLog _debug = new CDebugLog(); // 日志打印

        #endregion


        #region 控件
        //控件
        private void Btn_GetFileName_Click(object sender, EventArgs e) //Btn_GetFileName : 获取 文件夹中 所有文件
        {
            //测试 log
            //DebugLog();
            SerachFile();
        }

        private void Btn_Replace_Click(object sender, EventArgs e)// Btn_Replace : 文件名 替换
        {
            if(ReplaceFile())
            {
                _searchFileName = _replaceName;
                UpdateControl();
            }
            SerachFile();
        }

        private void bBtn_SelectFullPath_Click(object sender, EventArgs e)//bBtn_SelectFullPath :选择文件夹
        {
            SelectFullPath();
        }

        private void Btn_SetSuffix_Click(object sender, EventArgs e) //Btn_SetSuffix : 设置后缀
        {
            SetSuffix();
        }

        private void TxtB_Format_KeyDown(object sender, KeyEventArgs e) // 搜索文件 Enter 功能
        {
            if (e.KeyCode == Keys.Enter)
                SerachFile();
        }

        private void Lab_ToSource_Click(object sender, EventArgs e) // Label serach to source
        {
            TxtB_SourceName.Text = TxtB_SearchName.Text;
        }

        private void Lba_ToSearch_Click(object sender, EventArgs e)// Label sourch to search
        {
            TxtB_SearchName.Text = TxtB_SourceName.Text;
        }

        #endregion


        #region 自定义函数
        // fun
        // Update 控件
        private void UpdateControl()
        {
            _pathName = TxtB_PathName.Text;
            _searchFileName = TxtB_SearchName.Text;

            _sourceName = TxtB_SourceName.Text;
            _replaceName = TxtB_ReplaceName.Text;
            _suffixName = TxtB_SuffixName.Text;

            switch (ComB_SearchMode.SelectedIndex)
            {
                case 0: _searchMode = false; break;
                case 1: _searchMode = true; break;
                default: _searchMode = false; break;
            }
        }

        // 设置 RichText 控件
        private void SetRichText(List<string> list)
        {
            int count = -1;
            richTextBox1.Clear();
            foreach (var fileName in list)
            {
                richTextBox1.AppendText(fileName + '\n');
                count++;
            }
            TxtB_FilesCount.Text = count.ToString();
#if SHIELD_EXTRACTION
                _GetModifyFile.ExtractAllFileName(_pathName + @"\" + _outFileName, richTextBox1.Text);// 将文件名提取到指定文件中
#endif
        }
        // 文件模糊查询
        private void SerachFile()
        {
            try
            {
                UpdateControl();

                if (string.IsNullOrEmpty(_pathName))
                    return;               

                List<string> filesNameList = _GetModifyFile.GetAllFileNames(_pathName, _searchFileName, _searchMode);
                SetRichText(filesNameList);

            }
            catch (Exception e1) { e1.ToString(); };    
        }
        // test
        private bool Test01()
        {
            //_sourceName.Replace("", "");
            string data = _sourceName.Trim('*');
            //string[] str1 = data.Split();
            if (_sourceName.StartsWith("*") || _sourceName.EndsWith("*"))
                ;
            return true;
        }
        
        // 文件名替换
        private bool ReplaceFile()
        {
            bool remaneSuc = false;
            try
            {
                UpdateControl();
                List<string> filesNameList = _GetModifyFile.GetAllFileNames(_pathName, _sourceName, _searchMode);
                if (string.IsNullOrEmpty(_pathName) || filesNameList.Count == 0 || _sourceName == "")
                {
                    MessageBox.Show("参数异常！请检查\r\n" + " 文件路径、搜索字符串，原名字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return remaneSuc;
                }
                //test
                //if(Test01())
                //    return;

                string searchName = string.Empty;// 搜索文件名称
                string replaceName = string.Empty; // 替换字符串
                string sourcePathName = string.Empty;// 原文件全路径

                foreach (var fileName in filesNameList)
                {
                    searchName = GetVagueString(fileName, _sourceName) ?? null;
                    replaceName = GetVagueString(fileName, _sourceName, _replaceName) ?? null;

                    if (fileName.Contains(_sourceName.Trim('*')) && searchName != null && replaceName != null)
                    {
                        sourcePathName = _pathName + "\\" + fileName;
                        remaneSuc = _GetModifyFile.ChangeFileName(sourcePathName, searchName, replaceName);
                    }
                }
                if (remaneSuc == false)
                    MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return remaneSuc;
            }
            catch{ MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return remaneSuc; }
           
        }

        //获取模糊字符串
        private string GetVagueString(string fileName, string search, string repalce = null)
        {
            try
            {
                string aFirstName = string.Empty; // 首部 * 表示的字符串
                string aLastName = string.Empty;// 尾部 * 表示的字符串
                string[] data;
                if (repalce != null && fileName.Contains(repalce.Trim('*')))
                    data = repalce.Split('*');//string.Empty; // *data*
                else
                    data = search.Split('*');

                switch (data.Length)
                {
                    case 2:
                        if (data[0] == string.Empty)
                            aFirstName = fileName.Substring(0, fileName.IndexOf(data[1]));
                        else
                            aLastName = fileName.Substring(fileName.IndexOf(data[0]) + data[0].Length, fileName.LastIndexOf(".") - (fileName.IndexOf(data[0]) + data[0].Length));
                        break;
                    case 3:
                        aFirstName = fileName.Substring(0, fileName.IndexOf(data[1]));
                        aLastName = fileName.Substring(fileName.IndexOf(data[1]) + data[1].Length, fileName.LastIndexOf(".") - (fileName.IndexOf(data[1]) + data[1].Length));
                        break;
                    case 0:
                    case 1:
                    default: return repalce ?? search;

                }
                return repalce == null ? aFirstName + search.Trim('*') + aLastName : aFirstName + repalce.Trim('*') + aLastName;
            }
            catch { return null; }
        }
        //获取模糊字符串 --未用
        private string GetVagueString(string fileName, string target, int mode)
        {
            try
            {
                string data = target.Trim('*');//string.Empty; // *data*
                string aFirstName = string.Empty; // 首部 * 表示的字符串
                string aLastName = string.Empty;// 尾部 * 表示的字符串
                int firstVague = 0; // 首部 * 位置
                int lastVague = 0;// 尾部 * 位置

                firstVague = target.IndexOf("*");
                lastVague = target.LastIndexOf("*");
                if (firstVague != -1 || lastVague != -1)// 模糊查询
                {
                    if (firstVague == 0 && firstVague == lastVague)// 首部 模糊搜索
                    {
                        aFirstName = fileName.Substring(0, fileName.IndexOf(data));
                    }
                    else if (firstVague > 0 && firstVague == lastVague)// 尾部 模糊搜索
                    {
                        int aa = fileName.LastIndexOf(data);
                        aLastName = fileName.Substring(fileName.IndexOf(data) + data.Length, fileName.LastIndexOf(".") - (fileName.IndexOf(data) + data.Length));
                    }
                    else if (firstVague == 0 && lastVague > firstVague)// 首部 尾部 模糊搜索
                    {
                        aFirstName = fileName.Substring(0, fileName.IndexOf(data));
                        aLastName = fileName.Substring(fileName.IndexOf(data) + data.Length, fileName.LastIndexOf(".") - (fileName.IndexOf(data) + data.Length));
                    }
                    return aFirstName + data + aLastName;
                }
                else// 确定查询
                    return target;
            }
            catch { return null; }

        }
       
        // 设置后缀名
        private void SetSuffix()
        {
            try
            {
                if (_suffixName == "")
                    return;
                if ((int)MessageBox.Show("确定修改后缀名？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                    return;

                if (!string.IsNullOrEmpty(_pathName))
                {
                    //扩展名
                    //string sourceExtension = ".";
                    string extension = _suffixName;
                    //初始化文件夹对象
                    DirectoryInfo dir = new DirectoryInfo(_pathName);
                    // 获取当前文件夹下的所有文件
                    //TopDirectoryOnly:在搜索操作中包括仅当前目录
                    FileInfo[] files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    //FileInfo[] files = dir.GetFiles(sourceExtension == "" ? "*.*" : "*.js", SearchOption.AllDirectories);

                    //遍历当前文件夹下的所有文件
                    for (int i = 0; i < files.Length; i++)
                    {
                        //获取并输出文件扩展名称
                        Console.WriteLine(Path.GetExtension(files[i].FullName));
                        //修改文件扩展名称
                        files[i].MoveTo(Path.ChangeExtension(files[i].FullName, extension));
                        //获取并输出文件扩展名称
                        Console.WriteLine(Path.GetExtension(files[i].FullName));
                    }
                }
            }
            catch { }
        }
        // 选择路径
        private void SelectFullPath()
        {
            // 打开 文件 路径
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Multiselect = true;//该值确定是否可以选择多个文件
            //dialog.Title = "请选择文件";
            //dialog.Filter = "所有文件(*.*)|*.*";
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    Console.WriteLine("选择了文件路径：" + dialog.FileName);
            //}

            // 打开 文件夹 路径
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            dialog.SelectedPath = "C:\\";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtB_PathName.Text = dialog.SelectedPath;
                Console.WriteLine("选择了文件夹路径：" + dialog.SelectedPath);
            }
        }

        #endregion


        #region 进程通讯

        /**********************  其他测试：进程通讯测试 ************************/
        protected override void DefWndProc(ref System.Windows.Forms.Message m)//进程通讯服务器
        {
            if (m.Msg == 0x1050)
            {
                var paraA = (int)m.WParam;
                var paramB = (int)m.LParam;
                richTextBox1.Text += Environment.NewLine + "Win32 Msg Receive Val:" + paraA;
                richTextBox1.Text += Environment.NewLine + "Win32 Msg Receive Val:" + paramB;
            }
            base.DefWndProc(ref m);
        }
        /*进程通讯客户端，详见ProcessCom*/

        // debug log
        private void DebugLog()
        {
            string[] strAry = new string[10];
            float temper = 12.3456f;
            for(int i = 0; i< strAry.Length; i++)
            {
                strAry[i] = i.ToString() + "    " + (i * temper).ToString();
                _debug.DebugLog(strAry[i]);
            }


            
        }
        #endregion

    }
}
