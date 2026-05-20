namespace Client.UserControls
{
    partial class UCPromeniStavkaEvidencijeRez
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
            panelIznosi = new Panel();
            lblRezervacija = new Label();
            groupBoxKorisnik = new GroupBox();
            dtpDatumOdlaska = new DateTimePicker();
            dtpDatumDolaska = new DateTimePicker();
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
            btnPromeniEvidencijaRez = new Button();
            checkBoxUplacenAvans = new CheckBox();
            numericBrOsoba = new NumericUpDown();
            cmbVrstaUsluge = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnOdustani = new Button();
            groupBoxKorisnik.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).BeginInit();
            SuspendLayout();
            // 
            // panelIznosi
            // 
            panelIznosi.Location = new Point(132, 350);
            panelIznosi.Name = "panelIznosi";
            panelIznosi.Size = new Size(888, 165);
            panelIznosi.TabIndex = 7;
            // 
            // lblRezervacija
            // 
            lblRezervacija.Location = new Point(293, 18);
            lblRezervacija.Name = "lblRezervacija";
            lblRezervacija.Size = new Size(567, 25);
            lblRezervacija.TabIndex = 8;
            lblRezervacija.Text = "Rezervacija";
            // 
            // groupBoxKorisnik
            // 
            groupBoxKorisnik.Controls.Add(dtpDatumOdlaska);
            groupBoxKorisnik.Controls.Add(dtpDatumDolaska);
            groupBoxKorisnik.Controls.Add(groupBox1);
            groupBoxKorisnik.Controls.Add(btnPromeniEvidencijaRez);
            groupBoxKorisnik.Controls.Add(checkBoxUplacenAvans);
            groupBoxKorisnik.Controls.Add(numericBrOsoba);
            groupBoxKorisnik.Controls.Add(cmbVrstaUsluge);
            groupBoxKorisnik.Controls.Add(label4);
            groupBoxKorisnik.Controls.Add(label3);
            groupBoxKorisnik.Controls.Add(label1);
            groupBoxKorisnik.Controls.Add(label2);
            groupBoxKorisnik.Location = new Point(18, 41);
            groupBoxKorisnik.Name = "groupBoxKorisnik";
            groupBoxKorisnik.Size = new Size(1128, 303);
            groupBoxKorisnik.TabIndex = 14;
            groupBoxKorisnik.TabStop = false;
            groupBoxKorisnik.Text = "Podaci o rezervaciji";
            // 
            // dtpDatumOdlaska
            // 
            dtpDatumOdlaska.Location = new Point(633, 133);
            dtpDatumOdlaska.Name = "dtpDatumOdlaska";
            dtpDatumOdlaska.Size = new Size(291, 27);
            dtpDatumOdlaska.TabIndex = 18;
            // 
            // dtpDatumDolaska
            // 
            dtpDatumDolaska.Location = new Point(633, 82);
            dtpDatumDolaska.Name = "dtpDatumDolaska";
            dtpDatumDolaska.Size = new Size(291, 27);
            dtpDatumDolaska.TabIndex = 17;
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
            groupBox1.Location = new Point(17, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 226);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o gostu";
            // 
            // maskedTxtBrLicneKarte
            // 
            maskedTxtBrLicneKarte.Location = new Point(192, 36);
            maskedTxtBrLicneKarte.Mask = "000000000";
            maskedTxtBrLicneKarte.Name = "maskedTxtBrLicneKarte";
            maskedTxtBrLicneKarte.Size = new Size(134, 27);
            maskedTxtBrLicneKarte.TabIndex = 2;
            maskedTxtBrLicneKarte.TextAlign = HorizontalAlignment.Center;
            // 
            // btnPretraziKorisnik
            // 
            btnPretraziKorisnik.Location = new Point(352, 35);
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
            txtBrTel.Size = new Size(254, 27);
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
            txtKorisnik.Size = new Size(254, 27);
            txtKorisnik.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(192, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(254, 27);
            txtEmail.TabIndex = 8;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(950, 231);
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
            checkBoxUplacenAvans.Location = new Point(974, 54);
            checkBoxUplacenAvans.Name = "checkBoxUplacenAvans";
            checkBoxUplacenAvans.Size = new Size(124, 24);
            checkBoxUplacenAvans.TabIndex = 8;
            checkBoxUplacenAvans.Text = "uplacen avans";
            checkBoxUplacenAvans.UseVisualStyleBackColor = true;
            // 
            // numericBrOsoba
            // 
            numericBrOsoba.DecimalPlaces = 1;
            numericBrOsoba.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericBrOsoba.Location = new Point(633, 244);
            numericBrOsoba.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericBrOsoba.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericBrOsoba.Name = "numericBrOsoba";
            numericBrOsoba.Size = new Size(61, 27);
            numericBrOsoba.TabIndex = 10;
            numericBrOsoba.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbVrstaUsluge
            // 
            cmbVrstaUsluge.FormattingEnabled = true;
            cmbVrstaUsluge.Location = new Point(633, 192);
            cmbVrstaUsluge.Name = "cmbVrstaUsluge";
            cmbVrstaUsluge.Size = new Size(291, 28);
            cmbVrstaUsluge.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(525, 195);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 4;
            label4.Text = "Vrsta usluge";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(525, 246);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 3;
            label3.Text = "Broj osoba";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(525, 87);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Dan dolaska";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(525, 138);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Dan odlaska";
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(1040, 475);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(94, 29);
            btnOdustani.TabIndex = 15;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // UCPromeniStavkaEvidencijeRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOdustani);
            Controls.Add(groupBoxKorisnik);
            Controls.Add(lblRezervacija);
            Controls.Add(panelIznosi);
            Name = "UCPromeniStavkaEvidencijeRez";
            Size = new Size(1164, 529);
            groupBoxKorisnik.ResumeLayout(false);
            groupBoxKorisnik.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIznosi;
        private Label lblRezervacija;
        private GroupBox groupBoxKorisnik;
        private GroupBox groupBox1;
        private MaskedTextBox maskedTxtBrLicneKarte;
        private Button btnPretraziKorisnik;
        private Label label5;
        private TextBox txtBrTel;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtKorisnik;
        private TextBox txtEmail;
        private Button btnPromeniEvidencijaRez;
        private CheckBox checkBoxUplacenAvans;
        private NumericUpDown numericBrOsoba;
        private ComboBox cmbVrstaUsluge;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Button btnOdustani;
        private DateTimePicker dtpDatumOdlaska;
        private DateTimePicker dtpDatumDolaska;

        public Label LblRezervacija { get => lblRezervacija; set => lblRezervacija = value; }
        public Panel PanelIznosi { get => panelIznosi; set => panelIznosi = value; }
        public CheckBox CheckBoxUplacenAvans { get => checkBoxUplacenAvans; set => checkBoxUplacenAvans = value; }
        public ComboBox CmbVrstaUsluge { get => cmbVrstaUsluge; set => cmbVrstaUsluge = value; }
        public NumericUpDown NumericBrOsoba { get => numericBrOsoba; set => numericBrOsoba = value; }
        public MaskedTextBox MaskedTxtBrLicneKarte { get => maskedTxtBrLicneKarte; set => maskedTxtBrLicneKarte = value; }
        public TextBox TxtKorisnik { get => txtKorisnik; set => txtKorisnik = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public TextBox TxtBrTel { get => txtBrTel; set => txtBrTel = value; }
        public Button BtnZapamtiPodatke { get => btnPromeniEvidencijaRez; set => btnPromeniEvidencijaRez = value; }

        public Button BtnPretraziKorisnik { get => btnPretraziKorisnik; set => btnPretraziKorisnik = value; }
        public DateTimePicker DtpDatumDolaska { get =>  dtpDatumDolaska; set => dtpDatumDolaska = value; }
        public DateTimePicker DtpDatumOdlaska { get => dtpDatumOdlaska; set => dtpDatumOdlaska = value; }
    }
}
