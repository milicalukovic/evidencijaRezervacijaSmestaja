using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class PromeniEvidencijaRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public PromeniEvidencijaRezSO (EvidencijaRez e)
        {
            this.e = e;
        }
        protected override void ExecuteConcreteOperation()
        {
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
        }
    }
}
