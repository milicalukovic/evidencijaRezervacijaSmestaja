using Client.Forms;
using Client.GuiController;
using Client.UserControls;
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
        public PrijaviVlasnikController PrijaviVlasnikController { get; set; }    
        internal void OtvoriFrmPrijaviVlasnik()
        {
            FrmPrijaviVlasnik = new FrmPrijaviVlasnik();
            PrijaviVlasnikController = new PrijaviVlasnikController(FrmPrijaviVlasnik);
            PrijaviVlasnikController.OtvoriFormu();
        }

        public FrmGlavna FrmGlavna { get; set; }
        public GlavnaFrmController GlavnaFrmController { get; set; }
        internal void OtvoriGlavnuFrm() //prijaviGui je poziva
        {
            FrmGlavna = new FrmGlavna();
            GlavnaFrmController = new GlavnaFrmController(FrmGlavna);
            //GlavnaFrmController.OtvoriFormu();  preko App run se inicijalizuje
        }

        public FrmIzvorOcene FrmIzvorOcene { get; set; }
        public IzvorOceneController IzvorOceneController { get; set; }
        internal void OtvoriFrmIzvorOcene()
        {
            FrmIzvorOcene = new FrmIzvorOcene();
            IzvorOceneController = new IzvorOceneController(FrmIzvorOcene);
            IzvorOceneController.OtvoriFormu();
        }

        public List<TipSmestaja> ListaTipSmestaja { get; set; }
        public List<SmestajnaJedinica> ListaSmestajnaJedinica { get; set; }
        public UCPrikazSmestajnaJedinica UCPrikazSmestajnaJedinica { get; set; }
        public SmestajnaJedinicaUCController SmestajnaJedinicaUCController { get; set; }
        internal void InicijalizujUCPrikazSJ()
        {
            UCPrikazSmestajnaJedinica = new UCPrikazSmestajnaJedinica();
            SmestajnaJedinicaUCController = new SmestajnaJedinicaUCController(UCPrikazSmestajnaJedinica);
        }

        public SmestajnaJedinica KreiranaSJ { get; set; }
        public SmestajnaJedinica IzabranaSJ { get; set; }
        public Boolean ModeKreirajSJ { get; set; }
        public FrmSmestajnaJedinica FrmSmestajnaJedinica { get; set; }
        public SmestajnaJedinicaFrmController SmestajnaJedinicaFrmController { get; set; }
        internal void OtvoriFrmSmestajnaJedinica()
        {
            FrmSmestajnaJedinica = new FrmSmestajnaJedinica();
            SmestajnaJedinicaFrmController = new SmestajnaJedinicaFrmController(FrmSmestajnaJedinica);
            SmestajnaJedinicaFrmController.OtvoriFormu();
        }



    }
}
