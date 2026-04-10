namespace Client.Forms
{
    partial class FrmStavkaEvidencije
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
            lblRezervacija = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panelIznosi = new Panel();
            btnPromeniEvidencijaRez = new Button();
            checkBoxUplacenAvans = new CheckBox();
            cmbVrstaUsluge = new ComboBox();
            numericBrOsoba = new NumericUpDown();
            numericDanOdlaska = new NumericUpDown();
            numericDanDolaska = new NumericUpDown();
            groupBoxKorisnik = new GroupBox();
            cmbMesecOdlaska = new ComboBox();
            txtMesecDolaska = new TextBox();
            groupBox1 = new GroupBox();
            maskedTxtBrLicneKarte = new MaskedTextBox();
            btnPretraziKorisnik = new Button();
            label5 = new Label();
            txtBrTel = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtKorisnik = new TextBox();
            txtEmail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDanOdlaska).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDanDolaska).BeginInit();
            groupBoxKorisnik.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblRezervacija
            // 
            lblRezervacija.Location = new Point(194, 39);
            lblRezervacija.Name = "lblRezervacija";
            lblRezervacija.Size = new Size(567, 25);
            lblRezervacija.TabIndex = 0;
            lblRezervacija.Text = "Rezervacija";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 311);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Dan dolaska";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 362);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Dan odlaska";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(559, 88);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 3;
            label3.Text = "Broj osoba";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(559, 137);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 4;
            label4.Text = "Vrsta usluge";
            // 
            // panelIznosi
            // 
            panelIznosi.Location = new Point(40, 577);
            panelIznosi.Name = "panelIznosi";
            panelIznosi.Size = new Size(888, 165);
            panelIznosi.TabIndex = 6;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(706, 369);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(148, 42);
            btnPromeniEvidencijaRez.TabIndex = 7;
            btnPromeniEvidencijaRez.Text = "Zapamti podatke";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // checkBoxUplacenAvans
            // 
            checkBoxUplacenAvans.AutoSize = true;
            checkBoxUplacenAvans.Location = new Point(667, 186);
            checkBoxUplacenAvans.Name = "checkBoxUplacenAvans";
            checkBoxUplacenAvans.Size = new Size(124, 24);
            checkBoxUplacenAvans.TabIndex = 8;
            checkBoxUplacenAvans.Text = "uplacen avans";
            checkBoxUplacenAvans.UseVisualStyleBackColor = true;
            // 
            // cmbVrstaUsluge
            // 
            cmbVrstaUsluge.FormattingEnabled = true;
            cmbVrstaUsluge.Location = new Point(667, 134);
            cmbVrstaUsluge.Name = "cmbVrstaUsluge";
            cmbVrstaUsluge.Size = new Size(150, 28);
            cmbVrstaUsluge.TabIndex = 9;
            // 
            // numericBrOsoba
            // 
            numericBrOsoba.DecimalPlaces = 1;
            numericBrOsoba.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericBrOsoba.Location = new Point(667, 86);
            numericBrOsoba.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericBrOsoba.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericBrOsoba.Name = "numericBrOsoba";
            numericBrOsoba.Size = new Size(150, 27);
            numericBrOsoba.TabIndex = 10;
            numericBrOsoba.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericDanOdlaska
            // 
            numericDanOdlaska.Location = new Point(217, 360);
            numericDanOdlaska.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericDanOdlaska.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDanOdlaska.Name = "numericDanOdlaska";
            numericDanOdlaska.Size = new Size(61, 27);
            numericDanOdlaska.TabIndex = 11;
            numericDanOdlaska.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericDanDolaska
            // 
            numericDanDolaska.Location = new Point(217, 309);
            numericDanDolaska.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericDanDolaska.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDanDolaska.Name = "numericDanDolaska";
            numericDanDolaska.Size = new Size(61, 27);
            numericDanDolaska.TabIndex = 12;
            numericDanDolaska.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBoxKorisnik
            // 
            groupBoxKorisnik.Controls.Add(cmbMesecOdlaska);
            groupBoxKorisnik.Controls.Add(txtMesecDolaska);
            groupBoxKorisnik.Controls.Add(groupBox1);
            groupBoxKorisnik.Controls.Add(btnPromeniEvidencijaRez);
            groupBoxKorisnik.Controls.Add(checkBoxUplacenAvans);
            groupBoxKorisnik.Controls.Add(numericDanDolaska);
            groupBoxKorisnik.Controls.Add(numericDanOdlaska);
            groupBoxKorisnik.Controls.Add(numericBrOsoba);
            groupBoxKorisnik.Controls.Add(cmbVrstaUsluge);
            groupBoxKorisnik.Controls.Add(label4);
            groupBoxKorisnik.Controls.Add(label3);
            groupBoxKorisnik.Controls.Add(label1);
            groupBoxKorisnik.Controls.Add(label2);
            groupBoxKorisnik.Location = new Point(40, 86);
            groupBoxKorisnik.Name = "groupBoxKorisnik";
            groupBoxKorisnik.Size = new Size(888, 446);
            groupBoxKorisnik.TabIndex = 13;
            groupBoxKorisnik.TabStop = false;
            groupBoxKorisnik.Text = "Podaci o rezervaciji";
            // 
            // cmbMesecOdlaska
            // 
            cmbMesecOdlaska.FormattingEnabled = true;
            cmbMesecOdlaska.Location = new Point(306, 362);
            cmbMesecOdlaska.Name = "cmbMesecOdlaska";
            cmbMesecOdlaska.Size = new Size(202, 28);
            cmbMesecOdlaska.TabIndex = 16;
            // 
            // txtMesecDolaska
            // 
            txtMesecDolaska.Location = new Point(306, 308);
            txtMesecDolaska.Name = "txtMesecDolaska";
            txtMesecDolaska.Size = new Size(202, 27);
            txtMesecDolaska.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(maskedTxtBrLicneKarte);
            groupBox1.Controls.Add(btnPretraziKorisnik);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtBrTel);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtKorisnik);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(25, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(514, 249);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o gostu";
            // 
            // maskedTxtBrLicneKarte
            // 
            maskedTxtBrLicneKarte.Location = new Point(220, 36);
            maskedTxtBrLicneKarte.Mask = "000000000";
            maskedTxtBrLicneKarte.Name = "maskedTxtBrLicneKarte";
            maskedTxtBrLicneKarte.Size = new Size(110, 27);
            maskedTxtBrLicneKarte.TabIndex = 2;
            maskedTxtBrLicneKarte.TextAlign = HorizontalAlignment.Center;
            // 
            // btnPretraziKorisnik
            // 
            btnPretraziKorisnik.Location = new Point(389, 36);
            btnPretraziKorisnik.Name = "btnPretraziKorisnik";
            btnPretraziKorisnik.Size = new Size(94, 29);
            btnPretraziKorisnik.TabIndex = 10;
            btnPretraziKorisnik.Text = "Pretrazi";
            btnPretraziKorisnik.UseVisualStyleBackColor = true;
            btnPretraziKorisnik.Click += btnPretraziKorisnik_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 39);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 0;
            label5.Text = "Unesi broj licne karte";
            // 
            // txtBrTel
            // 
            txtBrTel.Location = new Point(192, 185);
            txtBrTel.Name = "txtBrTel";
            txtBrTel.Size = new Size(291, 27);
            txtBrTel.TabIndex = 9;
            // 
            // label6
            // 
            label6.Location = new Point(17, 93);
            label6.Name = "label6";
            label6.Size = new Size(148, 24);
            label6.TabIndex = 4;
            label6.Text = "Gost";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(17, 138);
            label7.Name = "label7";
            label7.Size = new Size(148, 24);
            label7.TabIndex = 5;
            label7.Text = "Email";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Location = new Point(17, 186);
            label8.Name = "label8";
            label8.Size = new Size(148, 24);
            label8.TabIndex = 6;
            label8.Text = "Telefon";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtKorisnik
            // 
            txtKorisnik.Location = new Point(192, 92);
            txtKorisnik.Name = "txtKorisnik";
            txtKorisnik.Size = new Size(291, 27);
            txtKorisnik.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(192, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(291, 27);
            txtEmail.TabIndex = 8;
            // 
            // FrmStavkaEvidencije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 782);
            Controls.Add(groupBoxKorisnik);
            Controls.Add(lblRezervacija);
            Controls.Add(panelIznosi);
            Name = "FrmStavkaEvidencije";
            Text = "Rezervacija";
            FormClosing += FrmStavkaEvidencije_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDanOdlaska).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDanDolaska).EndInit();
            groupBoxKorisnik.ResumeLayout(false);
            groupBoxKorisnik.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblRezervacija;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panelIznosi;
        private Button btnPromeniEvidencijaRez;
        private CheckBox checkBoxUplacenAvans;
        private ComboBox cmbVrstaUsluge;
        private NumericUpDown numericBrOsoba;
        private NumericUpDown numericDanOdlaska;
        private NumericUpDown numericDanDolaska;
        private GroupBox groupBoxKorisnik;
        private Label label8;
        private Label label7;
        private Label label6;
        private MaskedTextBox maskedTxtBrLicneKarte;
        private Label label5;
        private TextBox txtBrTel;
        private TextBox txtEmail;
        private TextBox txtKorisnik;
        private Button btnPretraziKorisnik;
        private GroupBox groupBox1;
        private ComboBox cmbMesecOdlaska;
        private TextBox txtMesecDolaska;

        public Label LblRezervacija { get => lblRezervacija; set => lblRezervacija = value; }
        public Panel PanelIznosi { get => panelIznosi; set => panelIznosi = value;}
        public CheckBox CheckBoxUplacenAvans { get => checkBoxUplacenAvans; set => checkBoxUplacenAvans = value; }
        public ComboBox CmbVrstaUsluge { get => cmbVrstaUsluge; set => cmbVrstaUsluge = value; }
        public ComboBox CmbMesecOdlaska { get => cmbMesecOdlaska; set => cmbMesecOdlaska = value; }
        public NumericUpDown NumericBrOsoba { get => numericBrOsoba; set => numericBrOsoba = value;}
        public NumericUpDown NumericDanDolaska { get => numericDanDolaska; set => numericDanDolaska = value;}
        public NumericUpDown NumericDanOdlaska { get => numericDanOdlaska; set => numericDanOdlaska = value;}
        public MaskedTextBox MaskedTxtBrLicneKarte { get => maskedTxtBrLicneKarte; set => maskedTxtBrLicneKarte = value; }
        public TextBox TxtKorisnik { get => txtKorisnik; set => txtKorisnik = value;     }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public TextBox TxtBrTel { get =>  txtBrTel; set => txtBrTel = value; }
        public TextBox TxtMesecDolaska { get => txtMesecDolaska; set => txtMesecDolaska = value; }
        public Button BtnZapamtiPodatke { get => btnPromeniEvidencijaRez; set => btnPromeniEvidencijaRez = value; }

        public Button BtnPretraziKorisnik { get => btnPretraziKorisnik; set => btnPretraziKorisnik= value; }
    }
}