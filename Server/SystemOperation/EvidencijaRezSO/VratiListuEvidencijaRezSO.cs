using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class VratiListuEvidencijaRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public List<EvidencijaRez> ResultList { get; set; }
        
        public VratiListuEvidencijaRezSO (EvidencijaRez e)
        {
            this.e = e;
        }
        protected override void ExecuteConcreteOperation()
        {
            //ucita evidencije
            List<EvidencijaRez> lista = repository.GetAllByCondition(e).Cast<EvidencijaRez>().ToList();
            ResultList = lista;


            //za svaku evidenciju ucita stavke
            foreach (EvidencijaRez evidencija in ResultList)
            {
                StavkaEvidencije stavka = new StavkaEvidencije();
                stavka.Evidencija = evidencija;

                List<IDomainObj> listaStavki = repository.GetAllByCondition(stavka);
                evidencija.StavkeEvidencije = listaStavki.Cast<StavkaEvidencije>().ToList();
            }
        }
    }
}
