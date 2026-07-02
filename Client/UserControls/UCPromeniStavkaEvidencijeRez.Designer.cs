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
            checkBoxZatvoreno = new CheckBox();
            dtpDatumOdlaska = new DateTimePicker();
            dtpDatumDolaska = new DateTimePicker();
            groupBox1 = new GroupBox();
            txtBrLicnogDokumenta = new TextBox();
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
            panelIznosi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelIznosi.AutoSize = true;
            panelIznosi.Location = new Point(145, 646);
            panelIznosi.Name = "panelIznosi";
            panelIznosi.Size = new Size(1375, 192);
            panelIznosi.TabIndex = 7;
            // 
            // lblRezervacija
            // 
            lblRezervacija.Anchor = AnchorStyles.Top;
            lblRezervacija.AutoSize = true;
            lblRezervacija.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRezervacija.Location = new Point(628, 57);
            lblRezervacija.Name = "lblRezervacija";
            lblRezervacija.Size = new Size(108, 28);
            lblRezervacija.TabIndex = 8;
            lblRezervacija.Text = "Rezervacija";
            // 
            // groupBoxKorisnik
            // 
            groupBoxKorisnik.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxKorisnik.Controls.Add(checkBoxZatvoreno);
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
            groupBoxKorisnik.Location = new Point(88, 133);
            groupBoxKorisnik.Name = "groupBoxKorisnik";
            groupBoxKorisnik.Size = new Size(1621, 468);
            groupBoxKorisnik.TabIndex = 14;
            groupBoxKorisnik.TabStop = false;
            groupBoxKorisnik.Text = "Podaci o rezervaciji";
            // 
            // checkBoxZatvoreno
            // 
            checkBoxZatvoreno.AutoSize = true;
            checkBoxZatvoreno.Location = new Point(204, 40);
            checkBoxZatvoreno.Name = "checkBoxZatvoreno";
            checkBoxZatvoreno.Size = new Size(78, 24);
            checkBoxZatvoreno.TabIndex = 19;
            checkBoxZatvoreno.Text = "Zatvori";
            checkBoxZatvoreno.UseVisualStyleBackColor = true;
            checkBoxZatvoreno.CheckedChanged += checkBoxZatvoreno_CheckedChanged;
            // 
            // dtpDatumOdlaska
            // 
            dtpDatumOdlaska.Location = new Point(938, 174);
            dtpDatumOdlaska.Name = "dtpDatumOdlaska";
            dtpDatumOdlaska.Size = new Size(291, 27);
            dtpDatumOdlaska.TabIndex = 18;
            // 
            // dtpDatumDolaska
            // 
            dtpDatumDolaska.Location = new Point(938, 123);
            dtpDatumDolaska.Name = "dtpDatumDolaska";
            dtpDatumDolaska.Size = new Size(291, 27);
            dtpDatumDolaska.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBrLicnogDokumenta);
            groupBox1.Controls.Add(btnPretraziKorisnik);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtBrTel);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtKorisnik);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(57, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(635, 350);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o gostu";
            // 
            // txtBrLicnogDokumenta
            // 
            txtBrLicnogDokumenta.Location = new Point(275, 106);
            txtBrLicnogDokumenta.Name = "txtBrLicnogDokumenta";
            txtBrLicnogDokumenta.Size = new Size(254, 27);
            txtBrLicnogDokumenta.TabIndex = 2;
            // 
            // btnPretraziKorisnik
            // 
            btnPretraziKorisnik.Location = new Point(510, 42);
            btnPretraziKorisnik.Name = "btnPretraziKorisnik";
            btnPretraziKorisnik.Size = new Size(94, 29);
            btnPretraziKorisnik.TabIndex = 10;
            btnPretraziKorisnik.Text = "Pretraži";
            btnPretraziKorisnik.UseVisualStyleBackColor = true;
            btnPretraziKorisnik.Click += btnPretraziKorisnik_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 109);
            label5.Name = "label5";
            label5.Size = new Size(200, 20);
            label5.TabIndex = 0;
            label5.Text = "Unesi broj ličnog dokumenta";
            // 
            // txtBrTel
            // 
            txtBrTel.Location = new Point(275, 287);
            txtBrTel.Name = "txtBrTel";
            txtBrTel.Size = new Size(254, 27);
            txtBrTel.TabIndex = 9;
            // 
            // label6
            // 
            label6.Location = new Point(77, 169);
            label6.Name = "label6";
            label6.Size = new Size(148, 24);
            label6.TabIndex = 4;
            label6.Text = "Gost";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(77, 231);
            label7.Name = "label7";
            label7.Size = new Size(148, 24);
            label7.TabIndex = 5;
            label7.Text = "Email";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Location = new Point(77, 288);
            label8.Name = "label8";
            label8.Size = new Size(148, 24);
            label8.TabIndex = 6;
            label8.Text = "Telefon";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtKorisnik
            // 
            txtKorisnik.Location = new Point(275, 168);
            txtKorisnik.Name = "txtKorisnik";
            txtKorisnik.Size = new Size(254, 27);
            txtKorisnik.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(275, 230);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(254, 27);
            txtEmail.TabIndex = 8;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(1367, 228);
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
            checkBoxUplacenAvans.Location = new Point(1381, 159);
            checkBoxUplacenAvans.Name = "checkBoxUplacenAvans";
            checkBoxUplacenAvans.Size = new Size(124, 24);
            checkBoxUplacenAvans.TabIndex = 8;
            checkBoxUplacenAvans.Text = "uplaćen avans";
            checkBoxUplacenAvans.UseVisualStyleBackColor = true;
            // 
            // numericBrOsoba
            // 
            numericBrOsoba.DecimalPlaces = 1;
            numericBrOsoba.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericBrOsoba.Location = new Point(938, 285);
            numericBrOsoba.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericBrOsoba.Name = "numericBrOsoba";
            numericBrOsoba.Size = new Size(61, 27);
            numericBrOsoba.TabIndex = 10;
            numericBrOsoba.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbVrstaUsluge
            // 
            cmbVrstaUsluge.FormattingEnabled = true;
            cmbVrstaUsluge.Location = new Point(938, 233);
            cmbVrstaUsluge.Name = "cmbVrstaUsluge";
            cmbVrstaUsluge.Size = new Size(291, 28);
            cmbVrstaUsluge.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(830, 236);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 4;
            label4.Text = "Vrsta usluge";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(830, 287);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Broj usluga";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(830, 128);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Dan dolaska";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(830, 179);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Dan odlaska";
            // 
            // btnOdustani
            // 
            btnOdustani.Location = new Point(1611, 719);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(98, 36);
            btnOdustani.TabIndex = 15;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = true;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // UCPromeniStavkaEvidencijeRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btnOdustani);
            Controls.Add(groupBoxKorisnik);
            Controls.Add(lblRezervacija);
            Controls.Add(panelIznosi);
            Name = "UCPromeniStavkaEvidencijeRez";
            Size = new Size(1800, 920);
            groupBoxKorisnik.ResumeLayout(false);
            groupBoxKorisnik.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelIznosi;
        private Label lblRezervacija;
        private GroupBox groupBoxKorisnik;
        private GroupBox groupBox1;
        private TextBox txtBrLicnogDokumenta;
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
        private CheckBox checkBoxZatvoreno;

        public Label LblRezervacija { get => lblRezervacija; set => lblRezervacija = value; }
        public Panel PanelIznosi { get => panelIznosi; set => panelIznosi = value; }
        public CheckBox CheckBoxZatvoreno { get => checkBoxZatvoreno; set => checkBoxZatvoreno = value; }
        public CheckBox CheckBoxUplacenAvans { get => checkBoxUplacenAvans; set => checkBoxUplacenAvans = value; }
        public ComboBox CmbVrstaUsluge { get => cmbVrstaUsluge; set => cmbVrstaUsluge = value; }
        public NumericUpDown NumericBrOsoba { get => numericBrOsoba; set => numericBrOsoba = value; }
        public TextBox TxtBrLicnogDokumenta { get => txtBrLicnogDokumenta; set => txtBrLicnogDokumenta = value; }
        public TextBox TxtKorisnik { get => txtKorisnik; set => txtKorisnik = value; }
        public TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }
        public TextBox TxtBrTel { get => txtBrTel; set => txtBrTel = value; }
        public Button BtnZapamtiPodatke { get => btnPromeniEvidencijaRez; set => btnPromeniEvidencijaRez = value; }

        public Button BtnPretraziKorisnik { get => btnPretraziKorisnik; set => btnPretraziKorisnik = value; }
        public DateTimePicker DtpDatumDolaska { get =>  dtpDatumDolaska; set => dtpDatumDolaska = value; }
        public DateTimePicker DtpDatumOdlaska { get => dtpDatumOdlaska; set => dtpDatumOdlaska = value; }
    }
}
