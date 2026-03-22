using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SmestajnaJedinicaSO
{

    internal class VratiListuSmestajnaJedinicaSO : SystemOperationBase
    {
        private SmestajnaJedinica sj;
        public List<SmestajnaJedinica> ResultList;
        public VratiListuSmestajnaJedinicaSO(SmestajnaJedinica sj)
        {
            this.sj = sj;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<SmestajnaJedinica> lista = repository.GetAllByCondition(sj).Cast<SmestajnaJedinica>().ToList();
            ResultList = lista;
        }
    }
}
