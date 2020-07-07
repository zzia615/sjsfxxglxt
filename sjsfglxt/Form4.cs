using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sjsfglxt
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string yhzh)
        {
            InitializeComponent();
            DataTable table = new SqlServerHelper().QuerySqlDataTable("select * from yhxx where yhzh='" + yhzh + "'");
            if (table.Count() > 0)
            {
                DataRow dr = table.Rows[0];
                textBox1.Text = dr["yhzh"].AsString();
                textBox2.Text = dr["yhxm"].AsString();
                textBox3.Text = dr["yhmm"].AsString();

                textBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string yhzh = textBox1.Text;
            string yhxm = textBox2.Text;
            string yhmm = textBox3.Text;
            if (string.IsNullOrEmpty(yhzh))
            {
                MessageBox.Show("账号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(yhxm))
            {
                MessageBox.Show("姓名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(yhmm))
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            string sql = "insert into yhxx(yhzh,yhxm,yhmm)values(@yhzh,@yhxm,@yhmm)";
            if (!textBox1.Enabled)
            {
                sql = "update yhxx set yhxm=@yhxm,yhmm=@yhmm where yhzh=@yhzh";
            }
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@yhzh",yhzh),
                new SqlParameter("@yhxm",yhxm),
                new SqlParameter("@yhmm",yhmm)
            };
            new SqlServerHelper().ExecuteSql(sql, parameters);
            if (textBox1.Enabled)
            {
                MessageBox.Show("新增登录用户成功");
            }
            else
            {
                MessageBox.Show("修改登录用户成功");
            }

            DialogResult = DialogResult.OK;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
