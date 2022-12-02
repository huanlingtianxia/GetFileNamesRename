using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace  GetFileNamesRename
{
    class ProcessCom
    {


    }

    /*进程通讯客户端*/
    public class ApiSendMessag
    {
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wP, IntPtr lP);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public void SendMessage(int intptr)// 未用
        {
            Process[] pros = Process.GetProcesses(); //获取本机所有进程
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].ProcessName == "GetFileNames") //名称为ProcessCommunication的进程

                {
                    IntPtr hWnd = pros[i].MainWindowHandle; //获取ProcessCommunication.exe主窗口句柄
                    int data = Convert.ToInt32("GetFileNames successful"); //获取文本框数据
                    SendMessage(hWnd, 0x0100, (IntPtr)data, (IntPtr)0); //点击该按钮，以文本框数据为参数，向Form1发送WM_KEYDOWN消息
                }
            }
        }

        public void SendMessage()
        {

            //获取到我们需要发送到的窗体的进程，然后获取他的主窗体句柄，将我们的消息10,20发送到指定的窗体中，然后会执行DefWndProc方法，
            //然后在方法中判断msg类型是否和我们这边发送的0x1050一致，就可以收到客户端发送的消息，第二个参数是我们定义的消息类型，
            //可以自己定义数字  也可以根据Win32 api里面规定的对应的功能用哪些也可以
            Process process = Process.GetProcessesByName("GetFileNames").FirstOrDefault();
            SendMessage(process.MainWindowHandle, 0x1050, 10, 20);
        }



    }
}
