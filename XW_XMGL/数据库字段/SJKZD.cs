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
    public partial class SJKZD : Form
    {
        public string tb = null;
        public string xt = null;
        public string sjk = null;

        public SJKZD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void showZD()
        {
            ZDEntity zdEntity = new ZDEntity();
            tbTB.Text = tb;
            zdEntity.tb = tbTB.Text.Trim();
            StringBuilder sql = new StringBuilder();
            string lsSql = string.Empty;
            SqlHelperXhf loSqlHelperXhf = new SqlHelperXhf(Comm.ConnStringFrom);
            //gnlb.name = tbName.Text.Trim();
            //gnlb.zygn = tbZYGN.Text.Trim();
            //gnlb.pt = tbPT.Text.Trim();
            //gnlb.xt = cbXT.Text.Trim();
            sql.Append("Select t10.XT,t10.SJK,t10.TB,t10.TBMS,t10.ZD,t10.ZDMS,t10.ISKEY,t10.KJLX,,t10.SM,,t10.DATATYPE,,t10.SFWK from PMP000901 t10 where 1=1 ");
            if (!string.IsNullOrEmpty(zdEntity.tb))
            {
                sql.Append(" and TB like '%" + zdEntity.tb + "%'");
               
            }
            DataTable loDt = loSqlHelperXhf.ExecuteDataTable(lsSql);
            SJKZDGrid.Columns["jkdgXT"].DataPropertyName = "XT";
            SJKZDGrid.Columns["jkdgGN"].DataPropertyName = "GNDM";
            SJKZDGrid.Columns["jkdgGNMC"].DataPropertyName = "GNMC";
            SJKZDGrid.Columns["jkdgJKDM"].DataPropertyName = "JKDM";
            SJKZDGrid.Columns["jkgdJKMC"].DataPropertyName = "JKMC";
            SJKZDGrid.Columns["jkgdJKGNMS"].DataPropertyName = "JKGNMS";
            SJKZDGrid.Columns["resquest"].DataPropertyName = "REQUEST";
            SJKZDGrid.Columns["response"].DataPropertyName = "RESPONSE";
            SJKZDGrid.Columns["jkdgFWLJ"].DataPropertyName = "FWLJ";
            SJKZDGrid.Columns["jkdgJKDYR"].DataPropertyName = "JKDYR";
            SJKZDGrid.Columns["jkdgCZPT"].DataPropertyName = "PT";
            SJKZDGrid.AutoGenerateColumns = false;
            SJKZDGrid.DataSource = loDt;
        }
    }
}
