
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
            lblNovi = new Label();
            btnRegistruj = new Button();
            SuspendLayout();
            // 
            // btnPrijavi
            // 
            btnPrijavi.Location = new Point(358, 219);
            btnPrijavi.Name = "btnPrijavi";
            btnPrijavi.Size = new Size(94, 29);
            btnPrijavi.TabIndex = 0;
            btnPrijavi.Text = "prijavi se";
            btnPrijavi.UseVisualStyleBackColor = true;
            btnPrijavi.Click += btnPrijavi_Click;
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.Location = new Point(176, 91);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(106, 20);
            lblKorisnickoIme.TabIndex = 1;
            lblKorisnickoIme.Text = "Korisnicko ime";
            // 
            // lblLozinka
            // 
            lblLozinka.AutoSize = true;
            lblLozinka.Location = new Point(176, 143);
            lblLozinka.Name = "lblLozinka";
            lblLozinka.Size = new Size(59, 20);
            lblLozinka.TabIndex = 2;
            lblLozinka.Text = "Lozinka";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(314, 91);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(180, 27);
            txtKorisnickoIme.TabIndex = 3;
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(314, 143);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.Size = new Size(180, 27);
            txtLozinka.TabIndex = 4;
            // 
            // lblNovi
            // 
            lblNovi.AutoSize = true;
            lblNovi.Location = new Point(358, 266);
            lblNovi.Name = "lblNovi";
            lblNovi.Size = new Size(111, 20);
            lblNovi.TabIndex = 5;
            lblNovi.Text = "Nemate nalog?";
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(358, 308);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(94, 29);
            btnRegistruj.TabIndex = 6;
            btnRegistruj.Text = "registruj se";
            btnRegistruj.UseVisualStyleBackColor = true;
            btnRegistruj.Click += btnRegistruj_Click;
            // 
            // FrmPrijaviVlasnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistruj);
            Controls.Add(lblNovi);
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
        private Label lblNovi;
        private Button btnRegistruj;

        public Button BtnPrijavi { get => btnPrijavi; set => btnPrijavi = value; }
        public Label LblKorisnickoIme { get => lblKorisnickoIme; set => lblKorisnickoIme = value; }
        public Label LblLozinka { get => lblLozinka; set => lblLozinka = value; }
        public TextBox TxtKorisnickoIme { get => txtKorisnickoIme; set => txtKorisnickoIme = value; }
        public TextBox TxtLozinka { get => txtLozinka; set => txtLozinka = value; }
        public Label LblRegistracija { get => lblNovi; set => lblNovi = value; }
        public Button BtnRegistracija { get => btnRegistruj; set => btnRegistruj = value; }
    }
}
