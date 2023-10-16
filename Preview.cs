using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFileNamesRename
{
    public delegate void CloseFormMsgHandler();
    public partial class Preview : Form
    {
        public event CloseFormMsgHandler CloseFormMsgEvent;
        public Preview(Form form1)
        {
            InitializeComponent();
            TxtB_FilesCount.ReadOnly = true;

            _form1 = (Form1)form1;
            Init();
        }

        Form1 _form1;

        private void Init()
        {
            _form1.PrevDataEvent += new PrevDataDeltage(ReceiveData);
            //richTextBox1.Font = new Font("Courier New", 8.25f);


        }

        private void ReceiveData(int count, string text)
        {
            richTextBox1.AppendText(text + '\n');
            TxtB_FilesCount.Text = count.ToString();
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = false;
            e.Cancel = true;
            CloseFormMsgEvent();
            richTextBox1.Clear();

        }
    }
}
