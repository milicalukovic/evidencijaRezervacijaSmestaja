using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SmestajnaJedinicaSO
{
    internal class PromeniSmestajnuJedinicuSO : SystemOperationBase
    {
        private SmestajnaJedinica sj;
        public PromeniSmestajnuJedinicuSO(SmestajnaJedinica sj)
        {
            this.sj = sj; 
        }

        protected override void ExecuteConcreteOperation()
        {
            repository.Update(sj);
        }
    }
}
