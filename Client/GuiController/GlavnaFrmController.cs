using Client.Forms;
using Client.Session;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class GlavnaFrmController
    {
        private FrmGlavna frmGlavna;

        public GlavnaFrmController(FrmGlavna frmGlavna)
        {
            this.frmGlavna = frmGlavna;
        }
        internal void PrikaziSmestajneJedinice()
        {
            frmGlavna.GlavnaPanel.Controls.Clear();
            Koordinator.Instance.InicijalizujUCPrikazSJ();    //INICIJALIZACIJA
            Koordinator.Instance.SmestajnaJedinicaUCController.PopuniPodatke(); //POPUNJAVAMO PODATKE
            frmGlavna.GlavnaPanel.Controls.Add(Koordinator.Instance.UCPrikazSmestajnaJedinica); // PRIKAZUJEMO UC
        }
        internal void UbaciIzvorOcene()
        {
            Koordinator.Instance.OtvoriFrmIzvorOcene();
        }
        internal void OdjaviVlasnik()
        {
            Communication.Instance.OdjaviVlasnik(Koordinator.Instance.UlogovaniVlasnik);
        }

    }
}
