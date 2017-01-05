using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XW_XMGL
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("你确定要退出吗？", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);//触发事件进行提示
            if (dr == DialogResult.No)
            {
                e.Cancel = true;//就不退了
            }
            else
            {
                e.Cancel = false;//退了
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (Comm.isDL == false)
            {
                Application.Exit();
            }

        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GNLB gnln = new GNLB();
            gnln.Show();
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            SQKB sqlb = new SQKB();
            sqlb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SJKZD sqlzd = new SJKZD();
            sqlzd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YM ym = new YM();
            ym.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JK jk = new JK();
            jk.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
