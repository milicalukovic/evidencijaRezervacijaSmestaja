using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Server.Services
{
    public class NotifikacijaService
    {
        public void ObradiPromene(EvidencijaRez evidencija, List<StavkaEvidencije> stareStavke = null)
        {
            EmailService emailService = new EmailService();

            foreach (var stavka in evidencija.StavkeEvidencije)
            {
                if (!TrebaSlatiMailZaStavku(stavka)) //izbegni duplo slanje mejla za rez koja traje u prethodnom mesecu, a odlazak je u ovom mesecu
                    continue;
                if (string.IsNullOrWhiteSpace(stavka.Korisnik?.Email))
                {
                    continue; //gosti koji nemaju email se preskacu
                }

                if (stavka.StatusStavke == StatusStavke.DODATA)
                {
                    PosaljiNovuRezervaciju(stavka, emailService);
                }

                if (stavka.StatusStavke == StatusStavke.IZMENJENA)
                {
                    // detektuj da li je jedina promena označavanje avansa kao uplaćen (ranije nije bio uplaćen -> sada jeste)
                    bool poslatZahvalniMail = false;
                    if (stareStavke != null)
                    {
                        var stara = stareStavke.FirstOrDefault(s => s.Rb == stavka.Rb && s.Evidencija.Id == stavka.Evidencija.Id);
                        if (stara != null && !stara.UplacenAvans && stavka.UplacenAvans)
                        {
                            PosaljiZahvaluZaAvans(stavka, emailService);
                            poslatZahvalniMail = true;
                        }
                    }

                    if (!poslatZahvalniMail)
                    {
                        PosaljiIzmenuRezervacije(stavka, emailService);
                    }
                }

                if (stavka.StatusStavke == StatusStavke.OBRISANA)
                {
                    PosaljiBrisanjeRezervacije(stavka, emailService);
                }
            }
        }
        private bool TrebaSlatiMailZaStavku(StavkaEvidencije stavka)
        {
            DateOnly prviDanMeseca = stavka.Evidencija.Mesec;

            // rezervacija je počela pre meseca ove evidencije
            bool pocelaRanije = stavka.Dolazak < prviDanMeseca;

            // izuzetak: počela poslednjeg dana prethodnog meseca
            bool poslednjiDanPrethodnogMeseca =
                stavka.Dolazak == prviDanMeseca.AddDays(-1);

            if (pocelaRanije && !poslednjiDanPrethodnogMeseca)
                return false;

            return true;
        }
        private string GetReplyTo(StavkaEvidencije stavka)
        {
            return stavka.Evidencija?.Vlasnik?.KorisnickoIme;
        }

        private void PosaljiNovuRezervaciju(StavkaEvidencije stavka, EmailService emailService)
        {
            string html = KreirajHtmlNoveRezervacije(stavka);

            string replyTo = GetReplyTo(stavka); 
            emailService.PosaljiMail(stavka.Korisnik.Email, "Potvrda rezervacije", html, replyTo);
        }

        private void PosaljiIzmenuRezervacije(StavkaEvidencije stavka, EmailService emailService)
        {
            string html = KreirajHtmlIzmene(stavka);
            string replyTo = GetReplyTo(stavka); 
            emailService.PosaljiMail(stavka.Korisnik.Email, "Izmena rezervacije", html, replyTo);
        }

        private void PosaljiBrisanjeRezervacije(StavkaEvidencije stavka, EmailService emailService)
        {
            string html = KreirajHtmlBrisanja(stavka);
            string replyTo = GetReplyTo(stavka); 
            emailService.PosaljiMail(stavka.Korisnik.Email, "Otkazana rezervacija", html, replyTo);
        }

        private void PosaljiZahvaluZaAvans(StavkaEvidencije stavka, EmailService emailService)
        {
            string html = KreirajHtmlZahvalnicaAvans(stavka);
            string replyTo = GetReplyTo(stavka);
            emailService.PosaljiMail(stavka.Korisnik.Email, "Hvala za uplatu avansa", html, replyTo);
        }
        public void PosaljiPodsetnikeZaAvans(EvidencijaRez evidencija, EmailService emailService)
        {
            DateOnly danas = DateOnly.FromDateTime(DateTime.Today);

            foreach (var stavka in evidencija.StavkeEvidencije)
            {
                if (string.IsNullOrWhiteSpace(stavka.Korisnik?.Email))
                {
                    continue; //gosti koji nemaju email se preskacu
                }

                int danaDoDolaska = stavka.Dolazak.DayNumber - danas.DayNumber;

                Console.WriteLine(
                       $"Gost: {stavka.Korisnik?.Ime} " +
                       $"Dolazak: {stavka.Dolazak} " +
                       $"Dana do dolaska: {danaDoDolaska} " +
                       $"Email: {stavka.Korisnik?.Email} " +
                       $"Avans: {stavka.UplacenAvans}");

                if (!stavka.UplacenAvans && 
                    (danaDoDolaska == 28 || danaDoDolaska == 14 || danaDoDolaska == 7)) 
                {
                    Console.WriteLine("SALJEM PODSETNIK!");
                    string html = KreirajHtmlAvansa(stavka);
                    string replyTo = GetReplyTo(stavka); 
                    emailService.PosaljiMail(stavka.Korisnik.Email, "Podsetnik za avans", html, replyTo);
                }
            }
        }

        private string KreirajHtmlNoveRezervacije(StavkaEvidencije s)
        {
            string link = KreirajGoogleCalendarLink(s);
            return $@"
            <h2>Potvrda rezervacije</h2>

            <p>Poštovani/a {s.Korisnik.Ime},</p>

            <p>uspešno je evidentirana Vaša rezervacija za {s.Evidencija?.SmestajnaJedinica?.Naziv}.</p>

            <p>Dolazak: {s.Dolazak:dd.MM.yyyy.}</p>

            <p>Odlazak: {s.Odlazak:dd.MM.yyyy.}</p>

            <p>Iznos rezervacije:
            {s.IznosRezervacije:N2} €</p>

            <p><b>Podaci za uplatu avansa</b></p>

            <p>Primalac: {s.Evidencija?.Vlasnik?.PrimalacUplate}</p>

            <p>Broj računa:
            {s.Evidencija?.Vlasnik?.BrojRacuna}</p>

            <p>Iznos avansa ({s.Evidencija?.ProcenatAvansa * 100:N0}%):
            {s.IznosAvansa:N2} €</p> 
            <p>
            <a href='{link}'>
            Dodaj u Google Calendar
            </a>
            </p>
            <p>Hvala Vam na ukazanom poverenju.</p>";
        }

        private string KreirajHtmlIzmene(StavkaEvidencije s)
        {
            string link = KreirajGoogleCalendarLink(s);
            return $@"
            <h2>Izmena rezervacije</h2>

            <p>Poštovani/a {s.Korisnik.Ime},</p>

            <p>rezervacija za {s.Evidencija?.SmestajnaJedinica?.Naziv} je izmenjena.</p>

            <p>Dolazak: {s.Dolazak:dd.MM.yyyy.}</p>

            <p>Odlazak: {s.Odlazak:dd.MM.yyyy.}</p>

            <p>Iznos rezervacije:
            {s.IznosRezervacije:N2} €</p>

            <p><b>Ukoliko niste izvršili uplatu avansa, podaci za uplatu su</b></p>

            <p>Primalac: {s.Evidencija?.Vlasnik?.PrimalacUplate}</p>

            <p>Broj računa: {s.Evidencija?.Vlasnik?.BrojRacuna}</p>

            <p>Iznos avansa ({s.Evidencija?.ProcenatAvansa * 100:N0}%):
            {s.IznosAvansa:N2} €</p>

            <p>
            <a href='{link}'>
            Dodaj u Google Calendar
            </a>
            </p>

            <p> Hvala Vam na ukazanom poverenju.</p> ";
        }

        private string KreirajHtmlBrisanja(StavkaEvidencije s)
        {
            return $@"
            <h2>Otkazana rezervacija</h2>

            <p>Poštovani/a {s.Korisnik.Ime},</p>

            <p>rezervacija za {s.Evidencija?.SmestajnaJedinica?.Naziv} u periodu {s.Dolazak:dd.MM.yyyy} - {s.Odlazak:dd.MM.yyyy.} je otkazana.</p>";
        }

        private string KreirajHtmlAvansa(StavkaEvidencije s)
        {
            return $@"
            <h2>Podsetnik za avans</h2>

            <p>Poštovani/a {s.Korisnik.Ime},</p>

            <p>Podsećamo Vas da za rezervaciju od {s.Dolazak:dd.MM.yyyy.} još uvek nije evidentirana uplata avansa.</p>

            <p><b>Podaci za uplatu avansa</b></p>

            <p>Primalac: {s.Evidencija?.Vlasnik?.PrimalacUplate}</p>

            <p>Broj računa:
            {s.Evidencija?.Vlasnik?.BrojRacuna}</p>

            <p>Iznos avansa ({s.Evidencija?.ProcenatAvansa * 100:N0}%):
            {s.IznosAvansa:N2} €</p>

            <p>Srdačan pozdrav!</p>";
        }

        private string KreirajHtmlZahvalnicaAvans(StavkaEvidencije s)
        {
            return $@"
            <h2>Hvala za uplatu avansa</h2>

            <p>Poštovani/a {s.Korisnik.Ime},</p>

            <p>Hvala Vam što ste uplatili avans za rezervaciju u periodu {s.Dolazak:dd.MM.yyyy} - {s.Odlazak:dd.MM.yyyy.}.</p>

            <p>Iznos uplaćenog avansa: {s.IznosAvansa:N2} €</p>

            <p>Srdačan pozdrav!</p>";
        }

        private string KreirajGoogleCalendarLink(StavkaEvidencije s)
        {
            string naslov = Uri.EscapeDataString($"Rezervacija {s.Evidencija.SmestajnaJedinica.Naziv}");

            string start = s.Dolazak
                    .ToDateTime(TimeOnly.MinValue)
                    .ToString("yyyyMMdd");

            string end = s.Odlazak
                    .ToDateTime(TimeOnly.MinValue)
                    .ToString("yyyyMMdd");

            return
                $"https://calendar.google.com/calendar/render?action=TEMPLATE" +
                $"&text={naslov}" +
                $"&dates={start}/{end}";
        }
    }
}
