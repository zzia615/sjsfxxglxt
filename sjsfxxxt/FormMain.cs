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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormChangePwd().ShowDialog();
        }

        private void 用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDengluList form = new FormDengluList();
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }

        private void 手机信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShoujishoufeiList form = new FormShoujishoufeiList();
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }

        private void 手机收费信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormShoujishoufeiQuery form = new FormShoujishoufeiQuery();
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = this;
            form.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
