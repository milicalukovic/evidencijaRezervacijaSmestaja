using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class KreirajEvidencijuRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public EvidencijaRez Result { get; set; }
        public KreirajEvidencijuRezSO(EvidencijaRez e)
        {
            this.e = e;
        }
        protected override void ExecuteConcreteOperation()
        {
            long id = repository.InsertIntoOutput(e);
            Result = e;
            Result.Id = id;
        }
    }
}
