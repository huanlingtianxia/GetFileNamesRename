//#define SHIELD_EXTRACTION // shield export get files
#define SHIELD

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
using Syntronic.IniReader;
using GetVideoDetails;

namespace  GetFileNamesRename
{
    public delegate void PrevDataDeltage(int count, string text);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                _getModifyFile.IniFiles(); // ini
                _getModifyFile.IniRead_Data(); // ini

                Path_Ctrl = _getModifyFile.Ini_Param.Path;
                Extension_Ctrl = _getModifyFile.Ini_Param.Extension;
                Search_Ctrl = _getModifyFile.Ini_Param.Search;
                SearchMode_Ctrl = _getModifyFile.Ini_Param.SearchMode;
                TxtB_FilesCount.ReadOnly = true;
                ComB_SearchMode.SelectedIndex = 0;

                _enableCtrl = true;

            }
            catch(Exception ex) { ex.ToString(); }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            form1 = new Form1();
            preview = new Preview(form1);// init
            formVideoDetail = new FormVideoDetail();
            //preview.FormClosed += Preview_FormClosed;
            //preview.CloseFormMsgEvent -= Preview_CloseForm;
            preview.CloseFormMsgEvent += Preview_CloseForm;
        }

        #region ================== delegate event ====================
        public string PreData = string.Empty;
        public event PrevDataDeltage PrevDataEvent;
        public void RunPrevEvent(int count, string data)
        {
            form1.PrevDataEvent(count, data);
        }

        #endregion #region ================== delegate event ====================

        #region ================== parameter define ====================
        public enum PrevType
        {
            UNDEFINE = 0,
            QUERY = 1,
            DELETE = 2,
            REPLACE = 3,
            EXTENSION = 4,
        }

        private Form1 form1;
        private static Preview preview;
        private static FormVideoDetail formVideoDetail;
        private string _pathName = string.Empty; // folder path
        private string _sourceName = string.Empty; // source name
        private string _replaceName = string.Empty; // replace name
        private bool _enableCtrl = false;

        private PrevType _prevType = new PrevType();
        private Dictionary<string,string> _DictionnaryList = new Dictionary<string,string>();

        //private int _filesCount = -1;

        private GetModifyFile _getModifyFile = new GetModifyFile(); // modify files
                                                                    //private CDebugLog _debug = new CDebugLog(); // print log     

        #endregion ================== parameter define ====================

        #region  ================= Control Event ====================


        // button
        #region == button ==
        // pop video from
        private void Btn_PopVideo_Click(object sender, EventArgs e)
        {
            if (preview != null)
                formVideoDetail.ShowDialog();
        }
        private void Btn_SelectFullPath_Click(object sender, EventArgs e)//bBtn_SelectFullPath :select folder
        {
            SelectFullPath();
        }
        private void Btn_GetFileName_Click(object sender, EventArgs e) //Btn_GetFileName : get all files in folder
        {
            RestartCurrentSWFun();//test Ericsson merge platform
            SerachFile();
        }
        private void Btn_Replace_Click(object sender, EventArgs e)// Btn_Replace : files name replace
        {
            OpenDialog(preview);
            ReplaceFileName();
        }
        private void Btn_DeletePartName_Click(object sender, EventArgs e) // delete part name
        {
            OpenDialog(preview);
            DeletePartName();

        }
        private void Btn_SetExtension_Click(object sender, EventArgs e) //Btn_SetExtension : set suffix
        {
            OpenDialog(preview);
            SetExtension();
        }

        #endregion == button ==


        #region == label + Text + ComBox ==
        //label
        private void Lab_ToSource_Click(object sender, EventArgs e) // Label search to source
        {
            TxtB_SourceName.Text = TxtB_SearchName.Text;
        }
        private void Lba_ToSearch_Click(object sender, EventArgs e) // Label sourch to search
        {
            TxtB_SearchName.Text = TxtB_SourceName.Text;
        }
        private void Lab_ReplaceName_Click(object sender, EventArgs e) // Label sourch to replace
        {
            TxtB_ReplaceName.Text = TxtB_SearchName.Text;
        }
        private void Lab_AddStar_Click(object sender, EventArgs e) // add star
        {
            RepalceName_Ctrl = "*" + RepalceName_Ctrl + "*";
        }
        private void Lab_SubtractStar_Click(object sender, EventArgs e) // subtract star
        {
            RepalceName_Ctrl = RepalceName_Ctrl.Trim('*');
        }
        // text
        private void TxtB_Format_KeyDown(object sender, KeyEventArgs e) // search files Enter function
        {
            if (e.KeyCode == Keys.Enter)
                SerachFile();
        }
        //combox
        private void ComB_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_enableCtrl)
                SerachFile();
        }
        #endregion == label ==


        #region == hovering show ==
        // hovering show
        private void TxtB_ReplaceName_MouseMove(object sender, MouseEventArgs e) // hovering show
        {
            toolTip1.SetToolTip(TxtB_ReplaceName, $"搜索出包含 \"{SourceName_Ctrl}\" 字符的文件，并将该文件的 \"{SourceName_Ctrl}\" 字符 替换为 \"{ReplaceName_Ctrl}\"字符. 替换规则如下：\r\n" +
                $"\"{ReplaceName_Ctrl}\" 首尾加‘*’(etc: \"*{ReplaceName_Ctrl}*\"): 表示所有包含 \"{SourceName_Ctrl}\" 的文件， 只将该文件的 \"{SourceName_Ctrl}\" 替换为 \"{ReplaceName_Ctrl}\"，其他部分保持不变\r\n" +
                $"\"{ReplaceName_Ctrl}\" 首尾无‘*’(etc: \"{ReplaceName_Ctrl}\"): 表示所有包含 \"{SourceName_Ctrl}\" 的文件，整个文件名替换 为 \"{ReplaceName_Ctrl}\"");
        }
        private void TxtB_SourceName_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TxtB_SourceName, $"搜索所有包含 \"{SourceName_Ctrl}\" 字符的文件");
        }
        private void TxtB_DeletePartName_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TxtB_DeletePartName, $"搜索出包含 \"{SourceName_Ctrl}\" 字符的文件，并 删除 该文件含有 \"{DeletePartName_Ctrl}\"的部分");
        }
        private void TxtB_RepalceAddSuffix_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(TxtB_RepalceAddSuffix, $" 按下“Replace”按钮时，为目标文件添加 后缀 \"{RepalceAddSuffix_Ctrl}\"");
        }
        private void CheckB_EnableSerialNumber_MouseMove(object sender, MouseEventArgs e)
        {
            string state = EnableSerialNumber_Ctrl ? "使能 添加序号" : "失能 添加序号";
            toolTip1.SetToolTip(CheckB_EnableSerialNumber, $" 按下“Replace”按钮时，为目标文件的后缀后面添加 序号，起始序号SN： \"{SerialNumber_Ctrl}\"\r\n" +
                $"状态：{state}");
        }
        #endregion == hovering show ==

        #endregion  ================= Control Event ====================

        #region ================= Control Property ====================
        // ini parameter
        private bool EnableCreat_Ctrl
        {
            get => CheckB_EnableCreatFile.Checked;
            set => CheckB_EnableCreatFile.Checked = value;
        }
        private string Extension_Ctrl
        {
            get => TxtB_ExtensionName.Text;
            set => TxtB_ExtensionName.Text = value;
        }
        private string Search_Ctrl
        {
            get => TxtB_SearchName.Text;
            set => TxtB_SearchName.Text = value;
        }
        private string SearchMode_Ctrl
        {
            get => ComB_SearchMode.Text;// GetControlTextSafe(ComB_SearchMode);
            set => ComB_SearchMode.Text = value;
        }
        private string Path_Ctrl
        {
            get => TxtB_PathName.Text;
            set => TxtB_PathName.Text = value;
        }
        private string ReplaceName_Ctrl
        {
            get => TxtB_ReplaceName.Text;
            set => TxtB_ReplaceName.Text = value;
        }
        private string SortOrder_Ctrl
        {
            get => ComB_Order.Text;//GetControlTextSafe(ComB_Order);
            set => ComB_Order.Text = value;
        }


        private string DeletePartName_Ctrl
        {
            get => TxtB_DeletePartName.Text;
            set => TxtB_DeletePartName.Text = value;
        }
        private string RepalceName_Ctrl
        {
            get => TxtB_ReplaceName.Text;
            set => TxtB_ReplaceName.Text = value;
        }
        private string RepalceAddSuffix_Ctrl
        {
            get => TxtB_RepalceAddSuffix.Text;
            set => TxtB_RepalceAddSuffix.Text = value;
        }
        private string SourceName_Ctrl
        {
            get => TxtB_SourceName.Text;
            set => TxtB_SourceName.Text = value;
        }
        private int SerialNumber_Ctrl
        {
            // get => TxtB_SourceName.Text;
            get
            {
                return (int)NumericUpD_SerialNumber.Value;
                //return Convert.ToInt32(TxtB_SourceName.Text);
            }
           
        }
        private bool EnableSerialNumber_Ctrl
        {
            get => CheckB_EnableSerialNumber.Checked;
            set => CheckB_EnableSerialNumber.Checked = value;
        }
        #endregion ================= Control Property ====================

        #region ================= Form ====================

        public async void Preview_CloseForm()
        {
            if ((int)MessageBox.Show("是否执行 Preview 中的操作", "待确认", MessageBoxButtons.OKCancel, MessageBoxIcon.None) != 1)
                return;
            string path = Path_Ctrl;
            string extension = Extension_Ctrl;
            string sourceName = SourceName_Ctrl;
            switch (_prevType)
            {
                case PrevType.UNDEFINE:    break;
                case PrevType.QUERY: break;

                case PrevType.DELETE:
                case PrevType.REPLACE:
                    await Task.Run(() =>
                    {
                        foreach (var fileName in _DictionnaryList)
                        {
                            _getModifyFile.ChangeFileName(path + "\\" + fileName.Key, fileName.Key, fileName.Value);
                        }
                    });

                    break;

                //case PrevType.REPLACE: break;

                case PrevType.EXTENSION:
                    GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
                    SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);
                    await Task.Run(() =>
                    {
                        _getModifyFile.SetExtensionName(extension, path, sourceName, or, so);
                    });
                    
                    break;

                default: break;
            }
        }
        private void Preview_FormClosed(object sender, FormClosedEventArgs e)
        {

            //ReplaceFile();//
        }

        /*在Panel1中打开窗口*/
        //private void openMethod(Form form, Panel panel)
        //{

        //    parameter_controlTest.form_panelA = form;
        //    form.TopLevel = false;
        //    //    form.WindowState = FormWindowState.Maximized;
        //    //    form.FormBorderStyle = FormBorderStyle.None;
        //    form.Parent = panel;
        //    form.Show();
        //}

        /*关闭Panel1中窗口*/
        private void CloseForm(Panel panel)
        {
            foreach (Control item in panel.Controls)
            {
                if (item is Form)
                {
                    Form form = (Form)item;
                    //    form.Close();
                    panel.Controls.Remove(form);
                }
            }
        }

        /*在Panel1中打开窗口*/
        //private void openForm(Form form, Panel panel)
        //{
        //    parameter_control.form_panelA = form;
        //    form.TopLevel = false;
        //    form.WindowState = FormWindowState.Normal;

        //    form.FormBorderStyle = FormBorderStyle.None;
        //    form.Parent = panel;
        //    form.Show();
        //}

        public bool OpenDialog(Form form)
        {
            bool open = false;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == form.Name)
                {
                    open = true;
                    form.WindowState = FormWindowState.Normal;
                    //openForm.Show();
                    openForm.Show();
                    openForm.Activate();
                    form = openForm;
                }
            }
            if (!open)
            {
                form.Show();
            }
            return open;
        }

        #endregion ================= Form ====================

        #region ================== private function =====================
        // fun
        // Update 控件

        //ComboBox

        public string GetControlTextSafe(Control control)
        {
            if (control.InvokeRequired)
            {
                return (string)control.Invoke(new Func<string>(() => control.Text));
            }
            else
            {
                return control.Text;
            }
        }
        public void SetControlValueSmart(Control control, string text, bool clear = false)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() =>
                {
                    if (control is RichTextBox richTB)
                    {
                        if (clear)
                            richTB.Clear();
                        richTB.AppendText(text); // RichTextBox 用追加
                    }
                    else
                    {
                        control.Text = text; // 其他控件直接赋值
                    }
                }));
            }
            else
            {
                if (control is RichTextBox richTB)
                {
                    if (clear)
                        richTB.Clear();
                    richTB.AppendText(text); // RichTextBox 用追加
                }
                else
                {
                    control.Text = text; // 其他控件直接赋值
                }
            }
        }


        private void UpdateControl()
        {
            _pathName = Path_Ctrl; // 文件夹路径
            _sourceName = SourceName_Ctrl; // 原名（被替换名）
            _replaceName = ReplaceName_Ctrl; // 替换名
        }

        // set RichText control
        private void SetRichText(List<string> list)
        {
            int count = 0;
            richTextBox1.Clear();
            foreach (var fileName in list)
            {             
                richTextBox1.AppendText(fileName + '\n');
                count++;
            }
            TxtB_FilesCount.Text = count.ToString();
            if (EnableCreat_Ctrl)
                _getModifyFile.ExtractAllFileName(Path_Ctrl + @"\" + ReplaceName_Ctrl, richTextBox1.Text); // extract file name
        }
        // get files
        private async Task<List<string>> GetFiles(string path, string search)
        {
            UpdateControl();
            List<string> filesNameList = null;
            GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
            SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);
            await Task.Run(() =>
            {
                filesNameList = _getModifyFile.GetAllFileNames(path, search, or, so).Select(x => x.Name).ToList();
            });
            if (string.IsNullOrEmpty(path) || filesNameList.Count == 0 || search == "")
            {
                MessageBox.Show("参数异常！请检查\r\n" + " 文件路径、搜索字符串，原名字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return filesNameList;
        }

        private async void SerachFile()
        {
            try
            {
                UpdateControl();

                if (string.IsNullOrEmpty(Path_Ctrl))
                    return;
                List<string> filesNameList = null;
                filesNameList = await GetFiles(Path_Ctrl, SourceName_Ctrl);

                SetRichText(filesNameList);

                GetModifyFile.Ini_Parameter ini_Parameter = new GetModifyFile.Ini_Parameter();
                ini_Parameter.Enable = EnableCreat_Ctrl;
                ini_Parameter.Extension = Extension_Ctrl;
                ini_Parameter.Search = Search_Ctrl;
                ini_Parameter.SearchMode = SearchMode_Ctrl;
                ini_Parameter.Path = Path_Ctrl;
                ini_Parameter.RenameFile = ReplaceName_Ctrl;
                ini_Parameter.SortOrder = SortOrder_Ctrl;
                _getModifyFile.IniWrite_Data(ini_Parameter); // ini

            }
            catch (Exception e1) { e1.ToString(); };    
        }

        // replace
        private async void ReplaceFileName()
        {
            int count = 0;
            int serialNumber = SerialNumber_Ctrl - 1;
            string replaceName = string.Empty;
            string fileOlny = string.Empty;
            string suffix = string.Empty;
            List<string> filesNameList = await GetFiles(Path_Ctrl, SourceName_Ctrl);
            _DictionnaryList.Clear();

            if (RepalceName_Ctrl == "" || SourceName_Ctrl == "")
                return;


            RunPrevEvent(count, $"old name{string.Empty, -200}  ----> new name\r\n");
            foreach (var fileName in filesNameList)
            {

                if (RepalceAddSuffix_Ctrl != "") // suffix
                    suffix = RepalceAddSuffix_Ctrl;
                if (EnableSerialNumber_Ctrl) // serial number
                {
                    serialNumber++;
                    suffix += serialNumber.ToString();
                }
                count++;
                if (!_replaceName.StartsWith("*") && !_replaceName.EndsWith("*"))
                {
                    replaceName = RepalceName_Ctrl + suffix + Path.GetExtension(fileName);
                }
                else if (_replaceName.StartsWith("*") && _replaceName.EndsWith("*"))
                {
                    replaceName = fileName.Replace(_sourceName.Trim('*'), _replaceName.Trim('*'));
                    fileOlny = replaceName.Substring(0, replaceName.LastIndexOf("."));
                    replaceName = fileOlny + suffix + Path.GetExtension(fileName);
                }
                RunPrevEvent(count, $"{fileName,-120} ----> {replaceName}");
                suffix = string.Empty;
                _DictionnaryList.Add(fileName, replaceName);
            }
            _prevType = PrevType.REPLACE;

        }

        // delete part name
        private async void DeletePartName()
        {
            int count = 0;
            List<string> filesNameList = await GetFiles(Path_Ctrl, SourceName_Ctrl);

            _DictionnaryList.Clear();
            RunPrevEvent(count, $"old name{string.Empty, -200}  ----> new name\r\n");
            foreach (var fileName in filesNameList)
            {
                string reName = string.Empty;
                string extension = Path.GetExtension(fileName);//扩展名
                string fileOlny = fileName.Substring(0, fileName.LastIndexOf("."));
                int pos = fileOlny.IndexOf(DeletePartName_Ctrl);

                if (pos == -1)
                    continue;
                else if (pos < fileOlny.Length && pos == 0)
                {
                    reName = fileOlny.Substring(DeletePartName_Ctrl.Length, fileOlny.Length - DeletePartName_Ctrl.Length);
                }
                else if (pos < fileOlny.Length && pos > 0)
                {
                    reName = fileOlny.Substring(0, pos) + fileOlny.Substring(pos + DeletePartName_Ctrl.Length, fileOlny.Length - DeletePartName_Ctrl.Length - pos);
                }

                count++;
                reName += extension;

                RunPrevEvent(count, $"{fileName,-120} ----> {reName}");
                _DictionnaryList.Add(fileName, reName);
            }
            _prevType = PrevType.DELETE;
        }

        // set suffix
        private async void SetExtension()
        {
            if (Extension_Ctrl == "" || SourceName_Ctrl == "")
                return;

            try
            {
                int count = 0;
                UpdateControl();
                List<string> filesNameList = await GetFiles(Path_Ctrl, SourceName_Ctrl);

                RunPrevEvent(count, $"old name{string.Empty, -200}  ----> new name\r\n");
                foreach (var fileName in filesNameList)
                {
                    string reName = string.Empty;
                    string extension = Path.GetExtension(fileName);//扩展名
                    string fileOlny = fileName.Substring(0, fileName.LastIndexOf("."));
                    reName = fileOlny + "." + Extension_Ctrl;
                    count++;
                    RunPrevEvent(count, $"{fileName,-120} ----> {reName}");
                }

                _prevType = PrevType.EXTENSION;
                //GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
                //SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);

                //_getModifyFile.SetExtensionName(Extension_Ctrl, Path_Ctrl, SourceName_Ctrl, or, so);

            }
            catch(Exception ex) { ex.ToString(); }
        }
        // select path
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
                Path_Ctrl = dialog.SelectedPath;
                Console.WriteLine("选择了文件夹路径：" + dialog.SelectedPath);
            }
        }

        #region ==== not use ===
        // test
        private bool Test01()
        {
            //_sourceName.Replace("", "");
            //string[] str1 = data.Split();
            //if (_sourceName.StartsWith("*") || _sourceName.EndsWith("*"))
            //    ;

            return true;
        }
        // replace preview
        private bool PrevReplaceFile()
        {

            try
            {
                string searchName1 = string.Empty;// 搜索文件名称
                string replaceName1 = string.Empty; // 替换字符串
                string sourcePathName1 = string.Empty;// 原文件全路径
                //bool remaneSuc = false;

                UpdateControl();

                GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
                SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);
                List<string> filesNameList = _getModifyFile.GetAllFileNames(_pathName, _sourceName, or, so).Select(x => x.Name).ToList();
                if (string.IsNullOrEmpty(_pathName) || filesNameList.Count == 0 || _sourceName == "")
                {
                    MessageBox.Show("参数异常！请检查\r\n" + " 文件路径、搜索字符串，原名字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (RepalceAddSuffix_Ctrl != "")
                {
                    if (MessageBox.Show("替换文件名时，确定添加后缀？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                    }
                }
                

                int count = 0;
                int serialNumber = SerialNumber_Ctrl - 1;
                foreach (var fileName in filesNameList)
                {
                    count++;
                    string suffix = string.Empty;
                    if (RepalceAddSuffix_Ctrl != "")
                        suffix = RepalceAddSuffix_Ctrl;
                    if (EnableSerialNumber_Ctrl) // 替换后缀添加 自增 编号
                    {
                        serialNumber++;
                        suffix += serialNumber.ToString();
                    }

                    if (!_sourceName.StartsWith("*") && !_sourceName.EndsWith("*"))
                        RunPrevEvent(count, fileName + "---->" + replaceName1);
                    // remaneSuc = _getModifyFile.ChangeFileName(sourcePathName1, _sourceName, _replaceName + suffix);
                    else
                    {
                        searchName1 = GetVagueString(fileName, _sourceName) ?? null;
                        replaceName1 = GetVagueString(fileName, _sourceName, _replaceName) ?? null;
                        replaceName1 += suffix;

                        if (fileName.Contains(_sourceName.Trim('*')) && searchName1 != null && replaceName1 != null)
                        {
                            //sourcePathName1 = _pathName + "\\" + fileName;
                            //remaneSuc = _getModifyFile.ChangeFileName(sourcePathName1, searchName1, replaceName1);
                            RunPrevEvent(count, fileName + "---->" + replaceName1);
                        }
                    }
                    
                }
                return true;
            }
            catch { MessageBox.Show("预览失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }

        }
        // file name replace
        private bool ReplaceFile()
        {
            bool remaneSuc = false;
            
            try
            {
                UpdateControl();
                GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
                SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);
                List<string> filesNameList = _getModifyFile.GetAllFileNames(_pathName, _sourceName, or, so).Select(x => x.Name).ToList();

                if ((int)MessageBox.Show("是否替换？", "待确认", MessageBoxButtons.OKCancel, MessageBoxIcon.None) != 1)
                    return remaneSuc;

                string searchName1 = string.Empty;// 搜索文件名称
                string replaceName1 = string.Empty; // 替换字符串
                string sourcePathName1 = string.Empty;// 原文件全路径

                int serialNumber = SerialNumber_Ctrl - 1;
                foreach (var fileName in filesNameList)
                {
                    string suffix = string.Empty;
                    if (RepalceAddSuffix_Ctrl != "")
                        suffix = RepalceAddSuffix_Ctrl;
                    if (EnableSerialNumber_Ctrl) // 替换后缀添加 自增 编号
                    {
                        serialNumber++;
                        suffix += serialNumber.ToString();
                        ReplaceName_Ctrl += suffix;
                    }

                    sourcePathName1 = _pathName + "\\" + fileName;

                    if(!_sourceName.StartsWith("*") && !_sourceName.EndsWith("*"))
                        remaneSuc = _getModifyFile.ChangeFileName(sourcePathName1, _sourceName, _replaceName + suffix);
                    else
                    {
                        searchName1 = GetVagueString(fileName, _sourceName) ?? null;
                        replaceName1 = GetVagueString(fileName, _sourceName, _replaceName) + suffix ?? null;

                        if (fileName.Contains(_sourceName.Trim('*')) && searchName1 != null && replaceName1 != null)
                        {
                            remaneSuc = _getModifyFile.ChangeFileName(fileName, searchName1, replaceName1);
                        }
                    }

                }
                if (remaneSuc == false)
                    MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return remaneSuc;
            }
            catch { MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return remaneSuc; }

        }



        //private bool ReplaceFile()
        //{
        //    bool remaneSuc = false;
        //    string suffix = string.Empty;
        //    int serialNumber = SerialNumber_Ctrl - 1;
        //    try
        //    {
        //        UpdateControl();

        //        GetModifyFile.SortOrder or = (GetModifyFile.SortOrder)Enum.Parse(typeof(GetModifyFile.SortOrder), SortOrder_Ctrl);
        //        SearchOption so = (SearchOption)Enum.Parse(typeof(SearchOption), SearchMode_Ctrl);
        //        List<string> filesNameList = _getModifyFile.GetAllFileNames(_pathName, _sourceName, or, so).Select(x => x.Name).ToList();
        //        if (string.IsNullOrEmpty(_pathName) || filesNameList.Count == 0 || _sourceName == "")
        //        {
        //            MessageBox.Show("参数异常！请检查\r\n" + " 文件路径、搜索字符串，原名字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return remaneSuc;
        //        }

        //        if (RepalceAddSuffix_Ctrl != "")
        //        {
        //            if (MessageBox.Show("替换文件名时，确定添加后缀？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        //            {
        //                suffix = RepalceAddSuffix_Ctrl;
        //            }
        //        }

        //        //打印 确认信息
        //        //string printfStr = string.Empty;
        //        int count = 0;
        //        foreach (var fileName in filesNameList)
        //        {
        //            count++;

        //            //printfStr += (GetVagueString(fileName, _sourceName) ?? null) + "---->" + (GetVagueString(fileName, _sourceName, _replaceName) ?? null) + "\r\n";
        //            RunPrevEvent(count, (GetVagueString(fileName, _sourceName) ?? null) + "---->" + (GetVagueString(fileName, _sourceName, _replaceName) ?? null));
        //        }

        //        if ((int)MessageBox.Show("是否替换？", "待确认", MessageBoxButtons.OKCancel, MessageBoxIcon.None) != 1)
        //            return remaneSuc;


        //        string searchName1 = string.Empty;// 搜索文件名称
        //        string replaceName1 = string.Empty; // 替换字符串
        //        string sourcePathName1 = string.Empty;// 原文件全路径

        //        foreach (var fileName in filesNameList)
        //        {
        //            if(EnableSerialNumber_Ctrl) // 替换后缀添加 自增 编号
        //            {
        //                serialNumber++;
        //                suffix += serialNumber.ToString();
        //            }

        //            searchName1 = GetVagueString(fileName, _sourceName) ?? null;
        //            replaceName1 = GetVagueString(fileName, _sourceName, _replaceName) + suffix ?? null;

        //            if (fileName.Contains(_sourceName.Trim('*')) && searchName1 != null && replaceName1 != null)
        //            {
        //                sourcePathName1 = _pathName + "\\" + fileName;
        //                remaneSuc = _getModifyFile.ChangeFileName(sourcePathName1, searchName1, replaceName1);
        //            }
        //        }
        //        if (remaneSuc == false)
        //            MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return remaneSuc;
        //    }
        //    catch{ MessageBox.Show("重命名失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return remaneSuc; }

        //}

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
        //get fuzzy string --not use
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
        #endregion ==== not use ===

        #endregion ================== private function =====================


        #region ================== process communication =====================

        /**********************  other test ：进程通讯测试 ************************/
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
               // _debug.DebugLog(strAry[i]);
            }


            
        }




        #endregion ================== process communication =====================

        #region ============  test Ericsson merge platform =============
        //test calss
        class RestartCurrentSW : impelmentBase
        {
            string ss;
            public RestartCurrentSW(Form1 form1, string str)
            {
                this.iru = form1;
                ss = str;
            }

            public override void Run()
            {
                string source = iru.SourceName_Ctrl;
            }
        }

        class impelmentBase
        {
            public Form1 iru = null;
            public int retestLimit = 0;

            public void Execute()
            {
                int retestCounter = retestLimit;
                Run();
               
            }
            public virtual void Run() { }
        }

        private void RestartCurrentSWFun()
        {
            RestartCurrentSW restartCurrentSW = new RestartCurrentSW(this, "ssss");

            restartCurrentSW.Execute();
        }

        #endregion ============  test Ericsson merge platform =============


    }
}
