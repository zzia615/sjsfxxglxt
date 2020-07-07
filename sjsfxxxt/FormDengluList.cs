using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace sjsfxxxt
{
    public partial class FormDengluList : Form
    {
        public FormDengluList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zh = textBox1.Text;
            string xm = textBox2.Text;
            string mm = textBox3.Text;
            if (string.IsNullOrEmpty(zh))
            {
                MessageBox.Show("账号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(xm))
            {
                MessageBox.Show("姓名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(mm))
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            string sql = "insert into denglu(zh,xm,mm)values(@zh,@xm,@mm)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@zh",zh),
                new SqlParameter("@xm",xm),
                new SqlParameter("@mm",mm)
            };
            new SqlServerHelper().ExecuteSql(sql, parameters);
            MessageBox.Show("新增登录用户成功");
            button4_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string zh = textBox4.Text;
            string sql = "select * from denglu where 1=1";
            if (!string.IsNullOrEmpty(zh))
            {
                sql += " and zh='" + zh + "'";
            }

            DataTable table = new SqlServerHelper().QuerySqlDataTable(sql);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
        }
    }
}
