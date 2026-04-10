using Common.Domain;
using Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.EvidencijaRezSO
{
    internal class UkloniEvidencijaRezSO : SystemOperationBase
    {
        private EvidencijaRez e;
        public UkloniEvidencijaRezSO(EvidencijaRez e)
        {
            this.e = e;
        }

        protected override void ExecuteConcreteOperation()
        {
            repository.Delete(e);
        }
    }
}
