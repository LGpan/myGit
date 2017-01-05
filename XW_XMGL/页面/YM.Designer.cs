namespace XW_XMGL
{
    partial class YM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.XT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YMDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YMLJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YMGNMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XT,
            this.GN,
            this.GNMC,
            this.YMDM,
            this.YMLJ,
            this.YMGNMS});
            this.dataGridView1.Location = new System.Drawing.Point(1, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(650, 228);
            this.dataGridView1.TabIndex = 0;
            // 
            // XT
            // 
            this.XT.HeaderText = "系统";
            this.XT.Name = "XT";
            // 
            // GN
            // 
            this.GN.HeaderText = "功能";
            this.GN.Name = "GN";
            // 
            // GNMC
            // 
            this.GNMC.HeaderText = "功能名称";
            this.GNMC.Name = "GNMC";
            // 
            // YMDM
            // 
            this.YMDM.HeaderText = "页面代码";
            this.YMDM.Name = "YMDM";
            // 
            // YMLJ
            // 
            this.YMLJ.HeaderText = "页面路径";
            this.YMLJ.Name = "YMLJ";
            // 
            // YMGNMS
            // 
            this.YMGNMS.HeaderText = "页面功能描述";
            this.YMGNMS.Name = "YMGNMS";
            // 
            // YM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 313);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "YM";
            this.Text = "YM";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn XT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn YMDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn YMLJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn YMGNMS;
    }
}