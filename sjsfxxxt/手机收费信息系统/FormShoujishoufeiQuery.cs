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
    public partial class FormShoujishoufeiQuery : Form
    {
        public FormShoujishoufeiQuery()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
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
            
        }

        private void FormDengluList_Load(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
