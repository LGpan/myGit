using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace XW_XMGL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lsPassWord, lsUserId;
            lsUserId = textBox1.Text;
            lsPassWord = textBox2.Text;
            if (!string.IsNullOrEmpty(lsUserId))
            {
                lsUserId = lsUserId.Trim();
            }
            if (string.IsNullOrEmpty(lsUserId))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (!string.IsNullOrEmpty(lsPassWord))
            {
                lsPassWord = lsPassWord.Trim();
            }
            if (string.IsNullOrEmpty(lsPassWord))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            Comm.login = this;
            Comm.isDL = true;
            //用户登陆2016-12-19 
            string lsSql;
            lsSql = "SELECT *  from PMP000201 where YHMD='" + lsUserId + "' and MM='" + lsPassWord + "'";
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            SqlDataReader rd = loSqlHelperXhf.ExecuteReader(lsSql);
            if (rd.Read())
            {
                Main loMain = new Main();
                loMain.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("用户名或密码错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            rd.Close();
        }
     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
