namespace Client.UserControls
{
    partial class UCPrikazSmestajnaJedinica
    {
        
        private System.ComponentModel.IContainer components = null;
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
            dgvSmestajnaJedinica = new DataGridView();
            btnKreirajSJ = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            cmbSmestajnaJedinica = new ComboBox();
            cmbTipSmestaja = new ComboBox();
            btnFilltrirajPrikazSJ = new Button();
            btnVratiPrikaz = new Button();
            label1 = new Label();
            label2 = new Label();
            btnPretraziSJ = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSmestajnaJedinica).BeginInit();
            SuspendLayout();
            // 
            // dgvSmestajnaJedinica
            // 
            dgvSmestajnaJedinica.BackgroundColor = SystemColors.Control;
            dgvSmestajnaJedinica.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSmestajnaJedinica.Location = new Point(34, 234);
            dgvSmestajnaJedinica.Name = "dgvSmestajnaJedinica";
            dgvSmestajnaJedinica.RowHeadersWidth = 51;
            dgvSmestajnaJedinica.Size = new Size(888, 217);
            dgvSmestajnaJedinica.TabIndex = 0;
            dgvSmestajnaJedinica.CellClick += dgvSmestajnaJedinica_CellClick;
            // 
            // btnKreirajSJ
            // 
            btnKreirajSJ.Location = new Point(758, 467);
            btnKreirajSJ.Name = "btnKreirajSJ";
            btnKreirajSJ.Size = new Size(132, 40);
            btnKreirajSJ.TabIndex = 2;
            btnKreirajSJ.Text = "dodaj novu";
            btnKreirajSJ.UseVisualStyleBackColor = true;
            btnKreirajSJ.Click += btnKreirajSJ_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(138, 80);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(170, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Osnovna vrsta usluge";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(492, 80);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(114, 24);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Tip smestaja";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // cmbSmestajnaJedinica
            // 
            cmbSmestajnaJedinica.FormattingEnabled = true;
            cmbSmestajnaJedinica.Location = new Point(94, 126);
            cmbSmestajnaJedinica.Name = "cmbSmestajnaJedinica";
            cmbSmestajnaJedinica.Size = new Size(243, 28);
            cmbSmestajnaJedinica.TabIndex = 6;
            // 
            // cmbTipSmestaja
            // 
            cmbTipSmestaja.FormattingEnabled = true;
            cmbTipSmestaja.Location = new Point(429, 126);
            cmbTipSmestaja.Name = "cmbTipSmestaja";
            cmbTipSmestaja.Size = new Size(243, 28);
            cmbTipSmestaja.TabIndex = 7;
            // 
            // btnFilltrirajPrikazSJ
            // 
            btnFilltrirajPrikazSJ.Location = new Point(579, 183);
            btnFilltrirajPrikazSJ.Name = "btnFilltrirajPrikazSJ";
            btnFilltrirajPrikazSJ.Size = new Size(94, 29);
            btnFilltrirajPrikazSJ.TabIndex = 8;
            btnFilltrirajPrikazSJ.Text = "filter";
            btnFilltrirajPrikazSJ.UseVisualStyleBackColor = true;
            btnFilltrirajPrikazSJ.Click += btnFilltrirajPrikazSJ_Click;
            // 
            // btnVratiPrikaz
            // 
            btnVratiPrikaz.Location = new Point(698, 183);
            btnVratiPrikaz.Name = "btnVratiPrikaz";
            btnVratiPrikaz.Size = new Size(94, 29);
            btnVratiPrikaz.TabIndex = 9;
            btnVratiPrikaz.Text = "restart";
            btnVratiPrikaz.UseVisualStyleBackColor = true;
            btnVratiPrikaz.Click += btnVratiPrikaz_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(54, 29);
            label1.Name = "label1";
            label1.Size = new Size(193, 20);
            label1.TabIndex = 10;
            label1.Text = "Izaberi kriterijum pretrage";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(94, 187);
            label2.Name = "label2";
            label2.Size = new Size(212, 25);
            label2.TabIndex = 11;
            label2.Text = "Vase smestajne jedinice";
            // 
            // btnPretraziSJ
            // 
            btnPretraziSJ.Location = new Point(594, 467);
            btnPretraziSJ.Name = "btnPretraziSJ";
            btnPretraziSJ.Size = new Size(133, 40);
            btnPretraziSJ.TabIndex = 12;
            btnPretraziSJ.Text = "ucitaj izabranu";
            btnPretraziSJ.UseVisualStyleBackColor = true;
            btnPretraziSJ.Click += btnPretraziSJ_Click;
            // 
            // UCPrikazSmestajnaJedinica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(btnPretraziSJ);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnVratiPrikaz);
            Controls.Add(btnFilltrirajPrikazSJ);
            Controls.Add(cmbTipSmestaja);
            Controls.Add(cmbSmestajnaJedinica);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(btnKreirajSJ);
            Controls.Add(dgvSmestajnaJedinica);
            Name = "UCPrikazSmestajnaJedinica";
            Size = new Size(953, 529);
            ((System.ComponentModel.ISupportInitialize)dgvSmestajnaJedinica).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSmestajnaJedinica;
        private Button btnKreirajSJ;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox cmbSmestajnaJedinica;
        private ComboBox cmbTipSmestaja;
        private Button btnFilltrirajPrikazSJ;
        private Button btnVratiPrikaz;
        private Label label1;
        private Label label2;
        private Button btnPretraziSJ;

        public DataGridView DgvSmestajnaJedinica { get => dgvSmestajnaJedinica; set => dgvSmestajnaJedinica = value; }
        public ComboBox CmbSmestajnaJedinica { get => cmbSmestajnaJedinica; set => cmbSmestajnaJedinica = value; }
        public ComboBox CmbTipSmestaja { get => cmbTipSmestaja; set => cmbTipSmestaja = value;}
        public CheckBox CbSmestajnaJedinica { get => checkBox1; set => checkBox1 = value; }
        public CheckBox CbTipSmestaja { get => checkBox2; set => checkBox2 = value; }
    }
}
