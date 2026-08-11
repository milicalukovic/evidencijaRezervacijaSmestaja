using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.VlasnikSO
{
    public class PrijaviVlasnikaSO : SystemOperationBase
    {
        private readonly Vlasnik vl;
        public Vlasnik Result { get; set; }
        public PrijaviVlasnikaSO(Vlasnik vl) 
        { 
            this.vl = vl;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<IDomainObj> list = repository.GetAllByCondition(vl); 
            Result = list.Cast<Vlasnik>().FirstOrDefault();
        }
    }
}
