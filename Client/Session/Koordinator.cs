using Client.Forms;
using Client.GuiController;
using Common.Domain;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Session
{
    public class Koordinator
    {
        private static Koordinator instance;
        private Koordinator() { }
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        }
        internal void OtvoriFormu(Form form)
        {
            form.ShowDialog();
        }
        public Vlasnik UlogovaniVlasnik { get; set; }
        public FrmPrijaviVlasnik FrmPrijaviVlasnik { get; set; }
        public PrijaviVlasnikGUIController PrijaviVlasnikGUIController { get; set; }    
        internal void OtvoriFrmPrijaviVlasnik()
        {
            FrmPrijaviVlasnik = new FrmPrijaviVlasnik();
            PrijaviVlasnikGUIController = new PrijaviVlasnikGUIController(FrmPrijaviVlasnik);
            PrijaviVlasnikGUIController.OtvoriFormu();
        }
        
    }
}
