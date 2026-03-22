namespace Client.Forms
{
    partial class FrmSmestajnaJedinica
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
            lblNaziv = new Label();
            lblOsnovnaVrstaUsluge = new Label();
            lblCenaPoOsobi = new Label();
            lblProcenatPovecanjaPoUsluzi = new Label();
            lblTip = new Label();
            cmbTip = new ComboBox();
            txtNaziv = new TextBox();
            cmbOsnovnaVrstaUsluge = new ComboBox();
            btnKreirajSJ = new Button();
            btnPromeniSJ = new Button();
            numericCenaPoOsobi = new NumericUpDown();
            numericPovecanjeCenePoUsluzi = new NumericUpDown();
            btnObrisiSJ = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCenaPoOsobi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPovecanjeCenePoUsluzi).BeginInit();
            SuspendLayout();
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(143, 139);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(99, 20);
            lblNaziv.TabIndex = 0;
            lblNaziv.Text = "naziv jedinice";
            // 
            // lblOsnovnaVrstaUsluge
            // 
            lblOsnovnaVrstaUsluge.Location = new Point(143, 210);
            lblOsnovnaVrstaUsluge.Name = "lblOsnovnaVrstaUsluge";
            lblOsnovnaVrstaUsluge.Size = new Size(99, 48);
            lblOsnovnaVrstaUsluge.TabIndex = 1;
            lblOsnovnaVrstaUsluge.Text = "osnovna vrsta usluge";
            lblOsnovnaVrstaUsluge.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCenaPoOsobi
            // 
            lblCenaPoOsobi.Location = new Point(118, 293);
            lblCenaPoOsobi.Name = "lblCenaPoOsobi";
            lblCenaPoOsobi.Size = new Size(146, 49);
            lblCenaPoOsobi.TabIndex = 2;
            lblCenaPoOsobi.Text = "cena osnovne usluge po osobi";
            lblCenaPoOsobi.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblProcenatPovecanjaPoUsluzi
            // 
            lblProcenatPovecanjaPoUsluzi.Location = new Point(118, 383);
            lblProcenatPovecanjaPoUsluzi.Name = "lblProcenatPovecanjaPoUsluzi";
            lblProcenatPovecanjaPoUsluzi.Size = new Size(146, 46);
            lblProcenatPovecanjaPoUsluzi.TabIndex = 3;
            lblProcenatPovecanjaPoUsluzi.Text = "povecanje cene po nivou usluge";
            lblProcenatPovecanjaPoUsluzi.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTip
            // 
            lblTip.AutoSize = true;
            lblTip.Location = new Point(143, 54);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(89, 20);
            lblTip.TabIndex = 4;
            lblTip.Text = "tip smestaja";
            // 
            // cmbTip
            // 
            cmbTip.FormattingEnabled = true;
            cmbTip.Location = new Point(356, 51);
            cmbTip.Name = "cmbTip";
            cmbTip.Size = new Size(251, 28);
            cmbTip.TabIndex = 5;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(356, 136);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(251, 27);
            txtNaziv.TabIndex = 6;
            // 
            // cmbOsnovnaVrstaUsluge
            // 
            cmbOsnovnaVrstaUsluge.FormattingEnabled = true;
            cmbOsnovnaVrstaUsluge.Location = new Point(356, 221);
            cmbOsnovnaVrstaUsluge.Name = "cmbOsnovnaVrstaUsluge";
            cmbOsnovnaVrstaUsluge.Size = new Size(251, 28);
            cmbOsnovnaVrstaUsluge.TabIndex = 9;
            // 
            // btnKreirajSJ
            // 
            btnKreirajSJ.Location = new Point(425, 456);
            btnKreirajSJ.Name = "btnKreirajSJ";
            btnKreirajSJ.Size = new Size(100, 40);
            btnKreirajSJ.TabIndex = 10;
            btnKreirajSJ.Text = "sacuvaj";
            btnKreirajSJ.UseVisualStyleBackColor = true;
            btnKreirajSJ.Click += btnKreirajSJ_Click;
            // 
            // btnPromeniSJ
            // 
            btnPromeniSJ.Location = new Point(426, 502);
            btnPromeniSJ.Name = "btnPromeniSJ";
            btnPromeniSJ.Size = new Size(99, 40);
            btnPromeniSJ.TabIndex = 11;
            btnPromeniSJ.Text = "izmeni";
            btnPromeniSJ.UseVisualStyleBackColor = true;
            btnPromeniSJ.Click += btnPromeniSJ_Click;
            // 
            // numericCenaPoOsobi
            // 
            numericCenaPoOsobi.DecimalPlaces = 2;
            numericCenaPoOsobi.Location = new Point(356, 303);
            numericCenaPoOsobi.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericCenaPoOsobi.Name = "numericCenaPoOsobi";
            numericCenaPoOsobi.Size = new Size(251, 27);
            numericCenaPoOsobi.TabIndex = 12;
            // 
            // numericPovecanjeCenePoUsluzi
            // 
            numericPovecanjeCenePoUsluzi.DecimalPlaces = 2;
            numericPovecanjeCenePoUsluzi.Location = new Point(356, 392);
            numericPovecanjeCenePoUsluzi.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericPovecanjeCenePoUsluzi.Name = "numericPovecanjeCenePoUsluzi";
            numericPovecanjeCenePoUsluzi.Size = new Size(251, 27);
            numericPovecanjeCenePoUsluzi.TabIndex = 13;
            // 
            // btnObrisiSJ
            // 
            btnObrisiSJ.Location = new Point(558, 502);
            btnObrisiSJ.Name = "btnObrisiSJ";
            btnObrisiSJ.Size = new Size(94, 40);
            btnObrisiSJ.TabIndex = 14;
            btnObrisiSJ.Text = "obrisi";
            btnObrisiSJ.UseVisualStyleBackColor = true;
            btnObrisiSJ.Click += btnObrisiSJ_Click;
            // 
            // FrmSmestajnaJedinica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 574);
            Controls.Add(btnObrisiSJ);
            Controls.Add(numericPovecanjeCenePoUsluzi);
            Controls.Add(numericCenaPoOsobi);
            Controls.Add(btnPromeniSJ);
            Controls.Add(btnKreirajSJ);
            Controls.Add(cmbOsnovnaVrstaUsluge);
            Controls.Add(txtNaziv);
            Controls.Add(cmbTip);
            Controls.Add(lblTip);
            Controls.Add(lblProcenatPovecanjaPoUsluzi);
            Controls.Add(lblCenaPoOsobi);
            Controls.Add(lblOsnovnaVrstaUsluge);
            Controls.Add(lblNaziv);
            Name = "FrmSmestajnaJedinica";
            Text = "Smestajna jedinica";
            FormClosing += FrmSmestajnaJedinica_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numericCenaPoOsobi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPovecanjeCenePoUsluzi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNaziv;
        private Label lblOsnovnaVrstaUsluge;
        private Label lblCenaPoOsobi;
        private Label lblProcenatPovecanjaPoUsluzi;
        private Label lblTip;
        private ComboBox cmbTip;
        private TextBox txtNaziv;
        private ComboBox cmbOsnovnaVrstaUsluge;
        private Button btnKreirajSJ;
        private Button btnPromeniSJ;
        private NumericUpDown numericCenaPoOsobi;
        private NumericUpDown numericPovecanjeCenePoUsluzi;
        private Button btnObrisiSJ;

        public ComboBox CmbTip {  get => cmbTip; set => cmbTip = value; }
        public TextBox TxtNaziv { get => txtNaziv; set => txtNaziv = value; }
        public ComboBox CmbOsnovnaVrstaUsluge { get => cmbOsnovnaVrstaUsluge; set => cmbOsnovnaVrstaUsluge = value; }
        public Button BtnKreirajSJ {  get => btnKreirajSJ; }
        public Button BtnPromeniSJ { get => btnPromeniSJ; }
        public Button BtnObrisiSJ { get => btnObrisiSJ; }
        public NumericUpDown NumericCenaPoOsobi {  get => numericCenaPoOsobi;}
        public NumericUpDown NumericPovecanjePoUsluzi { get => numericPovecanjeCenePoUsluzi; }
    }
}