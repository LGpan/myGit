using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XW_XMGL.Bussiness;

namespace XW_XMGL
{
    public partial class GNZSJ : Form
    {
        public string code = null;
        private ComboBox cmb_Temp = new ComboBox();
        private ComboBox cmb_Temp2 = new ComboBox();
        private ComboBox cmb_Temp3 = new ComboBox();
        private ComboBox cmb_Temp4 = new ComboBox();

        public GNZSJ()
        {
            
            InitializeComponent();
            BindXT();
            BindSJKT();
            // 设置下拉列表框不可见
            cmb_Temp.Visible = false;
            cmb_Temp2.Visible = false;
            cmb_Temp3.Visible = false;
            cmb_Temp4.Visible = false;
            // 添加下拉列表框事件
            cmb_Temp.SelectedIndexChanged += new EventHandler(cmb_Temp_SelectedIndexChanged);
            cmb_Temp2.SelectedIndexChanged += new EventHandler(cmb_Temp2_SelectedIndexChanged);
            cmb_Temp3.SelectedIndexChanged += new EventHandler(cmb_Temp3_SelectedIndexChanged);
            cmb_Temp4.SelectedIndexChanged += new EventHandler(cmb_Temp4_SelectedIndexChanged);


            // 将下拉列表框加入到DataGridView控件中
            this.dataGridView1.Controls.Add(cmb_Temp);
            this.dataGridView1.Controls.Add(cmb_Temp2);
            this.dataGridView2.Controls.Add(cmb_Temp3);
            this.dataGridView3.Controls.Add(cmb_Temp4);
        }

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
            cmb_Temp3.ValueMember = "XTDM";
            cmb_Temp3.DataSource = dtXT;
            cmb_Temp3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Temp4.ValueMember = "XTDM";
            cmb_Temp4.DataSource = dtXT;
            cmb_Temp4.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        /// <summary>
        /// 绑定数据库下拉框
        /// </summary>
        private void BindSJKT()
        {
            DataTable dtXT = new DataTable();
            string sql = "select DATABASEDM from PMP000701";
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            dtXT = loSqlHelperXhf.ExecuteDataTable(sql);
            cmb_Temp2.ValueMember = "DATABASEDM";
            //cmb_Temp.DisplayMember = "Name";
            cmb_Temp2.DataSource = dtXT;
            cmb_Temp2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // 当用户选择下拉列表框时改变DataGridView单元格的内容
        private void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.CurrentCell.Value = ((ComboBox)sender).Text;
            //dataGridView1.CurrentCell.Value = cmb_Temp.Text;
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[a].Cells["Column1"].Value = 1;
            dataGridView1.Rows[a].Cells["XT"].Value = cmb_Temp.Text;
        }
        private void cmb_Temp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.CurrentCell.Value = ((ComboBox)sender).Text;
            //dataGridView1.CurrentCell.Value = cmb_Temp2.Text;
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[a].Cells["Column1"].Value = 1;
            dataGridView1.Rows[a].Cells["DataBase"].Value = cmb_Temp2.Text;
        }
        private void cmb_Temp3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dataGridView2.CurrentCell.Value = ((ComboBox)sender).Text;
            //dataGridView2.CurrentCell.Value = cmb_Temp3.Text;
            int a = dataGridView1.CurrentRow.Index;
            dataGridView2.Rows[a].Cells["Column2"].Value = 1;
            dataGridView2.Rows[a].Cells["pgdgXT"].Value = cmb_Temp3.Text;
        }
        private void cmb_Temp4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dataGridView3.CurrentCell.Value = ((ComboBox)sender).Text;
            // dataGridView3.CurrentCell.Value = cmb_Temp4.Text;
            int a = dataGridView1.CurrentRow.Index;
            dataGridView3.Rows[a].Cells["Column3"].Value = 1;
            dataGridView3.Rows[a].Cells["jkdgXT"].Value = cmb_Temp4.Text;
           
        }
        

        // 滚动DataGridView时将下拉列表框设为不可见
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmb_Temp.Visible = false;
            this.cmb_Temp2.Visible = false;
        }
        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmb_Temp3.Visible = false;
        }
        private void dataGridView3_Scroll(object sender, ScrollEventArgs e)
        {
            this.cmb_Temp4.Visible = false;
        }

        // 改变DataGridView列宽时将下拉列表框设为不可见
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmb_Temp.Visible = false;
            this.cmb_Temp2.Visible = false;
        }
        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmb_Temp3.Visible = false;
        }
        private void dataGridView3_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.cmb_Temp4.Visible = false;
        }

        // 当用户移动到这一列时单元格显示下拉列表框
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
                if (this.dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);

                    cmb_Temp2.Left = rect.Left;
                    cmb_Temp2.Top = rect.Top;
                    cmb_Temp2.Width = rect.Width;
                    cmb_Temp2.Height = rect.Height;
                    cmb_Temp2.Visible = true;
                }
                else
                {
                    cmb_Temp2.Visible = false;
                }
            }
            catch
            {
            }
        }
        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView2.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = dataGridView2.GetCellDisplayRectangle(dataGridView2.CurrentCell.ColumnIndex, dataGridView2.CurrentCell.RowIndex, false);

                    cmb_Temp3.Left = rect.Left;
                    cmb_Temp3.Top = rect.Top;
                    cmb_Temp3.Width = rect.Width;
                    cmb_Temp3.Height = rect.Height;
                    cmb_Temp3.Visible = true;
                }
                else
                {
                    cmb_Temp3.Visible = false;
                }
            }
            catch
            {
            }
        }
        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView3.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = dataGridView3.GetCellDisplayRectangle(dataGridView3.CurrentCell.ColumnIndex, dataGridView3.CurrentCell.RowIndex, false);

                    cmb_Temp4.Left = rect.Left;
                    cmb_Temp4.Top = rect.Top;
                    cmb_Temp4.Width = rect.Width;
                    cmb_Temp4.Height = rect.Height;
                    cmb_Temp4.Visible = true;
                }
                else
                {
                    cmb_Temp4.Visible = false;
                }
            }
            catch
            {
            }
        }


        public void ShowGNZSJ()
        {
            tbCode.Text = code;
            TableEntity tableEntity = new TableEntity();
            string lsSql;
            string lsSql2;
            string lsSql3;
            StringBuilder sql = new StringBuilder();
            StringBuilder sql2 = new StringBuilder();
            StringBuilder sql3 = new StringBuilder();
            tableEntity.gndm = tbCode.Text.Trim();
            //gnlb.name = tbName.Text.Trim();
            //gnlb.zygn = tbZYGN.Text.Trim();
            //gnlb.pt = tbPT.Text.Trim();
            //gnlb.xt = cbXT.Text.Trim();
            sql.Append("Select t10.XT,t10.GNDM,t10.GNMC,t10.SJK,t10.TABLENAME,t10.TB,t10.ZYGN,t10.PT from PMP000401 t10 where 1=1 ");
            sql2.Append("Select t10.XT,t10.GNDM,t10.GNMC,t10.YMDM,t10.YMLJ,t10.YMGNMS from PMP000501 t10 where 1=1 ");
            sql3.Append("Select t10.XT,t10.GNDM,t10.GNMC,t10.JKDM,t10.JKMC,t10.JKGNMS,t10.REQUEST,t10.RESPONSE,t10.FWLJ,t10.JKDYR,t10.PT from PMP000601 t10 where 1=1 ");
            //lsSql = "Select t10.XT,t10.Code,t10.Name,t10.ZYGN,t10.PT,t10.LX,t10.CreateDate,t10.CJYH,t10.UpdateDate,t10.GXYH from PMP000101 t10";
            if (!string.IsNullOrEmpty(tableEntity.gndm))
            { 
                sql.Append(" and GNDM like '%" + tableEntity.gndm + "%'");
                sql2.Append(" and GNDM like '%" + tableEntity.gndm + "%'");
                sql3.Append(" and GNDM like '%" + tableEntity.gndm + "%'");
            }
            //if (!string.IsNullOrEmpty(gnlb.name))
            //    sql.Append(" and GNMC like '%" + gnlb.name + "%'");
            //if (!string.IsNullOrEmpty(gnlb.zygn))
            //    sql.Append(" and SJK like '%" + gnlb.zygn + "%'");
            //if (!string.IsNullOrEmpty(gnlb.pt))
            //    sql.Append(" and TABLENAME like '%" + gnlb.pt + "%'");
            //if (!string.IsNullOrEmpty(gnlb.createDate))
            //    sql.Append(" and TB like '%" + gnlb.createDate + "%'");
            //if (!string.IsNullOrEmpty(gnlb.gxyh))
            //    sql.Append(" and ZYGN like '%" + gnlb.gxyh + "%'");
            //if (!string.IsNullOrEmpty(gnlb.xt))
            //    sql.Append(" and PT like '%" + gnlb.xt + "%'");
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            lsSql = sql.ToString();
            lsSql2 = sql2.ToString();
            lsSql3 = sql3.ToString();
            DataTable loDt = loSqlHelperXhf.ExecuteDataTable(lsSql);
            DataTable loDt2 = loSqlHelperXhf.ExecuteDataTable(lsSql2);
            DataTable loDt3 = loSqlHelperXhf.ExecuteDataTable(lsSql3);
            dataGridView1.Columns["XT"].DataPropertyName = "XT";
            dataGridView1.Columns["gn"].DataPropertyName = "GNDM";
            dataGridView1.Columns["GNMC"].DataPropertyName = "GNMC";
            dataGridView1.Columns["DataBase"].DataPropertyName = "SJK";
            dataGridView1.Columns["BMC"].DataPropertyName = "TABLENAME";
            dataGridView1.Columns["Table1"].DataPropertyName = "TB";
            dataGridView1.Columns["dgZYGN"].DataPropertyName = "ZYGN";
            dataGridView1.Columns["dgPT"].DataPropertyName = "PT";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = loDt;

            dataGridView2.Columns["pgdgXT"].DataPropertyName = "XT";
            dataGridView2.Columns["pgdgGN"].DataPropertyName = "GNDM";
            dataGridView2.Columns["pgdgGNMC"].DataPropertyName = "GNMC";
            dataGridView2.Columns["pgdgYMDM"].DataPropertyName = "YMDM";
            dataGridView2.Columns["pgdgYMLJ"].DataPropertyName = "YMLJ";
            dataGridView2.Columns["pgdgYMGNMS"].DataPropertyName = "YMGNMS";
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = loDt2;

            dataGridView3.Columns["jkdgXT"].DataPropertyName = "XT";
            dataGridView3.Columns["jkdgGN"].DataPropertyName = "GNDM";
            dataGridView3.Columns["jkdgGNMC"].DataPropertyName = "GNMC";
            dataGridView3.Columns["jkdgJKDM"].DataPropertyName = "JKDM";
            dataGridView3.Columns["jkgdJKMC"].DataPropertyName = "JKMC";
            dataGridView3.Columns["jkgdJKGNMS"].DataPropertyName = "JKGNMS";
            dataGridView3.Columns["resquest"].DataPropertyName = "REQUEST";
            dataGridView3.Columns["response"].DataPropertyName = "RESPONSE";
            dataGridView3.Columns["jkdgFWLJ"].DataPropertyName = "FWLJ";
            dataGridView3.Columns["jkdgJKDYR"].DataPropertyName = "JKDYR";
            dataGridView3.Columns["jkdgCZPT"].DataPropertyName = "PT";
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = loDt3;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        //双击跳到字段页面
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SJKZD sjkzd = new SJKZD();
            int a = dataGridView1.CurrentRow.Index;
            sjkzd.tb = dataGridView1.Rows[a].Cells["Table1"].Value.ToString();
            sjkzd.xt = dataGridView1.Rows[a].Cells["XT"].Value.ToString();
            sjkzd.sjk = dataGridView1.Rows[a].Cells["DataBase"].Value.ToString();
            //gnln.name = dataGridView1.Rows[a].Cells["U_Name"].Value.ToString();
            //gnln.zygn = dataGridView1.Rows[a].Cells["ZYGN"].Value.ToString();
            //gnln.pt = dataGridView1.Rows[a].Cells["PT"].Value.ToString();
            //gnln.lx = dataGridView1.Rows[a].Cells["LX"].Value.ToString();
            //gnln.gnlx = dataGridView1.Rows[a].Cells["LX"].Value.ToString();
            sjkzd.Show();
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

        //编辑单元格获取当前行
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[a].Cells["Column1"].Value = 1;
        }
        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int a = dataGridView2.CurrentRow.Index;
            dataGridView2.Rows[a].Cells["Column2"].Value = 1;
        }
        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int a = dataGridView3.CurrentRow.Index;
            dataGridView3.Rows[a].Cells["Column3"].Value = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
