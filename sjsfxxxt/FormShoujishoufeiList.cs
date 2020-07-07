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
    public partial class FormShoujishoufeiList : Form
    {
        public FormShoujishoufeiList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
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

            string sql = "delete from shoujishoufei where id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",rv["id"].AsInt())
            };
            new SqlServerHelper().ExecuteSql(sql, parameters);

            MessageBox.Show("删除手机收费信息成功");

            button4_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mc = textBox1.Text;
            string xh = textBox2.Text;
            DateTime jhrq = dateTimePicker1.Value;
            decimal sl = numericUpDown1.Value;
            decimal dj = numericUpDown2.Value;
            int id = textBox3.Text.AsInt();
            if (string.IsNullOrEmpty(mc))
            {
                MessageBox.Show("手机不能为空");
                return;
            }
            if (string.IsNullOrEmpty(xh))
            {
                MessageBox.Show("型号不能为空");
                return;
            }
        

            string sql = "insert into shoujishoufei(mc,xh,jhrq,sl,dj)values(@mc,@xh,@jhrq,@sl,@dj)";
            if (id>0)
            {
                sql = "update shoujishoufei set mc=@mc,xh=@xh," +
                    "jhrq=@jhrq,sl=@sl,dj=@dj " +
                    " where id=@id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id",id),
                new SqlParameter("@mc",mc),
                new SqlParameter("@xh",xh),
                new SqlParameter("@jhrq",jhrq),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dj",dj)
                };
                new SqlServerHelper().ExecuteSql(sql, parameters);
            }
            else
            {

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@mc",mc),
                new SqlParameter("@xh",xh),
                new SqlParameter("@jhrq",jhrq),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dj",dj)
                };
                new SqlServerHelper().ExecuteSql(sql, parameters);
            }
            if (textBox1.Enabled)
            {
                MessageBox.Show("新增手机收费信息成功");
            }
            else
            {
                MessageBox.Show("修改手机收费信息成功");
            }
            button4_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mc = textBox4.Text;
            string xh = textBox5.Text;
            string sql = "select * from shoujishoufei where 1=1";
            if (!string.IsNullOrEmpty(mc))
            {
                sql += " and mc like'%" + mc + "%'";
            }
            if (!string.IsNullOrEmpty(xh))
            {
                sql += " and xh like'%" + xh + "%'";
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
            textBox1.Text = rv["mc"].AsString();
            textBox2.Text = rv["xh"].AsString();
            textBox3.Text = rv["id"].AsString();
            dateTimePicker1.Value = rv["jhrq"].AsDatetime();
            numericUpDown1.Value = rv["sl"].AsDecimal();
            numericUpDown2.Value = rv["dj"].AsDecimal();
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
