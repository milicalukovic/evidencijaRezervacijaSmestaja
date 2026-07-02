using Client.Model;
using Client.Session;
using Client.UserControls;
using Common.Communication;
using Common.Domain;
using Common.Domain.Enums;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class ProveraRaspolozivostiController
    {
        private UCProveraRaspolozivosti UC;

        public ProveraRaspolozivostiController(UCProveraRaspolozivosti ucProvera)
        {
            this.UC = ucProvera;
        }
        internal void PopuniPodatke()
        {

            UC.CmbSmestajnaJedinica.Visible = false;
            UC.CmbVrstaUsluge.Visible = false;
            UC.NumericBrOsoba.Visible = false;
            UC.CmbSmestajnaJedinica.DropDownStyle = ComboBoxStyle.DropDownList;
            UC.CmbVrstaUsluge.DropDownStyle = ComboBoxStyle.DropDownList;
            UcitajKalendare();
        }

        private void UcitajKalendare()
        {
            UC.FlpKalendari.Controls.Clear();
            for (int i = 0; i < 12; i++)
            {
                DateTime month = DateTime.Today.AddMonths(i);

                var kalendar = new UCMesecniKalendar();
                var controller =
                    new MesecniKalendarController(kalendar);

                controller.InicijalizujKalendar(
                    month.Month,
                    month.Year,
                    new()); // PRAZNO

                UC.FlpKalendari.Controls.Add(kalendar);
            }


        }

        internal void Proveri()
        {
            SmestajnaJedinica? izabranaJedinica = null;

            if (UC.CheckBoxSmestajnaJedinica.Checked)
            {
                izabranaJedinica = (SmestajnaJedinica) UC.CmbSmestajnaJedinica.SelectedItem;
            }

            VrstaUsluge? izabranaUsluga = null;

            if (UC.CheckBoxVrstaUsluge.Checked)
            {
                izabranaUsluga = (VrstaUsluge) UC.CmbVrstaUsluge.SelectedItem;
            }

            decimal? brojOsoba = null;

            if (UC.CheckBoxBrOsoba.Checked)
            {
                brojOsoba = (decimal)UC.NumericBrOsoba.Value;
            }

            //validacija ako je izabrana sj
            if (izabranaJedinica != null)
            {
                if (izabranaUsluga != null && izabranaJedinica.OsnovnaVrstaUsluge > izabranaUsluga)
                {
                    MessageBox.Show(
                        $"{izabranaJedinica} ne podržava izabranu vrstu usluge. Minimalna podržana usluga je {izabranaJedinica.OsnovnaVrstaUsluge}.",
                        "NEDOZVOLJENA USLUGA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                if (brojOsoba != null && (brojOsoba < izabranaJedinica.Tip.MinKapacitet || brojOsoba > izabranaJedinica.Tip.MaxKapacitet))
                {
                    MessageBox.Show(
                        $"Nije moguće rezervisati {izabranaJedinica} za {brojOsoba} osoba.\n" +
                        $"Dozvoljen kapacitet je od " +
                        $"{izabranaJedinica.Tip.MinKapacitet} do " +
                        $"{izabranaJedinica.Tip.MaxKapacitet}.",
                        "NEDOZVOLJEN KAPACITET",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
        

            //jedinice koje odgovaraju pretrazi
            List<SmestajnaJedinica> relevantneJedinice = Koordinator.Instance.ListaSmestajnaJedinica
                .Where(j =>
                {
                    if (izabranaJedinica != null &&
                        j.Id != izabranaJedinica.Id)
                    {
                        return false;
                    }

                    if (izabranaUsluga != null &&
                        j.OsnovnaVrstaUsluge > izabranaUsluga)
                    {
                        return false;
                    }

                    if (brojOsoba != null &&
                       (brojOsoba < j.Tip.MinKapacitet ||
                        brojOsoba > j.Tip.MaxKapacitet))
                    {
                        return false;
                    }

                    return true;
                })
                .ToList();

            if (relevantneJedinice.Count == 0)
            {
                MessageBox.Show("Ne postoje smeštajne jedinice koje se slažu sa kriterijumima pretrage.", "OBAVEŠTENJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EvidencijaRez kriterijum = new EvidencijaRez
            {
                Vlasnik = Koordinator.Instance.UlogovaniVlasnik
            };
            if (izabranaJedinica != null)
            {
                kriterijum.SmestajnaJedinica = izabranaJedinica;
            }

            //vrati evidencije u narednih 12 meseci
            DateOnly odMeseca = new DateOnly( DateTime.Today.Year, DateTime.Today.Month, 1);
            kriterijum.OdMeseca = odMeseca;

            Odgovor odgovor = Communication.Instance.VratiListuEvidencijaRez(kriterijum);

            if (odgovor.ExceptionMessage != null || odgovor.Result == null)
            {
                MessageBox.Show("Sistem ne može da učita raspoloživost.","GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //pronalazi sve evidencije - filter samo sj ako se unese
            List<EvidencijaRez> evidencije = (List<EvidencijaRez>) odgovor.Result;

            //filtriranje evidencija po relevantnim sj
            List<EvidencijaRez> relevantne = evidencije
                    .Where(e =>
                        relevantneJedinice.Any(j =>
                            j.Id ==
                            e.SmestajnaJedinica.Id))
                    .ToList();

            //ukoliko ne postoje relevantne evidencije
            if (relevantne.Count == 0 && relevantneJedinice.Count > 0)
            {
                    if (UC.CheckBoxSmestajnaJedinica.Checked)
                    {
                        MessageBox.Show($"Izabrana smeštajna jedinica {(SmestajnaJedinica)UC.CmbSmestajnaJedinica.SelectedItem} je raspoloživa u svim terminima narednih godina. ", "OBAVEŠTENJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        String ispis = "";
                        foreach (SmestajnaJedinica sj in relevantneJedinice)
                        {
                            ispis += $"\n {sj} ";
                        }
                        MessageBox.Show("Relevantne smeštajne jedinice su: " + ispis + "\nOne su raspoložive u svim terminima narednih godina. ", "OBAVEŠTENJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }

            //racunanje ZAUZETOSTI za svaku relevantnu
            Dictionary<DateOnly, InfoRaspolozivosti> dostupnostPoDatumu = new();
            //za jedan datum vrednosti da li je slobodna svaka relevantna jedinica, ukupno relevantnih, info o slobodnim jedinicama

            foreach (var sj in relevantneJedinice) //za svaku jedinicu
            {
                for (int i = 0; i < 12; i++)       //narednih 12 meseci
                {
                    DateOnly mesec =
                        DateOnly.FromDateTime(
                            new DateTime(
                                DateTime.Today.AddMonths(i).Year,
                                DateTime.Today.AddMonths(i).Month,
                                1));

                    EvidencijaRez? evidencija =         //trazi evidenciju
                        relevantne.FirstOrDefault(e =>
                            e.SmestajnaJedinica.Id == sj.Id
                            &&
                            e.Mesec == mesec);

                    //ne postoji => ceo taj mesec je slobodan
                    if (evidencija == null)
                    {
                        DateOnly kraj = mesec.AddMonths(1).AddDays(-1);

                        for (DateOnly d = mesec;d <= kraj;d = d.AddDays(1))
                        {
                            if (!dostupnostPoDatumu.ContainsKey(d)) //ukoliko datum ne postoji vec
                            {
                                dostupnostPoDatumu[d] = new InfoRaspolozivosti();
                            }

                            var info = dostupnostPoDatumu[d];

                            info.UkupnoJedinica++;

                            decimal cena;
                            if (UC.CheckBoxVrstaUsluge.Checked)
                            {
                                info.IzabranaUsluga = (VrstaUsluge)izabranaUsluga;
                                cena = sj.CenaPoOsobi + sj.PovecanjeCenePoUsluzi 
                                    * ((int)izabranaUsluga - (int)sj.OsnovnaVrstaUsluge);
                            }
                            else
                            {
                                cena = sj.CenaPoOsobi;
                            }

                            info.SlobodneJedinice.Add(
                                new KomentarSlobJedinice
                                {
                                    SmestajnaJedinica = sj,
                                    Evidencija = null,
                                    IznosUsluge = cena
                                });
                        }

                        continue;
                    }
                    else
                    {
                        HashSet<DateOnly> zauzeti = new(); //svi datumi po stavkama koji su zauzeti 

                        foreach (var stavka in evidencija.StavkeEvidencije)
                        {
                            for (DateOnly d = stavka.Dolazak; d < stavka.Odlazak; d = d.AddDays(1))
                            {
                                zauzeti.Add(d);
                            }
                        }

                        DateOnly pocetak = evidencija.Mesec;
                        DateOnly kraj = pocetak.AddMonths(1).AddDays(-1);

                        for (DateOnly d = pocetak; d <= kraj; d = d.AddDays(1))
                        {

                            if (!dostupnostPoDatumu.ContainsKey(d)) //ukoliko datum ne postoji
                            {
                                dostupnostPoDatumu[d] = new InfoRaspolozivosti();
                            }

                            var info = dostupnostPoDatumu[d];
                            info.UkupnoJedinica++;

                            if (!zauzeti.Contains(d)) //za taj dan u mesecu DA LI JE SLOBODNA
                            {
                                decimal cena;
                                if (UC.CheckBoxVrstaUsluge.Checked)
                                {
                                    info.IzabranaUsluga = (VrstaUsluge)izabranaUsluga;
                                    cena =
                                    (evidencija.OsnovnaCenaPoOsobi +
                                                    evidencija.PovecanjeCenePoUsluzi * ((int)izabranaUsluga - (int)evidencija.OsnovnaVrstaUsluge))
                                     * evidencija.SezonskiKoeficijentCene;
                                }
                                else
                                {
                                    cena = evidencija.OsnovnaCenaPoOsobi * evidencija.SezonskiKoeficijentCene;
                                }

                                info.SlobodneJedinice.Add(
                                    new KomentarSlobJedinice
                                    {
                                        SmestajnaJedinica = evidencija.SmestajnaJedinica,
                                        Evidencija = evidencija,
                                        IznosUsluge = cena,
                                    });
                            }
                        }

                    }
                }
            }

            //racunanje FINALNOG STATUSA dana 
            foreach (var info in dostupnostPoDatumu.Values)
            {
                //koliko sj je slobodno tog datuma
                int slobodno = info.SlobodneJedinice.Count; 

                //koliko ima relevantnih sj
                int ukupno = info.UkupnoJedinica;

                if (slobodno == ukupno)
                {
                    info.Status = StatusRaspolozivosti.Slobodno;
                }
                else if (slobodno == 0)
                {
                    info.Status = StatusRaspolozivosti.PotpunoZauzeto;
                }
                else
                {
                    info.Status = StatusRaspolozivosti.DelimicnoZauzeto;
                }
            }

            // reload kalendara
            UC.FlpKalendari.Controls.Clear();

            for (int i = 0; i < 12; i++)
            {
                DateTime month = DateTime.Today.AddMonths(i);

                var kalendar = new UCMesecniKalendar();

                var controller = new MesecniKalendarController(kalendar);

                controller.InicijalizujKalendar( month.Month, month.Year, dostupnostPoDatumu);

                UC.FlpKalendari.Controls.Add(kalendar);
            }
        }

        internal void PrikaziCmbSmestajnaJedinica()
        {
            if (UC.CheckBoxSmestajnaJedinica.Checked)
            {
                UC.CmbSmestajnaJedinica.DataSource = Koordinator.Instance.ListaSmestajnaJedinica;
                UC.CmbSmestajnaJedinica.DisplayMember = "Naziv";
                UC.CmbSmestajnaJedinica.Visible = true;
            }
            else
            {
                UC.CmbSmestajnaJedinica.Visible = false;
            }
        }

        internal void PrikaziCmbVrstaUsluge()
        {
            if (UC.CheckBoxVrstaUsluge.Checked)
            {
                UC.CmbVrstaUsluge.DataSource = Enum.GetValues(typeof(VrstaUsluge));
                UC.CmbVrstaUsluge.Visible = true;
            }
            else
            {
                UC.CmbVrstaUsluge.Visible = false;
            }
        }

        internal void PrikaziNumBrojOsoba()
        {
            if (UC.CheckBoxBrOsoba.Checked) { 

                UC.NumericBrOsoba.Visible = true;
            }
            else
            {
                UC.NumericBrOsoba.Visible = false;
            }
        }

        
    }
}
