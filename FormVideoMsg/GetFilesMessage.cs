using System;
using System.Text;
using System.IO;
using Syntronic.IniReader;

namespace GetVideoDetails
{
    internal class GetFilesMessage
    {
        #region video op
        // 获取video 文件名，播放时长，文件大小
        public void GetFilesMsg(string videoFolderPath, string outputFilePath, ref string msg)
        {
            // 设置视频文件夹路径和输出文件路径
            //string folderPath = @"C:\Your\Folder\Path"; // 修改为你的视频文件夹路径
            //string outputFilePath = @"C:\Your\Output\Path\video_info.txt"; // 修改为你保存输出的txt路径

            try
            {
                // 获取所有视频文件（根据扩展名过滤）
                string[] videoFiles = Directory.GetFiles(videoFolderPath, "*.*", SearchOption.AllDirectories);
                outputFilePath = GetTextFileName(outputFilePath);

                // 打开文件流进行写入
                using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                {
                    // 写入文件的标题行
                    writer.WriteLine("File Name\t\t\t\t\t\t\t\tDuration\t\tFile Size");
                    msg += "File Name\t\t\t\t\t\t\t\tDuration\t\tFile Size" + "\n";

                    // 遍历所有视频文件
                    foreach (string file in videoFiles)
                    {
                        // 检查文件是否是视频文件（可以根据扩展名进行过滤）
                        if (IsVideoFile(file))
                        {
                            // 获取文件名
                            string fileName = Path.GetFileName(file);
                            // 获取文件大小（单位为MB）
                            FileInfo fileInfo = new FileInfo(file);
                            float fileSize = fileInfo.Length;
                            fileSize = (float)Math.Round(fileSize / 1024 / 1024, 2); // 转换为MB, 四舍五入到两位小数


                            // 获取视频时长（使用MediaInfo库）
                            string videoDuration = GetMediaTimeLenMinute(file);

                            // 将文件名、时长和文件大小写入到文本文件
                            writer.WriteLine($"{fileName}\t\t\t\t\t\t\t\t{videoDuration}\t\t{fileSize} MB");
                            msg += $"{fileName}\t\t\t\t\t\t\t\t{videoDuration}\t\t{fileSize} MB" + "\n";
                        }
                    }
                }

                Console.WriteLine("视频文件信息已保存到 " + outputFilePath);
                msg += "视频文件信息已保存到 " + outputFilePath + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(msg += "发生错误: " + ex.Message);
                msg += "发生错误: " + ex.Message + "\n";
            }
        }

        // 检查文件是否是视频文件
        private bool IsVideoFile(string filePath)
        {
            string[] videoExtensions = { ".mp4", ".avi", ".mkv", ".mov", ".flv", ".wmv", ".mpg", ".mpeg" };
            string fileExtension = Path.GetExtension(filePath).ToLower();
            return Array.Exists(videoExtensions, ext => ext == fileExtension);
        }

        // 获取视频文件的时长
        public static string GetMediaTimeLenMinute(string path)
        {
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                //文件路径              
                Shell32.Folder folder = shell.NameSpace(path.Substring(0, path.LastIndexOf("\\")));
                //文件名称            
                Shell32.FolderItem folderitem = folder.ParseName(path.Substring(path.LastIndexOf("\\") + 1));
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    string mediaLength = folder.GetDetailsOf(folderitem, 27);
                    return mediaLength;
                }
                else
                {
                    string mediaLength = folder.GetDetailsOf(folderitem, 21);
                    return mediaLength;
                }
            }
            catch (Exception ex) { return null; }
        }
        #endregion

        #region private
        // 获取或创建text文件，如果不存在，则创建
        private string GetTextFileName(string fullPath)
        {
            // 检查txt文件是否存在
            if(!fullPath.Contains(".txt"))//只包含路径
            {
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                string dateTimeString = DateTime.Now.ToString("yyyyMMdd_HHmmss");// 获取当前日期和时间并格式化为字符串
                string fileName = $"{dateTimeString}.txt";// 创建文件名，包含日期和时间
                fullPath = Path.Combine(fullPath + "\\", fileName);// 设置文件路径（可以根据需要修改路径）
                try
                {
                    File.WriteAllText(fullPath, "这是一个测试文件内容。");// 创建并写入文件
                    Console.WriteLine($"文件已创建: {fullPath}");// 输出文件路径
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"创建文件时发生错误: {ex.Message}");// 如果出现错误，输出异常信息
                }
            }
            else if (!File.Exists(fullPath))//路径 + 文件
            {
                EnsureFileExists(fullPath);
            }
            return fullPath;
        }
        private void EnsureFileExists(string fullFilePath)
        {
            // 获取文件所在的目录
            string directory = Path.GetDirectoryName(fullFilePath);

            // 如果目录不存在，先创建目录
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 如果文件不存在，创建空文件
            if (!File.Exists(fullFilePath))
            {
                File.Create(fullFilePath).Close(); // 关闭释放资源
            }
        }
        #endregion

        #region parameter define
        public struct Ini_VideoParameter
        {
            public string PathSource;
            public string PathOut;
        }
        public Ini_VideoParameter Ini_VideoParam = new Ini_VideoParameter();
        #endregion

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
            Ini_VideoParam.PathSource = _iniReader.ReadString("Config", "VideoPathSource", "");
            Ini_VideoParam.PathOut = _iniReader.ReadString("Config", "VideoPathOut", "");
        }
        public void IniWrite_Data(Ini_VideoParameter ini_Parameter)
        {
            _iniReader.Write("Config", "VideoPathSource", ini_Parameter.PathSource);
            _iniReader.Write("Config", "VideoPathOut", ini_Parameter.PathOut);

        }

        #endregion ============================ INI ============================
    }
}
