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
            textBox1.Enabled = true;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            DialogResult dr = MessageBox.Show("是否删除所选数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr!= DialogResult.Yes)
            {
                return;
            }

            DataRowView rv = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView);

            string sql = "delete from denglu where zh=@zh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@zh",rv["zh"])
            };
            new SqlServerHelper().ExecuteSql(sql, parameters);

            MessageBox.Show("删除登录用户成功");

            button4_Click(null, null);
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
            if (!textBox1.Enabled)
            {
                sql = "update denglu set xm=@xm,mm=@mm where zh=@zh";
            }
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@zh",zh),
                new SqlParameter("@xm",xm),
                new SqlParameter("@mm",mm)
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
            button4_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string zh = textBox4.Text;
            string sql = "select * from denglu where 1=1";
            if (!string.IsNullOrEmpty(zh))
            {
                sql += " and zh like'%" + zh + "%'";
            }

            DataTable table = new SqlServerHelper().QuerySqlDataTable(sql);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
            if (table.Count() <=0)
            {
                button1_Click(null, null);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            DataRowView rv = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView);
            textBox1.Text = rv["zh"].AsString();
            textBox2.Text = rv["xm"].AsString();
            textBox3.Text = rv["mm"].AsString();

            textBox1.Enabled = false;
        }

        private void FormDengluList_Load(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_SelectionChanged(null, null);
        }
    }
}
