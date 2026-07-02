using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    public class VratiListuSviEvidencijaRezSO : SystemOperationBase  //za svakodnevno slanje podsetnika za uplatu avansa
    {
        public List<EvidencijaRez> ResultList { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            //ucita evidencije
            List<EvidencijaRez> lista = repository.GetAll(new EvidencijaRez()).Cast<EvidencijaRez>().ToList();
            ResultList = lista;


            //za svaku evidenciju ucita stavke
            foreach (EvidencijaRez evidencija in ResultList)
            {
                StavkaEvidencije stavka = new StavkaEvidencije();
                stavka.Evidencija = evidencija;

                List<IDomainObj> listaStavki = repository.GetAllByCondition(stavka);
                evidencija.StavkeEvidencije = listaStavki.Cast<StavkaEvidencije>().ToList();

                //dodajemo jer se za svaku stavku u getAll evidencija = new evidencija i ne cuvaju se podaci o vlasniku koji su potrebni za mejl
                foreach (var s in evidencija.StavkeEvidencije)
                {
                    s.Evidencija = evidencija;
                }
            }
        }
    }
}
