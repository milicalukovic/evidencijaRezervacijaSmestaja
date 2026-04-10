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
            dgvStavke.BackgroundColor = SystemColors.Window;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.GridColor = Color.Tan;
            dgvStavke.Location = new Point(22, 188);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(1006, 383);
            dgvStavke.TabIndex = 0;
            dgvStavke.CellClick += dgvStavke_CellClick;
            // 
            // btnDodajStavka
            // 
            btnDodajStavka.Location = new Point(528, 116);
            btnDodajStavka.Name = "btnDodajStavka";
            btnDodajStavka.Size = new Size(108, 53);
            btnDodajStavka.TabIndex = 1;
            btnDodajStavka.Text = "Dodaj rezervaciju";
            btnDodajStavka.UseVisualStyleBackColor = true;
            btnDodajStavka.Click += btnDodajStavka_Click;
            // 
            // btnIzmeniStavka
            // 
            btnIzmeniStavka.Location = new Point(694, 116);
            btnIzmeniStavka.Name = "btnIzmeniStavka";
            btnIzmeniStavka.Size = new Size(109, 53);
            btnIzmeniStavka.TabIndex = 2;
            btnIzmeniStavka.Text = "Izmeni rezervaciju";
            btnIzmeniStavka.UseVisualStyleBackColor = true;
            btnIzmeniStavka.Click += btnIzmeniStavka_Click;
            // 
            // btnObrisiStavka
            // 
            btnObrisiStavka.Location = new Point(845, 116);
            btnObrisiStavka.Name = "btnObrisiStavka";
            btnObrisiStavka.Size = new Size(105, 53);
            btnObrisiStavka.TabIndex = 3;
            btnObrisiStavka.Text = "Obrisi rezervaciju";
            btnObrisiStavka.UseVisualStyleBackColor = true;
            btnObrisiStavka.Click += btnObrisiStavka_Click;
            // 
            // lblRezervacije
            // 
            lblRezervacije.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblRezervacije.Location = new Point(22, 13);
            lblRezervacije.Name = "lblRezervacije";
            lblRezervacije.Size = new Size(781, 74);
            lblRezervacije.TabIndex = 4;
            lblRezervacije.Text = "Rezervacije";
            // 
            // btnPromeniEvidencijaRez
            // 
            btnPromeniEvidencijaRez.Location = new Point(845, 34);
            btnPromeniEvidencijaRez.Name = "btnPromeniEvidencijaRez";
            btnPromeniEvidencijaRez.Size = new Size(105, 53);
            btnPromeniEvidencijaRez.TabIndex = 5;
            btnPromeniEvidencijaRez.Text = "Sacuvaj evidenciju";
            btnPromeniEvidencijaRez.UseVisualStyleBackColor = true;
            btnPromeniEvidencijaRez.Click += btnPromeniEvidencijaRez_Click;
            // 
            // UCStavkeEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPromeniEvidencijaRez);
            Controls.Add(lblRezervacije);
            Controls.Add(btnObrisiStavka);
            Controls.Add(btnIzmeniStavka);
            Controls.Add(btnDodajStavka);
            Controls.Add(dgvStavke);
            Name = "UCStavkeEvidencijaRez";
            Size = new Size(1052, 589);
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
