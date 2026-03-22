
namespace Client
{
    partial class FrmPrijaviVlasnik
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPrijavi = new Button();
            lblKorisnickoIme = new Label();
            lblLozinka = new Label();
            txtKorisnickoIme = new TextBox();
            txtLozinka = new TextBox();
            SuspendLayout();
            // 
            // btnPrijavi
            // 
            btnPrijavi.BackColor = Color.Tan;
            btnPrijavi.Location = new Point(222, 205);
            btnPrijavi.Name = "btnPrijavi";
            btnPrijavi.Size = new Size(94, 29);
            btnPrijavi.TabIndex = 0;
            btnPrijavi.Text = "prijavi se";
            btnPrijavi.UseVisualStyleBackColor = false;
            btnPrijavi.Click += btnPrijavi_Click;
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.Location = new Point(119, 81);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(106, 20);
            lblKorisnickoIme.TabIndex = 1;
            lblKorisnickoIme.Text = "Korisnicko ime";
            // 
            // lblLozinka
            // 
            lblLozinka.AutoSize = true;
            lblLozinka.Location = new Point(119, 133);
            lblLozinka.Name = "lblLozinka";
            lblLozinka.Size = new Size(59, 20);
            lblLozinka.TabIndex = 2;
            lblLozinka.Text = "Lozinka";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(257, 81);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(155, 27);
            txtKorisnickoIme.TabIndex = 3;
            txtKorisnickoIme.Text = "tasa@luk.com";
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(257, 133);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.Size = new Size(155, 27);
            txtLozinka.TabIndex = 4;
            txtLozinka.Text = "tasa";
            txtLozinka.UseSystemPasswordChar = true;
            // 
            // FrmPrijaviVlasnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 310);
            Controls.Add(txtLozinka);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(lblLozinka);
            Controls.Add(lblKorisnickoIme);
            Controls.Add(btnPrijavi);
            Name = "FrmPrijaviVlasnik";
            Text = "Prijava";
            Load += FrmPrijaviVlasnik_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrijavi;
        private Label lblKorisnickoIme;
        private Label lblLozinka;
        private TextBox txtKorisnickoIme;
        private TextBox txtLozinka;

        public Button BtnPrijavi { get => btnPrijavi; set => btnPrijavi = value; }
        public Label LblKorisnickoIme { get => lblKorisnickoIme; set => lblKorisnickoIme = value; }
        public Label LblLozinka { get => lblLozinka; set => lblLozinka = value; }
        public TextBox TxtKorisnickoIme { get => txtKorisnickoIme; set => txtKorisnickoIme = value; }
        public TextBox TxtLozinka { get => txtLozinka; set => txtLozinka = value; }
    }
}
