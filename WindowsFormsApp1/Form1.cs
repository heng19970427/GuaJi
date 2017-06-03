using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GuaJiBao : Form
    {
        public GuaJiBao()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://wywljx.jgsu.edu.cn/npels/login.aspx");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            btnLogin.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取网页源代码
            HtmlDocument ens = this.webBrowser1.Document;
            //tbName 用户名 
            HtmlElement id = ens.GetElementById("tbName");
            //tbPwd 密码 
            HtmlElement pwd = ens.GetElementById("tbPwd");
            //判断输入是否为空
            if (textBox1.Text != null && textBox2.Text != null)
            {
                id.SetAttribute("value", textBox1.Text.ToString());
                pwd.SetAttribute("value", textBox2.Text.ToString());
                //点击登陆按钮
                if (ens.GetElementById("btnLogin") != null)
                    ens.GetElementById("btnLogin").InvokeMember("click");
            }
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        //private void click()
        //{
        //    HtmlDocument ens = webBrowser1.Document;
        //    if (ens.GetElementById("BtnScript") != null)
        //        ens.GetElementById("BtnScript").InvokeMember("click");
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            HtmlDocument ens = webBrowser1.Document;
            HtmlElement btn1 = ens.Window.Frames["mainFrame"].Document.GetElementById("question1");
            HtmlElement btn2 = ens.Window.Frames["mainFrame"].Document.GetElementById("BodyDiv");
            if (btn1 != null)
            {
                btn1.InvokeMember("click");
            }
            if (btn2 != null)
            {
                btn2.InvokeMember("click");
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://xiaoliublog.cn");
        }
    }
}
