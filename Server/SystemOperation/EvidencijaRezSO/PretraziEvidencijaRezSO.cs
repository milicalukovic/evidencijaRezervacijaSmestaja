using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class PretraziEvidencijaRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public EvidencijaRez Result { get; set; }
        public PretraziEvidencijaRezSO(EvidencijaRez e)
        {
            this.e = e;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<EvidencijaRez> lista = repository.GetAllByCondition(e).Cast<EvidencijaRez>().ToList();
            Result = lista.FirstOrDefault();

            if (Result == null)
                return;

            StavkaEvidencije stavka = new StavkaEvidencije();
            stavka.Evidencija = Result;
            stavka.StatusStavke = StatusStavke.BEZ;

            List<IDomainObj> listaStavki = repository.GetAllByCondition(stavka);
            Result.StavkeEvidencije = listaStavki.Cast<StavkaEvidencije>().ToList();
        }
    }
}
