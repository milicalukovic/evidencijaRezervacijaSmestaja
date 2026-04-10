namespace Client.UserControls
{
    partial class UCOsnovniPodaciEvidencijaRez
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
            label9 = new Label();
            numericSezonskiKoefCene = new NumericUpDown();
            numericProcenatAvansa = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            numericGodina = new NumericUpDown();
            numericMesec = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            txtMaxKapacitet = new TextBox();
            txtMinKapacitet = new TextBox();
            txtTipSmestaja = new TextBox();
            txtPovecanjeCenePoUsluzi = new TextBox();
            txtOsnovnaCenaPoOsobi = new TextBox();
            txtOsnovnaVrstaUsluge = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lblTip = new Label();
            lblProcenatPovecanjaPoUsluzi = new Label();
            lblCenaPoOsobi = new Label();
            lblOsnovnaVrstaUsluge = new Label();
            cmbSmestajnaJedinica = new ComboBox();
            btnPromeniEvidencijaRez = new Button();
            ((System.ComponentModel.ISupportInitialize)numericSezonskiKoefCene).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericProcenatAvansa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGodina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMesec).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Location = new Point(26, 138);
            label9.Name = "label9";
            label9.Size = new Size(156, 41);
            label9.TabIndex = 30;
            label9.Text = "Sezonski koeficijent promene cene";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // numericSezonskiKoefCene
            // 
            numericSezonskiKoefCene.DecimalPlaces = 2;
            numericSezonskiKoefCene.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericSezonskiKoefCene.Location = new Point(297, 152);
            numericSezonskiKoefCene.Maximum = new decimal(new int[] { 999, 0, 0, 131072 });
            numericSezonskiKoefCene.Name = "numericSezonskiKoefCene";
            numericSezonskiKoefCene.Size = new Size(150, 27);
            numericSezonskiKoefCene.TabIndex = 29;
            numericSezonskiKoefCene.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericProcenatAvansa
            // 
            numericProcenatAvansa.DecimalPlaces = 2;
            numericProcenatAvansa.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericProcenatAvansa.Location = new Point(297, 80);
            numericProcenatAvansa.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProcenatAvansa.Name = "numericProcenatAvansa";
            numericProcenatAvansa.Size = new Size(150, 27);
            numericProcenatAvansa.TabIndex = 28;
            // 
            // label7
            // 
            label7.Location = new Point(26, 85);
            label7.Name = "label7";
            label7.Size = new Size(156, 22);
            label7.TabIndex = 27;
            label7.Text = "Procenat avansa";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(409, 20);
            label6.Name = "label6";
            label6.Size = new Size(15, 20);
            label6.TabIndex = 26;
            label6.Text = "/";
            // 
            // numericGodina
            // 
            numericGodina.Location = new Point(490, 18);
            numericGodina.Maximum = new decimal(new int[] { 2036, 0, 0, 0 });
            numericGodina.Minimum = new decimal(new int[] { 2002, 0, 0, 0 });
            numericGodina.Name = "numericGodina";
            numericGodina.Size = new Size(61, 27);
            numericGodina.TabIndex = 25;
            numericGodina.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // numericMesec
            // 
            numericMesec.Location = new Point(354, 18);
            numericMesec.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericMesec.Name = "numericMesec";
            numericMesec.Size = new Size(49, 27);
            numericMesec.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(428, 20);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 23;
            label4.Text = "godina";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(297, 20);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 22;
            label5.Text = "mesec";
            // 
            // label3
            // 
            label3.Location = new Point(26, 23);
            label3.Name = "label3";
            label3.Size = new Size(156, 22);
            label3.TabIndex = 21;
            label3.Text = "Period evidencije";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMaxKapacitet);
            groupBox1.Controls.Add(txtMinKapacitet);
            groupBox1.Controls.Add(txtTipSmestaja);
            groupBox1.Controls.Add(txtPovecanjeCenePoUsluzi);
            groupBox1.Controls.Add(txtOsnovnaCenaPoOsobi);
            groupBox1.Controls.Add(txtOsnovnaVrstaUsluge);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblTip);
            groupBox1.Controls.Add(lblProcenatPovecanjaPoUsluzi);
            groupBox1.Controls.Add(lblCenaPoOsobi);
            groupBox1.Controls.Add(lblOsnovnaVrstaUsluge);
            groupBox1.Controls.Add(cmbSmestajnaJedinica);
            groupBox1.Location = new Point(26, 235);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1000, 336);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Smestajna jedinica";
            // 
            // txtMaxKapacitet
            // 
            txtMaxKapacitet.Location = new Point(712, 252);
            txtMaxKapacitet.Name = "txtMaxKapacitet";
            txtMaxKapacitet.Size = new Size(251, 27);
            txtMaxKapacitet.TabIndex = 15;
            // 
            // txtMinKapacitet
            // 
            txtMinKapacitet.Location = new Point(712, 182);
            txtMinKapacitet.Name = "txtMinKapacitet";
            txtMinKapacitet.Size = new Size(251, 27);
            txtMinKapacitet.TabIndex = 14;
            // 
            // txtTipSmestaja
            // 
            txtTipSmestaja.Location = new Point(712, 114);
            txtTipSmestaja.Name = "txtTipSmestaja";
            txtTipSmestaja.Size = new Size(251, 27);
            txtTipSmestaja.TabIndex = 13;
            // 
            // txtPovecanjeCenePoUsluzi
            // 
            txtPovecanjeCenePoUsluzi.Location = new Point(233, 252);
            txtPovecanjeCenePoUsluzi.Name = "txtPovecanjeCenePoUsluzi";
            txtPovecanjeCenePoUsluzi.Size = new Size(251, 27);
            txtPovecanjeCenePoUsluzi.TabIndex = 12;
            // 
            // txtOsnovnaCenaPoOsobi
            // 
            txtOsnovnaCenaPoOsobi.Location = new Point(233, 182);
            txtOsnovnaCenaPoOsobi.Name = "txtOsnovnaCenaPoOsobi";
            txtOsnovnaCenaPoOsobi.Size = new Size(251, 27);
            txtOsnovnaCenaPoOsobi.TabIndex = 11;
            // 
            // txtOsnovnaVrstaUsluge
            // 
            txtOsnovnaVrstaUsluge.Location = new Point(233, 114);
            txtOsnovnaVrstaUsluge.Name = "txtOsnovnaVrstaUsluge";
            txtOsnovnaVrstaUsluge.Size = new Size(251, 27);
            txtOsnovnaVrstaUsluge.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(550, 255);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 9;
            label2.Text = "maksimalni kapacitet";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(550, 185);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 8;
            label1.Text = "minimalni kapacitet";
            // 
            // lblTip
            // 
            lblTip.AutoSize = true;
            lblTip.Location = new Point(550, 117);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(89, 20);
            lblTip.TabIndex = 7;
            lblTip.Text = "tip smestaja";
            // 
            // lblProcenatPovecanjaPoUsluzi
            // 
            lblProcenatPovecanjaPoUsluzi.Location = new Point(32, 255);
            lblProcenatPovecanjaPoUsluzi.Name = "lblProcenatPovecanjaPoUsluzi";
            lblProcenatPovecanjaPoUsluzi.Size = new Size(146, 46);
            lblProcenatPovecanjaPoUsluzi.TabIndex = 6;
            lblProcenatPovecanjaPoUsluzi.Text = "povecanje cene po nivou usluge";
            lblProcenatPovecanjaPoUsluzi.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCenaPoOsobi
            // 
            lblCenaPoOsobi.Location = new Point(32, 176);
            lblCenaPoOsobi.Name = "lblCenaPoOsobi";
            lblCenaPoOsobi.Size = new Size(146, 49);
            lblCenaPoOsobi.TabIndex = 5;
            lblCenaPoOsobi.Text = "cena osnovne usluge po osobi";
            lblCenaPoOsobi.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOsnovnaVrstaUsluge
            // 
            lblOsnovnaVrstaUsluge.Location = new Point(32, 115);
            lblOsnovnaVrstaUsluge.Name = "lblOsnovnaVrstaUsluge";
            lblOsnovnaVrstaUsluge.Size = new Size(146, 22);
            lblOsnovnaVrstaUsluge.TabIndex = 4;
            lblOsnovnaVrstaUsluge.Text = "osnovna vrsta usluge";
            lblOsnovnaVrstaUsluge.TextAlign = ContentAlignment.TopCenter;
            // 
            // cmbSmestajnaJedinica
            // 
            cmbSmestajnaJedinica.FormattingEnabled = true;
            cmbSmestajnaJedinica.Location = new Point(365, 37);
            cmbSmestajnaJedinica.Name = "cmbSmestajnaJedinica";
            cmbSmestajnaJedinica.Size = new Size(251, 28);
            cmbSmestajnaJedinica.TabIndex = 0;
            cmbSmestajnaJedinica.SelectedIndexChanged += cmbSmestajnaJedinica_SelectedIndexChanged;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(821, 96);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(151, 44);
            btnPromeniEvidencijaRez.TabIndex = 19;
            btnPromeniEvidencijaRez.Text = "Zapamti podatke";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // UCOsnovniPodaciEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label9);
            Controls.Add(numericSezonskiKoefCene);
            Controls.Add(numericProcenatAvansa);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(numericGodina);
            Controls.Add(numericMesec);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(btnPromeniEvidencijaRez);
            Name = "UCOsnovniPodaciEvidencijaRez";
            Size = new Size(1052, 589);
            ((System.ComponentModel.ISupportInitialize)numericSezonskiKoefCene).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericProcenatAvansa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGodina).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMesec).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private NumericUpDown numericSezonskiKoefCene;
        private NumericUpDown numericProcenatAvansa;
        private Label label7;
        private Label label6;
        private NumericUpDown numericGodina;
        private NumericUpDown numericMesec;
        private Label label4;
        private Label label5;
        private Label label3;
        private GroupBox groupBox1;
        private TextBox txtMaxKapacitet;
        private TextBox txtMinKapacitet;
        private TextBox txtTipSmestaja;
        private TextBox txtPovecanjeCenePoUsluzi;
        private TextBox txtOsnovnaCenaPoOsobi;
        private TextBox txtOsnovnaVrstaUsluge;
        private Label label2;
        private Label label1;
        private Label lblTip;
        private Label lblProcenatPovecanjaPoUsluzi;
        private Label lblCenaPoOsobi;
        private Label lblOsnovnaVrstaUsluge;
        private ComboBox cmbSmestajnaJedinica;
        private Button btnPromeniEvidencijaRez;

        public NumericUpDown NumericSezonskiKoefCene { get => numericSezonskiKoefCene; set => numericSezonskiKoefCene = value; }
        public NumericUpDown NumericProcenatAvansa { get => numericProcenatAvansa; set => numericProcenatAvansa = value; }
        public NumericUpDown NumericGodina { get => numericGodina; set => numericGodina = value; }
        public NumericUpDown NumericMesec { get => numericMesec; set => numericMesec = value; }
        public TextBox TxtMaxKapacitet { get => txtMaxKapacitet; set => txtMaxKapacitet = value; }
        public TextBox TxtMinKapacitet { get => txtMinKapacitet; set => txtMinKapacitet = value; }
        public TextBox TxtTipSmestaja { get => txtTipSmestaja; set => txtTipSmestaja = value; }
        public TextBox TxtPovecanjeCenePoUsluzi { get => txtPovecanjeCenePoUsluzi; set => txtPovecanjeCenePoUsluzi = value; }
        public TextBox TxtOsnovnaCenaPoOsobi { get => txtOsnovnaCenaPoOsobi; set => txtOsnovnaCenaPoOsobi = value; }
        public TextBox TxtOsnovnaVrstaUsluge { get => txtOsnovnaVrstaUsluge; set => txtOsnovnaVrstaUsluge = value; }
        public ComboBox CmbSmestajnaJedinica { get => cmbSmestajnaJedinica; set => cmbSmestajnaJedinica = value; }
        public Button BtnPromeniEvidencijaRez { get => btnPromeniEvidencijaRez; set => btnPromeniEvidencijaRez = value; }
    }
}
