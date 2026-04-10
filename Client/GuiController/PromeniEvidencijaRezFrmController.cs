using Client.Forms;
using Client.Session;
using Common.Communication;
using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class PromeniEvidencijaRezFrmController
    {
        private FrmPromeniEvidencijaRez Frm;

        public PromeniEvidencijaRezFrmController(FrmPromeniEvidencijaRez FrmPromeniEvidencijaRez)
        {
            this.Frm = FrmPromeniEvidencijaRez;
        }

        internal void OtvoriFormu(EvidencijaRez e)
        {
            OsnovniPodaciEvidencijeRez(e);
            Frm.Show();
        }

        internal void OsnovniPodaciEvidencijeRez(EvidencijaRez e)
        {
            Frm.PanelEvidencije.Controls.Clear();
            Koordinator.Instance.InicijalizujUCOsnovniPodaciEvidencijaRez();
            Koordinator.Instance.OsnovniPodaciEvidencijaRezController.PopuniPodatke(e);
            Frm.PanelEvidencije.Controls.Add(Koordinator.Instance.UCOsnovniPodaciEvidencijaRez);
        }
        internal void StavkeEvidencijeRez()
        {
            Frm.PanelEvidencije.Controls.Clear();
            Koordinator.Instance.InicijalizujUCStavkeEvidencijaRez();
            Koordinator.Instance.StavkeEvidencijaRezUCController.PopuniPodatke();
            Frm.PanelEvidencije.Controls.Add(Koordinator.Instance.UCStavkeEvidencijaRez);
        }
        internal void ObrisiEvidenciju() //pre nego sto se desilo promeniEvidencijaRez
        {
            if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.KreiranaEvidencija))
            {
                Odgovor odg = Communication.Instance.ObrisiEvidencijaRez(Koordinator.Instance.KreiranaEvidencija);

                if (odg.ExceptionMessage != null)
                    throw new Exception(odg.ExceptionMessage);

                Koordinator.Instance.KreiranaEvidencija = null; //osvezi
                Koordinator.Instance.IzmenjenaEvidencija = null;
            }
            if(Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.IzabranaEvidencija))
            {
                Koordinator.Instance.IzabranaEvidencija = null; //osvezi
                Koordinator.Instance.IzmenjenaEvidencija = null;
            }
        }

        internal void ZatvoriFormu()
        {
            Koordinator.Instance.GlavnaFrmController.PrikaziEvidencije();
            Frm.Close();
        }
    }
}
