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

            StavkaEvidencije kriterijum = new StavkaEvidencije();
            kriterijum.Evidencija = e;

            List<IDomainObj> stareStavke = repository.GetAllByCondition(kriterijum);

            foreach (StavkaEvidencije stavka in stareStavke.Cast<StavkaEvidencije>())
            {
                if (stavka.StatusStavke == StatusStavke.DODATA)
                {
                    stavka.Evidencija = e;
                    repository.InsertInto(stavka);
                    Debug.WriteLine(stavka.StatusStavke);
                }
                if (stavka.StatusStavke == StatusStavke.OBRISANA)
                {
                    repository.Delete(stavka);
                    Debug.WriteLine(stavka.StatusStavke);
                }
                if (stavka.StatusStavke == StatusStavke.IZMENJENA)
                {
                    repository.Update(stavka);
                    Debug.WriteLine(stavka.StatusStavke);
                }
            }

            

            //foreach (StavkaEvidencije stavka in stareStavke.Cast<StavkaEvidencije>())
            //{
            //    repository.Delete(stavka);
            //}

            //long rb = 1;
            //foreach (StavkaEvidencije stavka in e.StavkeEvidencije)
            //{
            //    stavka.Evidencija = e;
            //    stavka.Rb = rb++;
            //    repository.InsertInto(stavka);
            //}



        }
    }
}
