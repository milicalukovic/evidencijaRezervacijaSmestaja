using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.TipSmestajaSO
{
    public class VratiListuSviTipSmestajaSO : SystemOperationBase
    {
        private TipSmestaja tip;
        public List<TipSmestaja> ResultList {  get; set; }
        public VratiListuSviTipSmestajaSO(TipSmestaja tip)
        {
            this.tip = tip;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IDomainObj> Tipovi = repository.GetAll(tip);
            ResultList = Tipovi.Cast<TipSmestaja>().ToList();
        }
    }
}
