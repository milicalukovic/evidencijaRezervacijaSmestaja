namespace Client.Forms
{
    partial class FrmKriterijumPretrageEvidencijaRez
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnPretraziEvidencijeRez = new Button();
            numericGodina = new NumericUpDown();
            label6 = new Label();
            txtSmestajNaziv = new TextBox();
            txtBrLicneKarte = new TextBox();
            label7 = new Label();
            cmbMesec = new ComboBox();
            checkBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericGodina).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(186, 47);
            label1.Name = "label1";
            label1.Size = new Size(392, 28);
            label1.TabIndex = 0;
            label1.Text = "Unesi kriterijume za pretragu evidencija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(433, 111);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 1;
            label2.Text = "mesec";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(596, 111);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 2;
            label3.Text = "godina";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.Location = new Point(118, 202);
            label4.Name = "label4";
            label4.Size = new Size(216, 25);
            label4.TabIndex = 3;
            label4.Text = "Naziv smestajne jedinice";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.Location = new Point(118, 267);
            label5.Name = "label5";
            label5.Size = new Size(241, 25);
            label5.TabIndex = 4;
            label5.Text = "Licna karta korisnika usluge";
            // 
            // btnPretraziEvidencijeRez
            // 
            btnPretraziEvidencijeRez.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPretraziEvidencijeRez.Location = new Point(532, 349);
            btnPretraziEvidencijeRez.Name = "btnPretraziEvidencijeRez";
            btnPretraziEvidencijeRez.Size = new Size(161, 61);
            btnPretraziEvidencijeRez.TabIndex = 5;
            btnPretraziEvidencijeRez.Text = "pretrazi evidencije";
            btnPretraziEvidencijeRez.UseVisualStyleBackColor = true;
            btnPretraziEvidencijeRez.Click += btnPretraziEvidencijeRez_Click;
            // 
            // numericGodina
            // 
            numericGodina.Location = new Point(582, 139);
            numericGodina.Maximum = new decimal(new int[] { 2036, 0, 0, 0 });
            numericGodina.Minimum = new decimal(new int[] { 2002, 0, 0, 0 });
            numericGodina.Name = "numericGodina";
            numericGodina.Size = new Size(101, 27);
            numericGodina.TabIndex = 7;
            numericGodina.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(557, 137);
            label6.Name = "label6";
            label6.Size = new Size(19, 25);
            label6.TabIndex = 8;
            label6.Text = "/";
            // 
            // txtSmestajNaziv
            // 
            txtSmestajNaziv.Location = new Point(396, 200);
            txtSmestajNaziv.Name = "txtSmestajNaziv";
            txtSmestajNaziv.Size = new Size(287, 27);
            txtSmestajNaziv.TabIndex = 9;
            // 
            // txtBrLicneKarte
            // 
            txtBrLicneKarte.Location = new Point(396, 265);
            txtBrLicneKarte.Name = "txtBrLicneKarte";
            txtBrLicneKarte.Size = new Size(287, 27);
            txtBrLicneKarte.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.Location = new Point(118, 137);
            label7.Name = "label7";
            label7.Size = new Size(208, 25);
            label7.TabIndex = 11;
            label7.Text = "Unesi period evidencije";
            // 
            // cmbMesec
            // 
            cmbMesec.FormattingEnabled = true;
            cmbMesec.Location = new Point(396, 137);
            cmbMesec.Name = "cmbMesec";
            cmbMesec.Size = new Size(155, 28);
            cmbMesec.TabIndex = 12;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(94, 143);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(18, 17);
            checkBox.TabIndex = 13;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // FrmKriterijumPretrageEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(758, 449);
            Controls.Add(checkBox);
            Controls.Add(cmbMesec);
            Controls.Add(label7);
            Controls.Add(txtBrLicneKarte);
            Controls.Add(txtSmestajNaziv);
            Controls.Add(label6);
            Controls.Add(numericGodina);
            Controls.Add(btnPretraziEvidencijeRez);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmKriterijumPretrageEvidencijaRez";
            Text = "Kriterijumi pretrage";
            ((System.ComponentModel.ISupportInitialize)numericGodina).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnPretraziEvidencijeRez;
        private NumericUpDown numericGodina;
        private Label label6;
        private TextBox txtSmestajNaziv;
        private TextBox txtBrLicneKarte;
        private Label label7;
        private ComboBox cmbMesec;
        private CheckBox checkBox;

        public CheckBox CheckBox { get => checkBox; set => checkBox = value;  }
        public ComboBox CmbMesec { get => cmbMesec; set => cmbMesec = value;  }
        public NumericUpDown NumericGodina { get => numericGodina; set => numericGodina = value; }
        public TextBox TxtSmestajNaziv { get => txtSmestajNaziv; set => txtSmestajNaziv = value; }
        public TextBox TxtBrLicneKarte { get => txtBrLicneKarte; set => txtBrLicneKarte = value; }
    }
}