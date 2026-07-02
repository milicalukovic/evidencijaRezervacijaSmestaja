namespace Client.UserControls
{
    partial class UCStavkeEvidencijaRez
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
            dgvStavke = new DataGridView();
            btnDodajStavka = new Button();
            btnIzmeniStavka = new Button();
            btnObrisiStavka = new Button();
            lblRezervacije = new Label();
            btnPromeniEvidencijaRez = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // dgvStavke
            // 
            dgvStavke.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStavke.BackgroundColor = SystemColors.Window;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.GridColor = Color.Tan;
            dgvStavke.Location = new Point(133, 131);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(937, 246);
            dgvStavke.TabIndex = 0;
            dgvStavke.CellClick += dgvStavke_CellClick;
            // 
            // btnDodajStavka
            // 
            btnDodajStavka.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDodajStavka.Location = new Point(475, 438);
            btnDodajStavka.Name = "btnDodajStavka";
            btnDodajStavka.Size = new Size(171, 53);
            btnDodajStavka.TabIndex = 1;
            btnDodajStavka.Text = "Dodaj rezervaciju";
            btnDodajStavka.UseVisualStyleBackColor = true;
            btnDodajStavka.Click += btnDodajStavka_Click;
            // 
            // btnIzmeniStavka
            // 
            btnIzmeniStavka.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIzmeniStavka.Location = new Point(733, 438);
            btnIzmeniStavka.Name = "btnIzmeniStavka";
            btnIzmeniStavka.Size = new Size(173, 53);
            btnIzmeniStavka.TabIndex = 2;
            btnIzmeniStavka.Text = "Izmeni rezervaciju";
            btnIzmeniStavka.UseVisualStyleBackColor = true;
            btnIzmeniStavka.Click += btnIzmeniStavka_Click;
            // 
            // btnObrisiStavka
            // 
            btnObrisiStavka.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnObrisiStavka.Location = new Point(988, 438);
            btnObrisiStavka.Name = "btnObrisiStavka";
            btnObrisiStavka.Size = new Size(154, 53);
            btnObrisiStavka.TabIndex = 3;
            btnObrisiStavka.Text = "Obriši rezervaciju";
            btnObrisiStavka.UseVisualStyleBackColor = true;
            btnObrisiStavka.Click += btnObrisiStavka_Click;
            // 
            // lblRezervacije
            // 
            lblRezervacije.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblRezervacije.Location = new Point(59, 50);
            lblRezervacije.Name = "lblRezervacije";
            lblRezervacije.Size = new Size(972, 39);
            lblRezervacije.TabIndex = 4;
            lblRezervacije.Text = "Rezervacije";
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPromeniEvidencijaRez.Location = new Point(970, 41);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(172, 53);
            btnPromeniEvidencijaRez.TabIndex = 5;
            btnPromeniEvidencijaRez.Text = "Sačuvaj evidenciju";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // UCStavkeEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btnPromeniEvidencijaRez);
            Controls.Add(lblRezervacije);
            Controls.Add(btnObrisiStavka);
            Controls.Add(btnIzmeniStavka);
            Controls.Add(btnDodajStavka);
            Controls.Add(dgvStavke);
            Name = "UCStavkeEvidencijaRez";
            Size = new Size(1219, 529);
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStavke;
        private Button btnDodajStavka;
        private Button btnIzmeniStavka;
        private Button btnObrisiStavka;
        private Label lblRezervacije;
        private Button btnPromeniEvidencijaRez;

        public DataGridView DgvStavke { get => dgvStavke; set => dgvStavke = value; }
        public Button BtnDodajStavka { get => btnDodajStavka; set =>  btnDodajStavka = value;}
        public Button BtnIzmeniStavka { get => btnIzmeniStavka; set => btnIzmeniStavka = value; }
        public Button BtnObrisiStavka { get => btnObrisiStavka; set => btnObrisiStavka = value; }
        public Label LblRezervacije { get => lblRezervacije; set => lblRezervacije = value; }
    }
}
