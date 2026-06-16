using Client.Session;
using Client.UserControls;
using Common.Domain;
using Common.Domain.Enums;
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
            PopuniSmestajnaJedinica();
            PopuniCMBVrstaUsluge();

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
                    new List<DateOnly>()); // PRAZNO

                UC.FlpKalendari.Controls.Add(kalendar);
            }


        }

        public List<DateOnly> GetBusyDates(List<StavkaEvidencije> stavke)
        {
            List<DateOnly> dates = new List<DateOnly>();

            foreach (var s in stavke)
            {
                for (DateOnly d = s.Dolazak; d <= s.Odlazak; d = d.AddDays(1))
                {
                    dates.Add(d);
                }
            }

            return dates.Distinct().ToList();
        }
        private void PopuniSmestajnaJedinica()
        {
            UC.CmbSmestajnaJedinica.DataSource = Koordinator.Instance.ListaSmestajnaJedinica;
            UC.CmbSmestajnaJedinica.DisplayMember = "Naziv";
            UC.CmbSmestajnaJedinica.Visible = true;
        }
        private void PopuniCMBVrstaUsluge()
        {
            UC.CmbVrstaUsluge.DataSource = Enum.GetValues(typeof(VrstaUsluge));
            UC.CmbVrstaUsluge.Visible = true;
        }

    }
}
