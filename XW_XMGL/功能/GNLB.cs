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
using XW_XMGL.Bussiness;

namespace XW_XMGL
{
    public partial class GNLB : Form
    {
        public GNLB()
        {

            InitializeComponent();
        }

        private ComboBox cmb_Temp = new ComboBox();
        /// <summary>
        /// 绑定系统下拉框
        /// </summary>
        private void BindXT()
        {
            DataTable dtXT = new DataTable();
            string sql = "select XTDM from PMP000301";
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            dtXT = loSqlHelperXhf.ExecuteDataTable(sql);
            cmb_Temp.ValueMember = "XTDM";
            //cmb_Temp.DisplayMember = "Name";
            cmb_Temp.DataSource = dtXT;
            cmb_Temp.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //private string code = null;
        //private string name = null;
        //private string zygn = null;
        //private string pt = null;
        //private string lx = null;
        //private string createDate = null;
        //private string cjyh = null;
        //private string updateDate = null;
        //private string gxyh = null;
        //private string xt = null;

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            GNLBEntity gnlb = new GNLBEntity();
            string lsSql;
            StringBuilder sql = new StringBuilder();
            gnlb.code = tbCode.Text.Trim();
            gnlb.name = tbName.Text.Trim();
            gnlb.zygn = tbZYGN.Text.Trim();
            gnlb.pt = tbPT.Text.Trim();
            gnlb.xt = cbTX.Text.Trim();
            //createDate = tbCode.Text.Trim();
            //cjyh = tbCode.Text.Trim();
            //updateDate = tbCode.Text.Trim();
            gnlb.gxyh = tbGXYH.Text.Trim();
            sql.Append("Select t10.XT,t10.Code,t10.Name,t10.ZYGN,t10.PT,t10.LX,t10.CreateDate,t10.CJYH,t10.UpdateDate,t10.GXYH from PMP000101 t10 where 1=1 ");
            //lsSql = "Select t10.XT,t10.Code,t10.Name,t10.ZYGN,t10.PT,t10.LX,t10.CreateDate,t10.CJYH,t10.UpdateDate,t10.GXYH from PMP000101 t10";
            if (!string.IsNullOrEmpty(gnlb.code))
                sql.Append(" and Code like '%" + gnlb.code + "%'");
            if (!string.IsNullOrEmpty(gnlb.name))
                sql.Append(" and Name like '%" + gnlb.name + "%'");
            if (!string.IsNullOrEmpty(gnlb.zygn))
                sql.Append(" and ZYGN like '%" + gnlb.zygn + "%'");
            if (!string.IsNullOrEmpty(gnlb.pt))
                sql.Append(" and PT like '%" + gnlb.pt + "%'");
            if (!string.IsNullOrEmpty(gnlb.createDate))
                sql.Append(" and CreateDate like '%" + gnlb.createDate + "%'");
            if (!string.IsNullOrEmpty(gnlb.gxyh))
                sql.Append(" and GXYH like '%" + gnlb.gxyh + "%'");
            if (!string.IsNullOrEmpty(gnlb.xt))
                sql.Append(" and GXYH like '%" + gnlb.xt + "%'");
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            lsSql = sql.ToString();
            DataTable loDt = loSqlHelperXhf.ExecuteDataTable(lsSql);

            dataGridView1.Columns["XT"].DataPropertyName = "XT";
            dataGridView1.Columns["Code"].DataPropertyName = "Code";
            dataGridView1.Columns["U_Name"].DataPropertyName = "Name";
            dataGridView1.Columns["ZYGN"].DataPropertyName = "ZYGN";
            dataGridView1.Columns["PT"].DataPropertyName = "PT";
            dataGridView1.Columns["GNLX"].DataPropertyName = "LX";
            dataGridView1.Columns["CreateDate"].DataPropertyName = "CreateDate";
            dataGridView1.Columns["CJYH"].DataPropertyName = "CJYH";
            dataGridView1.Columns["UpdateDate"].DataPropertyName = "UpdateDate";
            dataGridView1.Columns["GXYH"].DataPropertyName = "GXYH";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = loDt;
        }

        //保存
        private void button2_Click(object sender, EventArgs e)
        {
            GNLBEntity gnlb = new GNLBEntity();
            string lsSql = string.Empty;
            StringBuilder loString = new StringBuilder();
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["SC"].Value == null)  //第一次 都是null
                    {
                        dataGridView1.Rows[i].Cells["SC"].Value = "0";

                    }
                    if (dataGridView1.Rows[i].Cells["SC"].Value.ToString() == "1")
                    {
                        gnlb.code = dataGridView1.Rows[i].Cells["Code"].Value.ToString();
                        gnlb.name = dataGridView1.Rows[i].Cells["U_Name"].Value.ToString();
                        gnlb.zygn = dataGridView1.Rows[i].Cells["ZYGN"].Value.ToString();
                        gnlb.xt = dataGridView1.Rows[i].Cells["XT"].Value.ToString();
                        gnlb.pt = dataGridView1.Rows[i].Cells["PT"].Value.ToString();
                        gnlb.lx = dataGridView1.Rows[i].Cells["GNLX"].Value.ToString();
                        gnlb.createDate = dataGridView1.Rows[i].Cells["CreateDate"].Value.ToString();
                        gnlb.cjyh = dataGridView1.Rows[i].Cells["CJYH"].Value.ToString();
                        gnlb.gxyh = dataGridView1.Rows[i].Cells["GXYH"].Value.ToString();
                        if (string.IsNullOrEmpty(gnlb.code))
                        {
                            throw new Exception("功能代码不能为空");
                        }
                        if (string.IsNullOrEmpty(gnlb.name))
                        {
                            throw new Exception("功能名称不能为空");
                        }
                        if (string.IsNullOrEmpty(gnlb.pt))
                        {
                            throw new Exception("平台不能为空");
                        }
                        if (string.IsNullOrEmpty(gnlb.cjyh))
                        {
                            throw new Exception("创建用户不能为空");
                        }
                        string sql = "Select count(*) from PMP000101 t10 where Code='" + gnlb.code + "' ";
                        SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);

                        if (Convert.ToInt32(loSqlHelperXhf.ExecuteScalar(sql)) == 0)
                        {
                            lsSql =@"Insert into PMP000101(Code,Name,XT,ZYGN,PT,LX,CreateDate,UpdateDate,CJYH,GXYH) values
                          （'" + gnlb.code + "','" + gnlb.name + "','" + gnlb.xt + "','" + gnlb.zygn + "','" + gnlb.pt + "','" + gnlb.lx + "','" + System.DateTime.Now + "','','" + gnlb.cjyh + "','" + gnlb.gxyh + "')";
                        }
                        else
                        {

                            lsSql = "update PMP000101 set Name='" + gnlb.name + "',XT='" + gnlb.xt + "',ZYGN='" + gnlb.zygn + "',PT='" + gnlb.pt + "',LX='" + gnlb.lx + "',CreateDate='" + gnlb.createDate + "',UpdateDate='" + System.DateTime.Now + "',CJYH='" + gnlb.cjyh + "',GXYH='" + gnlb.gxyh + "' where Code='" + gnlb.code + "' ";
                        }

                        loString.AppendLine(lsSql);
                    }

                }
                lsSql = loString.ToString();
                if (!string.IsNullOrEmpty(lsSql))
                {
                    SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
                    loSqlHelperXhf.ExecuteNonQuery(lsSql);
                }
                else
                {
                    MessageBox.Show("没有任何选中数据！");
                }
                button1_Click(null, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //删除2016-12-19
        private void button3_Click(object sender, EventArgs e)
        {
            //List<string> list = new List<string>();
            string code = string.Empty;
            string lsSql = string.Empty;
            StringBuilder loString = new StringBuilder();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["SC"].Value == null)  //第一次 都是null
                {
                    dataGridView1.Rows[i].Cells["SC"].Value = "0";

                }
                if (dataGridView1.Rows[i].Cells["SC"].Value.ToString() == "1")
                {
                    //MessageBox.Show(dataGridView1.Rows[i].Cells["Code"].Value.ToString());
                    code = dataGridView1.Rows[i].Cells["Code"].Value.ToString();
                    //list.Add(code);
                    lsSql = "Delete PMP000101 where Code='" + code + "' ";
                    loString.AppendLine(lsSql);
                }

            }

            lsSql = loString.ToString();
            if (!string.IsNullOrEmpty(lsSql))
            {
                SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
                loSqlHelperXhf.ExecuteNonQuery(lsSql);
            }
            else
            {
                MessageBox.Show("没有任何选中数据！");
            }
            button1_Click(null, null);
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private int rowIndex = 0;
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private SqlConnection GetConnection()
        {
            SqlConnection mycon = new SqlConnection(Comm.ConnStringFrom);
            return mycon;
        }
        private void dgvBing()
        {
            SqlConnection mycon = GetConnection();
            try
            {
                mycon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from PMP000101",mycon);
                DataTable table = new DataTable();
                sda.Fill(table);
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = table;
                this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mycon.Close();
            }
            
        }

        private void GNLB_Load(object sender, EventArgs e)
        {
            //dgvBing();
            BindXT();
            // 设置下拉列表框不可见
            cmb_Temp.Visible = false;
            // 添加下拉列表框事件
            cmb_Temp.SelectedIndexChanged += new EventHandler(cmb_Temp_SelectedIndexChanged);

            // 将下拉列表框加入到DataGridView控件中
            this.dataGridView1.Controls.Add(cmb_Temp);


        }
        // 当用户选择下拉列表框时改变DataGridView单元格的内容
        private void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = ((ComboBox)sender).Text;
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[a].Cells["SC"].Value = 1;
        }

        // 绑定数据表后将性别列中的每一单元格的Value和Tag属性（Tag为值文本，Value为显示文本）
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[1].ColumnIndex == 1)
                {
                    dataGridView1.Rows[i].Cells[1].Tag = dataGridView1.Rows[i].Cells[1].Value.ToString();
                }
            }
        }
  

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            GNZSJ gnln = new GNZSJ();
            gnln.code = dataGridView1.Rows[a].Cells["Code"].Value.ToString();
            //gnln.name = dataGridView1.Rows[a].Cells["U_Name"].Value.ToString();
            //gnln.zygn = dataGridView1.Rows[a].Cells["ZYGN"].Value.ToString();
            //gnln.pt = dataGridView1.Rows[a].Cells["PT"].Value.ToString();
            //gnln.lx = dataGridView1.Rows[a].Cells["LX"].Value.ToString();
            //gnln.gnlx = dataGridView1.Rows[a].Cells["LX"].Value.ToString();
            gnln.ShowGNZSJ();
            gnln.Show();

        }

        
        //编辑单元格获取当前行
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[a].Cells["SC"].Value = 1;
        }

        // 滚动DataGridView时将下拉列表框设为不可见
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }

        // 改变DataGridView列宽时将下拉列表框设为不可见
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmb_Temp.Visible = false;
        }

        // 当用户移动到性别这一列时单元格显示下拉列表框
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    cmb_Temp.Left = rect.Left;
                    cmb_Temp.Top = rect.Top;
                    cmb_Temp.Width = rect.Width;
                    cmb_Temp.Height = rect.Height;
                    cmb_Temp.Visible = true;
                }
                else
                {
                    cmb_Temp.Visible = false;
                }
            }
            catch
            {
            }
        }
    }
}
