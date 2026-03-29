namespace Client.Forms
{
    partial class FrmGlavna
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
            menu = new MenuStrip();
            mesecnaEvidencijaMenuItem = new ToolStripMenuItem();
            kreirajNovuToolStripMenuItem = new ToolStripMenuItem();
            pretraziEvidencijeToolStripMenuItem = new ToolStripMenuItem();
            izmeniPostojecuToolStripMenuItem = new ToolStripMenuItem();
            smestajnaJedinicaMenuItem = new ToolStripMenuItem();
            prikazSJMenuItem = new ToolStripMenuItem();
            prosecnaOcenaMenuItem = new ToolStripMenuItem();
            ubaciIzvorOcene = new ToolStripMenuItem();
            vlasnikMenuItem = new ToolStripMenuItem();
            odjava = new ToolStripMenuItem();
            panel = new Panel();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = Color.Tan;
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { mesecnaEvidencijaMenuItem, smestajnaJedinicaMenuItem, prosecnaOcenaMenuItem, vlasnikMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1229, 28);
            menu.TabIndex = 0;
            menu.Text = "menu";
            // 
            // mesecnaEvidencijaMenuItem
            // 
            mesecnaEvidencijaMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajNovuToolStripMenuItem, pretraziEvidencijeToolStripMenuItem, izmeniPostojecuToolStripMenuItem });
            mesecnaEvidencijaMenuItem.Name = "mesecnaEvidencijaMenuItem";
            mesecnaEvidencijaMenuItem.Size = new Size(152, 24);
            mesecnaEvidencijaMenuItem.Text = "Mesecna evidencija";
            // 
            // kreirajNovuToolStripMenuItem
            // 
            kreirajNovuToolStripMenuItem.Name = "kreirajNovuToolStripMenuItem";
            kreirajNovuToolStripMenuItem.Size = new Size(214, 26);
            kreirajNovuToolStripMenuItem.Text = "kreiraj novu";
            // 
            // pretraziEvidencijeToolStripMenuItem
            // 
            pretraziEvidencijeToolStripMenuItem.Name = "pretraziEvidencijeToolStripMenuItem";
            pretraziEvidencijeToolStripMenuItem.Size = new Size(214, 26);
            pretraziEvidencijeToolStripMenuItem.Text = "pretrazi evidenciju";
            // 
            // izmeniPostojecuToolStripMenuItem
            // 
            izmeniPostojecuToolStripMenuItem.Name = "izmeniPostojecuToolStripMenuItem";
            izmeniPostojecuToolStripMenuItem.Size = new Size(214, 26);
            izmeniPostojecuToolStripMenuItem.Text = "izmeni postojecu";
            // 
            // smestajnaJedinicaMenuItem
            // 
            smestajnaJedinicaMenuItem.DropDownItems.AddRange(new ToolStripItem[] { prikazSJMenuItem });
            smestajnaJedinicaMenuItem.Name = "smestajnaJedinicaMenuItem";
            smestajnaJedinicaMenuItem.Size = new Size(148, 24);
            smestajnaJedinicaMenuItem.Text = "Smestajna Jedinica";
            // 
            // prikazSJMenuItem
            // 
            prikazSJMenuItem.Name = "prikazSJMenuItem";
            prikazSJMenuItem.Size = new Size(161, 26);
            prikazSJMenuItem.Text = "prikazi sve";
            prikazSJMenuItem.Click += prikaziMenuItem_Click;
            // 
            // prosecnaOcenaMenuItem
            // 
            prosecnaOcenaMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciIzvorOcene });
            prosecnaOcenaMenuItem.Name = "prosecnaOcenaMenuItem";
            prosecnaOcenaMenuItem.Size = new Size(128, 24);
            prosecnaOcenaMenuItem.Text = "Prosecna Ocena";
            // 
            // ubaciIzvorOcene
            // 
            ubaciIzvorOcene.Name = "ubaciIzvorOcene";
            ubaciIzvorOcene.Size = new Size(211, 26);
            ubaciIzvorOcene.Text = "dodaj izvor ocene";
            ubaciIzvorOcene.Click += ubaciIzvorOcene_Click;
            // 
            // vlasnikMenuItem
            // 
            vlasnikMenuItem.Alignment = ToolStripItemAlignment.Right;
            vlasnikMenuItem.DropDownItems.AddRange(new ToolStripItem[] { odjava });
            vlasnikMenuItem.Name = "vlasnikMenuItem";
            vlasnikMenuItem.Size = new Size(69, 24);
            vlasnikMenuItem.Text = "Vlasnik";
            // 
            // odjava
            // 
            odjava.Name = "odjava";
            odjava.Size = new Size(151, 26);
            odjava.Text = "odjavi se";
            odjava.Click += odjava_Click;
            // 
            // panel
            // 
            panel.Location = new Point(31, 50);
            panel.Name = "panel";
            panel.Size = new Size(1164, 529);
            panel.TabIndex = 1;
            // 
            // FrmGlavna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1229, 612);
            Controls.Add(panel);
            Controls.Add(menu);
            Name = "FrmGlavna";
            Text = "Klijentska forma";
            FormClosing += FrmGlavna_FormClosing;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem mesecnaEvidencijaMenuItem;
        private ToolStripMenuItem smestajnaJedinicaMenuItem;
        private ToolStripMenuItem prosecnaOcenaMenuItem;
        private ToolStripMenuItem vlasnikMenuItem;
        private ToolStripMenuItem odjava;
        private ToolStripMenuItem kreirajNovuToolStripMenuItem;
        private ToolStripMenuItem pretraziEvidencijeToolStripMenuItem;
        private ToolStripMenuItem izmeniPostojecuToolStripMenuItem;
        private ToolStripMenuItem prikazSJMenuItem;
        private ToolStripMenuItem ubaciIzvorOcene;
        private Panel panel;

        public Panel GlavnaPanel { get => panel; set => panel = value; }
    }
}