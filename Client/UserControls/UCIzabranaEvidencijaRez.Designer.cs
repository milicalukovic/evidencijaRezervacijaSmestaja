namespace Client.UserControls
{
    partial class UCIzabranaEvidencijaRez
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
            txtSmestajnaJedinica = new TextBox();
            txtMesec = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUkupanIznos = new TextBox();
            dgvStavke = new DataGridView();
            btnPromeniEvidencijaRez = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSmestajnaJedinica
            // 
            txtSmestajnaJedinica.Location = new Point(256, 66);
            txtSmestajnaJedinica.Name = "txtSmestajnaJedinica";
            txtSmestajnaJedinica.Size = new Size(218, 27);
            txtSmestajnaJedinica.TabIndex = 0;
            // 
            // txtMesec
            // 
            txtMesec.Location = new Point(256, 120);
            txtMesec.Name = "txtMesec";
            txtMesec.Size = new Size(218, 27);
            txtMesec.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(85, 69);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 2;
            label1.Text = "Smeštajna jedinica";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(85, 123);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 3;
            label2.Text = "Period evidencije";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(496, 95);
            label3.Name = "label3";
            label3.Size = new Size(182, 20);
            label3.TabIndex = 4;
            label3.Text = "Ukupan iznos rezervacija";
            // 
            // txtUkupanIznos
            // 
            txtUkupanIznos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUkupanIznos.Location = new Point(694, 92);
            txtUkupanIznos.Name = "txtUkupanIznos";
            txtUkupanIznos.Size = new Size(218, 27);
            txtUkupanIznos.TabIndex = 5;
            // 
            // dgvStavke
            // 
            dgvStavke.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStavke.BackgroundColor = SystemColors.Window;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new Point(60, 65);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(941, 221);
            dgvStavke.TabIndex = 6;
            dgvStavke.DataError += dgvStavke_DataError;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPromeniEvidencijaRez.Location = new Point(970, 81);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(130, 48);
            btnPromeniEvidencijaRez.TabIndex = 8;
            btnPromeniEvidencijaRez.Text = "Izmeni evidenciju";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.AutoSize = true;
            groupBox1.BackColor = Color.Tan;
            groupBox1.Controls.Add(dgvStavke);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox1.Location = new Point(47, 166);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1053, 336);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rezervacije";
            // 
            // UCIzabranaEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Tan;
            Controls.Add(groupBox1);
            Controls.Add(btnPromeniEvidencijaRez);
            Controls.Add(txtUkupanIznos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMesec);
            Controls.Add(txtSmestajnaJedinica);
            Name = "UCIzabranaEvidencijaRez";
            Size = new Size(1164, 529);
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSmestajnaJedinica;
        private TextBox txtMesec;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUkupanIznos;
        private DataGridView dgvStavke;
        private Button btnPromeniEvidencijaRez;
        private GroupBox groupBox1;

        public TextBox TxtSmestajnaJedinica { get =>  txtSmestajnaJedinica; set => txtSmestajnaJedinica = value; }
        public TextBox TxtMesec { get => txtMesec; set => txtMesec = value; }
        public TextBox TxtUkupanIznos { get => txtUkupanIznos; set => txtUkupanIznos = value; }
        public DataGridView DgvStavke { get => dgvStavke; set => dgvStavke = value;}
    }
}
