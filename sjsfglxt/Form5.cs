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

namespace sjsfglxt
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要删除的数据");
                return;
            }

            DialogResult dr = MessageBox.Show("是否删除所选数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr!= DialogResult.Yes)
            {
                return;
            }

            DataRowView rv = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView);

            string sql = "delete from sjsfgl where id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",rv["id"].AsInt())
            };
            new SqlServerHelper().ExecuteSql(sql, parameters);

            MessageBox.Show("删除手机收费信息成功");

            button4_Click(null, null);
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            string mc = textBox4.Text;
            string xh = textBox5.Text;
            string sql = "select * from sjsfgl where 1=1";
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
        }

        private void FormDengluList_Load(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要修改的数据");
                return;
            }

            DataRowView rv = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView);
            int id = rv["id"].AsInt();

            Form6 form = new Form6(id);
            form.StartPosition = FormStartPosition.CenterScreen;
            if(form.ShowDialog()== DialogResult.OK)
            {
                button4_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form6 form = new Form6();
            form.StartPosition = FormStartPosition.CenterScreen;
            if (form.ShowDialog() == DialogResult.OK)
            {
                button4_Click(null, null);
            }
        }
    }
}
