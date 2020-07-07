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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void FormChangePwd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mm_o = textBox1.Text;
            string mm_n = textBox2.Text;
            string mm_n1 = textBox3.Text;

            if (string.IsNullOrEmpty(mm_o))
            {
                MessageBox.Show("原密码不能为空");
                return;
            }
            if (string.IsNullOrEmpty(mm_n))
            {
                MessageBox.Show("新密码不能为空");
                return;
            }
            if (string.IsNullOrEmpty(mm_n1))
            {
                MessageBox.Show("重复新密码不能为空");
                return;
            }
            if (mm_n == mm_o)
            {
                MessageBox.Show("新密码不能与原密码相同");
                return;
            }
            if (mm_n != mm_n1)
            {
                MessageBox.Show("两次密码输入一致");
                return;
            }
            DataTable table = new SqlServerHelper().QuerySqlDataTable("select * from yhxx where yhzh=N'" + GlobalVar.yhxx_yhzh + "' and yhmm=N'" + mm_o + "'");

            if (table.Count() > 0)
            {
                string sql = "update yhxx set yhmm=N'" + mm_n + "' where yhzh=N'" + GlobalVar.yhxx_yhzh + "'";
                new SqlServerHelper().ExecuteSql(sql);
                MessageBox.Show("密码修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("原密码输入不正确");
            }
        }
    }
}
