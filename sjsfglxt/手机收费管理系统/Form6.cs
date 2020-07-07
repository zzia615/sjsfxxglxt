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
    public partial class Form6 : Form
    {
        private readonly int id;

        public Form6()
        {
            InitializeComponent();
        }
        public Form6(int id)
        {
            InitializeComponent();
            this.id = id;
            string sql = "select * from sjsfgl where id=" + id.ToString();
            DataTable table = new SqlServerHelper().QuerySqlDataTable(sql);
            if (table.Count() > 0)
            {
                DataRow row = table.Rows[0];
                textBox1.Text = row["mc"].AsString();
                textBox2.Text = row["xh"].AsString();
                textBox3.Text = row["sfy"].AsString();
                dateTimePicker1.Value = row["sfrq"].AsDatetime();
                numericUpDown1.Value = row["sl"].AsDecimal();
                numericUpDown2.Value = row["dj"].AsDecimal();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string mc = textBox1.Text;
            string xh = textBox2.Text;
            string sfy = textBox3.Text;
            DateTime sfrq = dateTimePicker1.Value;
            decimal sl = numericUpDown1.Value;
            decimal dj = numericUpDown2.Value;
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


            string sql = "insert into sjsfgl(mc,xh,sfrq,sl,dj,sfy)values(@mc,@xh,@sfrq,@sl,@dj,@sfy)";
            if (id > 0)
            {
                sql = "update sjsfgl set mc=@mc,xh=@xh," +
                    "sfrq=@sfrq,sl=@sl,dj=@dj,sfy=@sfy " +
                    " where id=@id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id",id),
                new SqlParameter("@mc",mc),
                new SqlParameter("@xh",xh),
                new SqlParameter("@sfrq",sfrq),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dj",dj),
                new SqlParameter("@sfy",sfy)
                };
                new SqlServerHelper().ExecuteSql(sql, parameters);
            }
            else
            {

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@mc",mc),
                new SqlParameter("@xh",xh),
                new SqlParameter("@sfrq",sfrq),
                new SqlParameter("@sl",sl),
                new SqlParameter("@dj",dj),
                new SqlParameter("@sfy",sfy)
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

            DialogResult = DialogResult.OK;
        }
    }
}
