using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GetFileNamesRename
{
    public class GetModifyFile
    {
        #region 修改文件名

        /// <summary>
        /// 修改文件名
        /// </summary>
        /// <param name="sourceFile">原文件名</param>
        /// <param name="oldName">需要替换的文件名</param>
        /// <param name="neweName">替换文件名</param>
        /// <returns></returns>
        public bool ChangeFileName(string sourceFile, string oldName, string neweName)
        {
            //string aFile = @"D:\training_datum\test\test111.txt";
            if (!File.Exists(sourceFile))
                return false;

            string aFirstName = sourceFile.Substring(sourceFile.LastIndexOf("\\") + 1, (sourceFile.LastIndexOf(".") - sourceFile.LastIndexOf("\\") - 1));  //文件名
            string aLastName = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1, (sourceFile.Length - sourceFile.LastIndexOf(".") - 1));   //扩展名
            string newFile = sourceFile.Replace(oldName, neweName);
            try
            {
                File.Move(sourceFile, newFile);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("重命名失败原因：\r\n" + e.ToString(), "原因", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.ToString();
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

        #endregion


        #region 获取文件名

        //public List<string> FilesNameList;
        //public string PathName = string.Empty;

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
        /// <param name="pattern">搜索条件</param>
        /// <param name="searchMode">是否包含子目录：false 则仅包含本目录； true 则包含子目录 + 本目录</param>
        /// <returns></returns>
        public List<string> GetAllFileNames(string path, string pattern, bool searchMode)
        {
            try
            {
                SearchOption searchOption = new SearchOption();
                searchOption = searchMode ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                List<FileInfo> folder = new DirectoryInfo(path).GetFiles("*" + pattern + "*", searchOption).ToList();// 只搜索本目录
                return folder.Select(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("查询失败原因：\r\n" + e.ToString(), "原因", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            //List<string> folder =  Directory.GetFiles(path, "*" + pattern + "*", searchOption).ToList<string>();// 搜索 本目录 + 子目录
            //return folder;
        }
        
        #endregion
    }
}
