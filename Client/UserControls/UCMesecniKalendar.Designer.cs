namespace Client.UserControls
{
    partial class UCMesecniKalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMesec = new Label();
            tblKalendar = new TableLayoutPanel();
            SuspendLayout();
            // 
            // lblMesec
            // 
            lblMesec.BackColor = Color.WhiteSmoke;
            lblMesec.Dock = DockStyle.Top;
            lblMesec.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMesec.ForeColor = Color.SaddleBrown;
            lblMesec.Location = new Point(0, 0);
            lblMesec.Name = "lblMesec";
            lblMesec.Size = new Size(246, 35);
            lblMesec.TabIndex = 0;
            lblMesec.Text = "mesec";
            lblMesec.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblKalendar
            // 
            tblKalendar.BackColor = Color.White;
            tblKalendar.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblKalendar.ColumnCount = 7;
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tblKalendar.Dock = DockStyle.Fill;
            tblKalendar.Location = new Point(0, 35);
            tblKalendar.Name = "tblKalendar";
            tblKalendar.Padding = new Padding(2);
            tblKalendar.RowCount = 7;
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666111F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666111F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666111F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666111F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666111F));
            tblKalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6694412F));
            tblKalendar.Size = new Size(246, 203);
            tblKalendar.TabIndex = 1;
            // 
            // UCMesecniKalendar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tblKalendar);
            Controls.Add(lblMesec);
            Name = "UCMesecniKalendar";
            Size = new Size(246, 238);
            ResumeLayout(false);
        }

        #endregion

        private Label lblMesec;
        private TableLayoutPanel tblKalendar;

        public Label LblMesec { get { return lblMesec; }  set { lblMesec = value; } }
        public TableLayoutPanel TblKalendar { get  { return tblKalendar; } set { tblKalendar = value; }  }
    }
}
