using Client.Forms;
using Client.Model;
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
            Popuni_Txt_Cmb_Mesec();
            Frm.CmbMesec.Enabled = false;
            Frm.NumericGodina.Enabled = false;
            Frm.Show();
            
        }

        private void Popuni_Txt_Cmb_Mesec()
        {

            Frm.CmbMesec.DataSource = Enum.GetValues(typeof(NazivMeseca));

            Frm.CmbMesec.Format += (s, ev) =>
            {
                ev.Value = ev.ListItem.ToString();
            };

        }

        internal void OtvoriUnosPeriodaEvidencije()
        {
            if (Frm.CheckBox.Checked)
            {
                Frm.CmbMesec.Enabled = true;
                Frm.NumericGodina.Enabled = true;
            }
            else
            {
                Frm.CmbMesec.Enabled = false;
                Frm.NumericGodina.Enabled = false;
            }
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
                Odgovor serverOdg = Communication.Instance.VratiListuSviKorisnik(new Korisnik());
                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    Koordinator.Instance.ListaKorisnik = (List<Korisnik>)serverOdg.Result;
                }

                Korisnik trazeniKorisnik = Koordinator.Instance.ListaKorisnik
                                          ?.FirstOrDefault(k => k.BrLicneKarte == Frm.TxtBrLicneKarte.Text.Trim());

                if (trazeniKorisnik != null)
                {
                    evidencija.StavkeEvidencije.Add(new StavkaEvidencije
                        {
                            Korisnik = new Korisnik
                            {
                                Id = trazeniKorisnik.Id,
                                BrLicneKarte = trazeniKorisnik.BrLicneKarte
                            }
                            // NE postavljati Evidencija = evidencija da ne bi doslo do cikline reference
                        });
                }
                else
                {
                    MessageBox.Show(Frm, "Sistem ne moze da nadje korisnika po zadatom kriterijumu. Proverite uneti broj licne karte!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (Frm.CheckBox.Checked)
            {
                //uneto u pretragu
                int mesec = (int)(NazivMeseca)Frm.CmbMesec.SelectedItem;
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
                        Koordinator.Instance.GlavnaFrmController.PrikaziEvidencije(true);  //prikaze UC
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
