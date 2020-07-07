using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sjsfxxxt
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zh = textBox1.Text;
            string mm = textBox2.Text;

            if (string.IsNullOrEmpty(zh))
            {
                MessageBox.Show("账号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(mm))
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            DataTable table = new SqlServerHelper().QuerySqlDataTable("select * from denglu where zh=N'" + zh + "' and mm=N'" + mm + "'");

            if (table.Count() > 0)
            {
                MessageBox.Show("登录成功！");
                this.Hide();
                GlobalVar.denglu_zh = zh;
                //打开主页面
                FormMain main = new FormMain();
                main.FormClosed += Main_FormClosed;
                main.WindowState = FormWindowState.Maximized;
                main.Show();
            }
            else
            {
                MessageBox.Show("用户名密码输入有误！");
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
