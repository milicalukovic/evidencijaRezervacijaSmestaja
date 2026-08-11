using Common.Domain;
using Common.Domain.Enums;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class PromeniEvidencijuRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public PromeniEvidencijuRezSO (EvidencijaRez e)
        {
            this.e = e;
        }
        protected override void ExecuteConcreteOperation()
        {
            // učitaj trenutne stavke iz baze pre primene promena
            var kriterijum = new StavkaEvidencije
            {
                Evidencija = new EvidencijaRez { Id = e.Id }
            };

            var stariObj = repository.GetAllByCondition(kriterijum);
            List<StavkaEvidencije> stareStavke = stariObj?.Cast<StavkaEvidencije>().ToList() ?? new List<StavkaEvidencije>();

            repository.Update(e);

            foreach (StavkaEvidencije stavka in e.StavkeEvidencije)
            {
                stavka.Evidencija = e;
                stavka.IzracunajIznose(); //pre cuvanja u bazi
                if (stavka.StatusStavke == StatusStavke.DODATA)
                {
                    stavka.Evidencija = e;
                    repository.InsertInto(stavka);
                }
                if (stavka.StatusStavke == StatusStavke.OBRISANA)
                {
                    repository.Delete(stavka);
                }
                if (stavka.StatusStavke == StatusStavke.IZMENJENA)
                {
                    repository.Update(stavka);
                }
                Debug.WriteLine(stavka.StatusStavke +" "+ stavka.Korisnik.Ime);
            }
            try
            {
                NotifikacijaService servis = new NotifikacijaService();
                // prosledi stare stavke da servis može da detektuje promene poput uplate avansa
                servis.ObradiPromene(e, stareStavke);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Greška pri slanju mejla: {ex.Message}");
            }
        }
    }
}
