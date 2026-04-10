namespace Client.Forms
{
    partial class FrmPromeniEvidencijaRez
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
            panelEvidencije = new Panel();
            SuspendLayout();
            // 
            // panelEvidencije
            // 
            panelEvidencije.Location = new Point(45, 40);
            panelEvidencije.Name = "panelEvidencije";
            panelEvidencije.Size = new Size(1052, 589);
            panelEvidencije.TabIndex = 19;
            // 
            // FrmPromeniEvidencijaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 660);
            Controls.Add(panelEvidencije);
            Name = "FrmPromeniEvidencijaRez";
            Text = "Evidencija rezervacija";
            FormClosing += FrmPromeniEvidencijaRez_FormClosing;
            ResumeLayout(false);
        }

        #endregion
        private Panel panelEvidencije;

        public Panel PanelEvidencije { get => panelEvidencije; set => panelEvidencije = value;}
    }
}