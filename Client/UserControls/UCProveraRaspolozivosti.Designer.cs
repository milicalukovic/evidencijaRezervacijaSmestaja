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
            label1 = new Label();
            flpKalendari = new FlowLayoutPanel();
            label2 = new Label();
            numericBrOsoba = new NumericUpDown();
            cmbVrstaUsluge = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericBrOsoba).BeginInit();
            SuspendLayout();
            // 
            // btnProveri
            // 
            btnProveri.Location = new Point(1488, 91);
            btnProveri.Name = "btnProveri";
            btnProveri.Size = new Size(206, 59);
            btnProveri.TabIndex = 0;
            btnProveri.Text = "Proveri";
            btnProveri.UseVisualStyleBackColor = true;
            // 
            // cmbNazivSmestaja
            // 
            cmbNazivSmestaja.FormattingEnabled = true;
            cmbNazivSmestaja.Location = new Point(269, 107);
            cmbNazivSmestaja.Name = "cmbNazivSmestaja";
            cmbNazivSmestaja.Size = new Size(227, 28);
            cmbNazivSmestaja.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 110);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 2;
            label1.Text = "Naziv smestaja";
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
            label2.Location = new Point(980, 110);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 4;
            label2.Text = "Broj usluga";
            // 
            // numericBrOsoba
            // 
            numericBrOsoba.DecimalPlaces = 1;
            numericBrOsoba.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericBrOsoba.Location = new Point(1080, 108);
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
            cmbVrstaUsluge.Location = new Point(682, 107);
            cmbVrstaUsluge.Name = "cmbVrstaUsluge";
            cmbVrstaUsluge.Size = new Size(227, 28);
            cmbVrstaUsluge.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(566, 110);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 13;
            label3.Text = "Vrsta usluge";
            // 
            // UCProveraRaspolozivosti
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cmbVrstaUsluge);
            Controls.Add(numericBrOsoba);
            Controls.Add(label2);
            Controls.Add(flpKalendari);
            Controls.Add(label1);
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
        private Label label1;
        private FlowLayoutPanel flpKalendari;
        private Label label2;
        private NumericUpDown numericBrOsoba;
        private ComboBox cmbVrstaUsluge;
        private Label label3;

        public Button BtnProveri { get =>  btnProveri; set => btnProveri = value; }
        public ComboBox CmbSmestajnaJedinica { get => cmbNazivSmestaja; set => cmbNazivSmestaja = value; }
        public ComboBox CmbVrstaUsluge { get => cmbVrstaUsluge; set => cmbVrstaUsluge = value; }
        public NumericUpDown NumericBrOsoba { get => numericBrOsoba; set => numericBrOsoba = value;}
        public FlowLayoutPanel FlpKalendari { get => flpKalendari; set => flpKalendari = value; }   
    }
}
