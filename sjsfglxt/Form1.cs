using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sjsfglxt
{
    public partial class Form1 : Form
    {
        public Form1()
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

            DataTable table = new SqlServerHelper().QuerySqlDataTable("select * from yhxx where yhzh=N'" + zh + "' and yhmm=N'" + mm + "'");

            if (table.Count() > 0)
            {
                MessageBox.Show("登录成功！");
                this.Hide();
                GlobalVar.yhxx_yhzh = zh;
                //打开主页面
                Form2 main = new Form2();
                main.FormClosed += Main_FormClosed;
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
