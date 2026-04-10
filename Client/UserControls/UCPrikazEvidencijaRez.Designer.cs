namespace Client.UserControls
{
    partial class UCPrikazEvidencijaRez
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
            dgvEvidencije = new DataGridView();
            label1 = new Label();
            btnUnesiKriterijumPretrage = new Button();
            btnPrikaziSve = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEvidencije).BeginInit();
            SuspendLayout();
            // 
            // dgvEvidencije
            // 
            dgvEvidencije.BackgroundColor = SystemColors.Window;
            dgvEvidencije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvidencije.Location = new Point(77, 93);
            dgvEvidencije.Name = "dgvEvidencije";
            dgvEvidencije.RowHeadersWidth = 51;
            dgvEvidencije.Size = new Size(1018, 375);
            dgvEvidencije.TabIndex = 1;
            dgvEvidencije.CellClick += dgvEvidencije_CellClick;
            dgvEvidencije.DataError += dgvEvidencije_DataError;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(77, 38);
            label1.Name = "label1";
            label1.Size = new Size(210, 25);
            label1.TabIndex = 2;
            label1.Text = "Vase mesecne evidecije";
            // 
            // btnUnesiKriterijumPretrage
            // 
            btnUnesiKriterijumPretrage.Location = new Point(663, 33);
            btnUnesiKriterijumPretrage.Name = "btnUnesiKriterijumPretrage";
            btnUnesiKriterijumPretrage.Size = new Size(180, 38);
            btnUnesiKriterijumPretrage.TabIndex = 3;
            btnUnesiKriterijumPretrage.Text = "Pretrazi evidencije";
            btnUnesiKriterijumPretrage.UseVisualStyleBackColor = true;
            btnUnesiKriterijumPretrage.Click += btnUnesiKriterijumPretrage_Click;
            // 
            // btnPrikaziSve
            // 
            btnPrikaziSve.Location = new Point(887, 33);
            btnPrikaziSve.Name = "btnPrikaziSve";
            btnPrikaziSve.Size = new Size(181, 38);
            btnPrikaziSve.TabIndex = 4;
            btnPrikaziSve.Text = "Prikazi sve evidencije";
            btnPrikaziSve.UseVisualStyleBackColor = true;
            btnPrikaziSve.Click += btnPrikaziSve_Click;
            // 
            // UCPrikazEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(btnPrikaziSve);
            Controls.Add(btnUnesiKriterijumPretrage);
            Controls.Add(label1);
            Controls.Add(dgvEvidencije);
            Name = "UCPrikazEvidencijaRez";
            Size = new Size(1164, 529);
            ((System.ComponentModel.ISupportInitialize)dgvEvidencije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEvidencije;
        private Label label1;
        private Button btnUnesiKriterijumPretrage;
        private Button btnPrikaziSve;

        public DataGridView DgvEvidencije { get => dgvEvidencije; set =>  dgvEvidencije = value; }
    }
}
