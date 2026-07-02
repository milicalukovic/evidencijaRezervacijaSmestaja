namespace Client.UserControls
{
    partial class UCProveraRaspolozivosti
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
            btnProveri = new Button();
            cmbNazivSmestaja = new ComboBox();
            flpKalendari = new FlowLayoutPanel();
            label2 = new Label();
            numericBrOsoba = new NumericUpDown();
            cmbVrstaUsluge = new ComboBox();
            label3 = new Label();
            checkBoxNaziv = new CheckBox();
            checkBoxUsluga = new CheckBox();
            checkBoxBroj = new CheckBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).BeginInit();
            SuspendLayout();
            // 
            // btnProveri
            // 
            btnProveri.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProveri.Location = new Point(1488, 91);
            btnProveri.Name = "btnProveri";
            btnProveri.Size = new Size(206, 59);
            btnProveri.TabIndex = 0;
            btnProveri.Text = "Proveri";
            btnProveri.UseVisualStyleBackColor = true;
            btnProveri.Click += btnProveri_Click;
            // 
            // cmbNazivSmestaja
            // 
            cmbNazivSmestaja.FormattingEnabled = true;
            cmbNazivSmestaja.Location = new Point(144, 148);
            cmbNazivSmestaja.Name = "cmbNazivSmestaja";
            cmbNazivSmestaja.Size = new Size(227, 28);
            cmbNazivSmestaja.TabIndex = 1;
            // 
            // flpKalendari
            // 
            flpKalendari.AutoScroll = true;
            flpKalendari.AutoSize = true;
            flpKalendari.BorderStyle = BorderStyle.Fixed3D;
            flpKalendari.Location = new Point(144, 218);
            flpKalendari.MaximumSize = new Size(1550, 0);
            flpKalendari.Name = "flpKalendari";
            flpKalendari.Padding = new Padding(20);
            flpKalendari.Size = new Size(1550, 252);
            flpKalendari.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1016, 110);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 4;
            // 
            // numericBrOsoba
            // 
            numericBrOsoba.DecimalPlaces = 1;
            numericBrOsoba.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericBrOsoba.Location = new Point(764, 149);
            numericBrOsoba.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericBrOsoba.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericBrOsoba.Name = "numericBrOsoba";
            numericBrOsoba.Size = new Size(61, 27);
            numericBrOsoba.TabIndex = 11;
            numericBrOsoba.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbVrstaUsluge
            // 
            cmbVrstaUsluge.FormattingEnabled = true;
            cmbVrstaUsluge.Location = new Point(451, 148);
            cmbVrstaUsluge.Name = "cmbVrstaUsluge";
            cmbVrstaUsluge.Size = new Size(227, 28);
            cmbVrstaUsluge.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(590, 110);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 13;
            // 
            // checkBoxNaziv
            // 
            checkBoxNaziv.AutoSize = true;
            checkBoxNaziv.Location = new Point(182, 106);
            checkBoxNaziv.Name = "checkBoxNaziv";
            checkBoxNaziv.Size = new Size(155, 24);
            checkBoxNaziv.TabIndex = 14;
            checkBoxNaziv.Text = "Smeštajna jedinica";
            checkBoxNaziv.UseVisualStyleBackColor = true;
            checkBoxNaziv.CheckedChanged += checkBoxNaziv_CheckedChanged;
            // 
            // checkBoxUsluga
            // 
            checkBoxUsluga.AutoSize = true;
            checkBoxUsluga.Location = new Point(511, 106);
            checkBoxUsluga.Name = "checkBoxUsluga";
            checkBoxUsluga.Size = new Size(110, 24);
            checkBoxUsluga.TabIndex = 15;
            checkBoxUsluga.Text = "Vrsta usluge";
            checkBoxUsluga.UseVisualStyleBackColor = true;
            checkBoxUsluga.CheckedChanged += checkBoxUsluga_CheckedChanged;
            // 
            // checkBoxBroj
            // 
            checkBoxBroj.AutoSize = true;
            checkBoxBroj.Location = new Point(746, 106);
            checkBoxBroj.Name = "checkBoxBroj";
            checkBoxBroj.Size = new Size(105, 24);
            checkBoxBroj.TabIndex = 16;
            checkBoxBroj.Text = "Broj usluga";
            checkBoxBroj.UseVisualStyleBackColor = true;
            checkBoxBroj.CheckedChanged += checkBoxBroj_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(133, 45);
            label1.Name = "label1";
            label1.Size = new Size(387, 25);
            label1.TabIndex = 17;
            label1.Text = "Izaberi kriterijume za proveru raspoloživosti";
            // 
            // UCProveraRaspolozivosti
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(checkBoxBroj);
            Controls.Add(checkBoxUsluga);
            Controls.Add(checkBoxNaziv);
            Controls.Add(label3);
            Controls.Add(cmbVrstaUsluge);
            Controls.Add(numericBrOsoba);
            Controls.Add(label2);
            Controls.Add(flpKalendari);
            Controls.Add(cmbNazivSmestaja);
            Controls.Add(btnProveri);
            Name = "UCProveraRaspolozivosti";
            Size = new Size(1800, 920);
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProveri;
        private ComboBox cmbNazivSmestaja;
        private FlowLayoutPanel flpKalendari;
        private Label label2;
        private NumericUpDown numericBrOsoba;
        private ComboBox cmbVrstaUsluge;
        private Label label3;
        private CheckBox checkBoxNaziv;
        private CheckBox checkBoxUsluga;
        private CheckBox checkBoxBroj;
        private Label label1;

        public Button BtnProveri { get =>  btnProveri; set => btnProveri = value; }
        public ComboBox CmbSmestajnaJedinica { get => cmbNazivSmestaja; set => cmbNazivSmestaja = value; }
        public ComboBox CmbVrstaUsluge { get => cmbVrstaUsluge; set => cmbVrstaUsluge = value; }
        public NumericUpDown NumericBrOsoba { get => numericBrOsoba; set => numericBrOsoba = value;}
        public FlowLayoutPanel FlpKalendari { get => flpKalendari; set => flpKalendari = value; }
        public CheckBox CheckBoxSmestajnaJedinica { get => checkBoxNaziv; set => checkBoxNaziv = value; }
        public CheckBox CheckBoxVrstaUsluge { get => checkBoxUsluga; set => checkBoxUsluga = value; }
        public CheckBox CheckBoxBrOsoba { get => checkBoxBroj; set => checkBoxBroj = value; }

    }
}
