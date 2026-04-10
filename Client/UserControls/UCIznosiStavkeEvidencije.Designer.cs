namespace Client.UserControls
{
    partial class UCIznosiStavkeEvidencije
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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtBrDana = new TextBox();
            txtIznosAvansa = new TextBox();
            txtIznosUsluge = new TextBox();
            txtIznosRezervacije = new TextBox();
            btnPromeniEvidencijaRez = new Button();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label6
            // 
            label6.Location = new Point(55, 37);
            label6.Name = "label6";
            label6.Size = new Size(148, 24);
            label6.TabIndex = 5;
            label6.Text = "Broj dana";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Location = new Point(55, 97);
            label1.Name = "label1";
            label1.Size = new Size(148, 24);
            label1.TabIndex = 6;
            label1.Text = "Iznos avansa";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(375, 97);
            label2.Name = "label2";
            label2.Size = new Size(148, 24);
            label2.TabIndex = 7;
            label2.Text = "Iznos rezervacije";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Location = new Point(375, 37);
            label3.Name = "label3";
            label3.Size = new Size(148, 24);
            label3.TabIndex = 8;
            label3.Text = "Iznos usluge";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBrDana
            // 
            txtBrDana.Location = new Point(209, 36);
            txtBrDana.Name = "txtBrDana";
            txtBrDana.Size = new Size(105, 27);
            txtBrDana.TabIndex = 9;
            // 
            // txtIznosAvansa
            // 
            txtIznosAvansa.Location = new Point(209, 96);
            txtIznosAvansa.Name = "txtIznosAvansa";
            txtIznosAvansa.Size = new Size(105, 27);
            txtIznosAvansa.TabIndex = 10;
            // 
            // txtIznosUsluge
            // 
            txtIznosUsluge.Location = new Point(529, 36);
            txtIznosUsluge.Name = "txtIznosUsluge";
            txtIznosUsluge.Size = new Size(105, 27);
            txtIznosUsluge.TabIndex = 11;
            // 
            // txtIznosRezervacije
            // 
            txtIznosRezervacije.Location = new Point(529, 96);
            txtIznosRezervacije.Name = "txtIznosRezervacije";
            txtIznosRezervacije.Size = new Size(105, 27);
            txtIznosRezervacije.TabIndex = 12;
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(707, 64);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(151, 35);
            btnPromeniEvidencijaRez.TabIndex = 13;
            btnPromeniEvidencijaRez.Text = "Sacuvaj rezervaciju";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // UCIznosiStavkeEvidencije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPromeniEvidencijaRez);
            Controls.Add(txtIznosRezervacije);
            Controls.Add(txtIznosUsluge);
            Controls.Add(txtIznosAvansa);
            Controls.Add(txtBrDana);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Name = "UCIznosiStavkeEvidencije";
            Size = new Size(888, 165);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBrDana;
        private TextBox txtIznosAvansa;
        private TextBox txtIznosUsluge;
        private TextBox txtIznosRezervacije;
        private Button btnPromeniEvidencijaRez;

        public TextBox TxtBrDana { get =>  txtBrDana; set => txtBrDana = value; }
        public TextBox TxtIznosAvansa { get => txtIznosAvansa; set => txtIznosAvansa = value; }
        public TextBox TxtIznosUsluge { get => txtIznosUsluge; set => txtIznosUsluge = value; }
        public TextBox TxtIznosRezervacije { get => txtIznosRezervacije; set => txtIznosRezervacije = value; }
    }
}
