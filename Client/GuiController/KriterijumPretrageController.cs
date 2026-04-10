using Client.Forms;
using Client.Session;
using Common.Communication;
using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class KriterijumPretrageController
    {
        private FrmKriterijumPretrageEvidencijaRez Frm;

        public KriterijumPretrageController(FrmKriterijumPretrageEvidencijaRez Frm)
        {
            this.Frm = Frm;
        }

        internal void OtvoriFormu()
        {
            Frm.Show();
        }

        internal void PretraziEvidencijeRezPoKriterijumima()
        {
            EvidencijaRez evidencija = new EvidencijaRez();
            evidencija.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
            if (!Frm.TxtSmestajNaziv.Text.Trim().IsNullOrEmpty())
            {
                evidencija.SmestajnaJedinica = new SmestajnaJedinica();
                evidencija.SmestajnaJedinica.Naziv = Frm.TxtSmestajNaziv.Text.Trim();
            }
            if (!Frm.TxtBrLicneKarte.Text.Trim().IsNullOrEmpty())
            {
                StavkaEvidencije stavka = new StavkaEvidencije();
                stavka.Evidencija = evidencija;
                stavka.Korisnik = new Korisnik();
                stavka.Korisnik.BrLicneKarte = Frm.TxtBrLicneKarte.Text.Trim();

                evidencija.StavkeEvidencije.Add(stavka);
            }
            if (Frm.NumericMesec.Value > 0)
            {
                int mesec = (int)Frm.NumericMesec.Value;
                int godina = (int)Frm.NumericGodina.Value;

                evidencija.Mesec = new DateOnly(godina, mesec, 1); //za bazu
            }
            Debug.WriteLine("WHERE: " + evidencija.WhereClause);

            if (!Koordinator.Instance.ListaEvidencijaRezervacija.IsNullOrEmpty() && evidencija.WhereClause.Contains("AND")) //pretrazi samo ako postoji bar 1 evidencija ulogovanog vlasnika i ako je uneo bar jedan kriterijum
            {
                Odgovor serverOdg = Communication.Instance.VratiListuEvidencijaRez(evidencija);
                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    List<EvidencijaRez> lista = (List<EvidencijaRez>)serverOdg.Result;

                    if (!lista.IsNullOrEmpty())
                    {
                        Koordinator.Instance.GlavnaFrmController.PrikaziEvidencije();  //prikaze UC
                        Koordinator.Instance.PrikazEvidencijaRezController.PretraziEvidencijeRezPoKriterijumima(lista); //prikaze u tabeli samo po kriterijumu
                        Frm.Close();
                        return;
                    }
                    
                }
            }
            MessageBox.Show(Frm, "Sistem ne moze da nadje evidencije rezervacija po zadatim kriterijumima.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Frm.Close();

        }
    }
}
