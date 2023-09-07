using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Syntronic.IniReader;

namespace GetFileNamesRename
{
    public class GetModifyFile
    {
        public enum SortOrder
        {
            Name_Order = 0,
            Name_Reverse = 1,
            CreationTime_Order = 2,
            CreationTime_Reverse = 3,
            Modify_Order = 4,
            Modify_Reverse = 5
        }

        public struct Ini_Parameter
        {
            public bool Enable;
            public string Extension;
            public string Search;
            public string SearchMode;
            public string Path;
            public string RenameFile;
            public string SortOrder;
        }

        public Ini_Parameter Ini_Param = new Ini_Parameter();


        #region ============================ Files ============================

        /// <summary>
        /// 将路径中的所有文件名到处到指定文件中
        /// </summary>
        /// <param name="strFilePath">导出文件名</param>
        /// <param name="strContent">导出字符串</param>
        public void ExtractAllFileName(string strFilePath, string strContent)
        {
            StreamWriter swOut = new StreamWriter(strFilePath, false, Encoding.Default);
            swOut.WriteLine(strContent);
            swOut.Flush();
            swOut.Close();
        }
        
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="order">搜索顺序</param>
        /// <param name="pattern">搜索条件</param>
        /// <param name="searchMode">是否包含子目录：false 则仅包含本目录； true 则包含子目录 + 本目录</param>
        /// <returns></returns>
        public FileInfo[] GetAllFileNames(string path, string pattern, SortOrder order, SearchOption searchOption)
        {

            try
            {
                string patt = !pattern.StartsWith("*") && !pattern.EndsWith("*") ? ("*" + pattern + "*") : pattern;
                FileInfo[] Files = new DirectoryInfo(path).GetFiles(patt, searchOption).ToArray();

                switch (order)
                {
                    case SortOrder.Name_Order:
                        SortAsFileName(ref Files, true); break;
                    case SortOrder.Name_Reverse:
                        SortAsFileName(ref Files, false); break;
                    case SortOrder.CreationTime_Order:
                        SortAsFileCreationTime(ref Files, true); break;
                    case SortOrder.CreationTime_Reverse:
                        SortAsFileCreationTime(ref Files, false); break;
                    case SortOrder.Modify_Order:
                        SortAsFileModifyTime(ref Files, true); break;
                    case SortOrder.Modify_Reverse:
                        SortAsFileModifyTime(ref Files, false); break;
                    default:
                        SortAsFileName(ref Files, true); break;
                }
                return Files;//Files.Select(x => x.Name).ToList()
            }
            catch (Exception e)
            {
                MessageBox.Show("查询失败原因：\r\n" + e.ToString(), "原因", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        // 设置后缀名
        //public void SetExtensionName(string extension, string path, string pattern, SortOrder order, SearchOption searchOption)
        //{
        //    try
        //    {
        //        if (extension == "")
        //            return;
        //        //if ((int)MessageBox.Show("确定修改 扩展名？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
        //        //    return;

        //        FileInfo[] files = GetAllFileNames(path, pattern, order, searchOption);

        //        foreach (FileInfo file in files)
        //        {
        //            file.MoveTo(Path.ChangeExtension(file.FullName, extension));
        //        }

        //        //if ((int)MessageBox.Show("扩展名 修改失败", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != 1)
        //        //    return;
        //    }
        //    catch { }
        //}
        public void SetExtensionName(string extension, string path, string pattern, SortOrder order, SearchOption searchOption)
        {
            try
            {
                if (extension == "")
                    return;
                //if ((int)MessageBox.Show("确定修改 扩展名？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1)
                //    return;

                FileInfo[] files = GetAllFileNames(path, pattern, order, searchOption);

                foreach(FileInfo file in files)
                {
                    file.MoveTo(Path.ChangeExtension(file.FullName, extension));
                }

                //if ((int)MessageBox.Show("扩展名 修改失败", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != 1)
                //    return;
            }
            catch { }
        }



        /// <summary>
        /// 修改文件名
        /// </summary>
        /// <param name="sourceFile">全路径 原文件名</param>
        /// <param name="oldName">旧文件名</param>
        /// <param name="neweName">新文件名</param>
        /// <returns></returns>
        public bool ChangeFileName(string sourceFile, string oldName, string neweName)
        {
            //string aFile = @"D:\training_datum\test\test111.txt";
            if (!File.Exists(sourceFile))
                return false;

            //string aFirstName = sourceFile.Substring(sourceFile.LastIndexOf("\\") + 1, (sourceFile.LastIndexOf(".") - sourceFile.LastIndexOf("\\") - 1));  //文件名
            //string aLastName = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1, (sourceFile.Length - sourceFile.LastIndexOf(".") - 1));   //扩展名
            string newFile = sourceFile.Replace(oldName, neweName);
            try
            {
                File.Move(sourceFile, newFile);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("重命名失败原因：\r\n" + e.ToString(), "原因", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }

        /// <summary>
        /// 修改文件名
        /// </summary>
        /// <param name="srcRelativePath">待修改文件相对路径（含文件名）</param>
        /// <param name="desRelativePath">修改后的文件相对路径（含文件名）</param>
        /// <returns>真：修改成功；假：修改失败</returns>
        private bool ChangeFileName(string srcRelativePath, string desRelativePath)
        {
            srcRelativePath = HttpContext.Current.Server.MapPath(srcRelativePath);
            desRelativePath = HttpContext.Current.Server.MapPath(desRelativePath);

            try
            {
                if (File.Exists(srcRelativePath))
                {
                    File.Move(srcRelativePath, desRelativePath);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #region ==== private sort order ====
        // sort name
        private void SortAsFileName(ref FileInfo[] arrFile, bool order)
        {
            if (order)
                Array.Sort(arrFile, (x, y) => { return x.Name.CompareTo(y.Name); });//Array.Sort(arrFile, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
            else
                Array.Sort(arrFile, (x, y) => { return y.Name.CompareTo(x.Name); });
        }

        // sort creation time
        private void SortAsFileCreationTime(ref FileInfo[] arrFile, bool order)
        {
            if (order)
                Array.Sort(arrFile, (x, y) => { return x.CreationTime.CompareTo(y.CreationTime); });
            else
                Array.Sort(arrFile, (x, y) => { return y.CreationTime.CompareTo(x.CreationTime); });
        }

        // sort modify time
        private void SortAsFileModifyTime(ref FileInfo[] arrFile, bool order)
        {
            if (order)
                Array.Sort(arrFile, (x, y) => { return x.LastWriteTime.CompareTo(y.LastWriteTime); });
            else
                Array.Sort(arrFile, (x, y) => { return y.LastWriteTime.CompareTo(x.LastWriteTime); });
        }

        //第二种 排序
        public class FIleLastTimeComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                //return y.LastWriteTime.CompareTo(x.LastWriteTime);//递减
                return x.LastWriteTime.CompareTo(y.LastWriteTime);//递增
            }
        }
        #endregion ==== private sort order ====

        #endregion  ============================ Files ============================


        #region  ============================ INI ============================

        private IniReader _iniReader = null;

        public void IniFiles()
        {
            // 返回上上级文件夹
            DirectoryInfo di = new DirectoryInfo(string.Format(@"{0}..\..\..\", System.Environment.CurrentDirectory));//Application.StartupPath
            string path = di.FullName + @"IniReader\FileConfig.ini";

            if (File.Exists(path) && _iniReader == null)
                _iniReader = new IniReader(path);
        }
        public void IniRead_Data()
        {
            Ini_Param.Enable = _iniReader.ReadBoolean("Config", "EnableCreat", false);
            Ini_Param.Extension = _iniReader.ReadString("Config", "Extension", "");
            Ini_Param.Search = _iniReader.ReadString("Config", "Search", "");
            Ini_Param.SearchMode = _iniReader.ReadString("Config", "SearchMode", "");
            Ini_Param.Path = _iniReader.ReadString("Config", "Path", "");
            Ini_Param.RenameFile = _iniReader.ReadString("Config", "RenameFile", "");
            Ini_Param.SortOrder = _iniReader.ReadString("Config", "SortOrder", "");
        }
        public void IniWrite_Data(Ini_Parameter ini_Parameter)
        {
            _iniReader.Write("Config", "EnableCreat", ini_Parameter.Enable);
            _iniReader.Write("Config", "Extension", ini_Parameter.Extension);
            _iniReader.Write("Config", "Search", ini_Parameter.Search);
            _iniReader.Write("Config", "SearchMode", ini_Parameter.SearchMode);
            _iniReader.Write("Config", "Path", ini_Parameter.Path);
            _iniReader.Write("Config", "RenameFile", ini_Parameter.RenameFile);
            _iniReader.Write("Config", "SortOrder", ini_Parameter.SortOrder);
        }

        #endregion ============================ INI ============================
    }
}
