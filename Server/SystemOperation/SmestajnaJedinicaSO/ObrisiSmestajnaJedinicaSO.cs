using Common.Domain;
using Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SmestajnaJedinicaSO
{
    internal class ObrisiSmestajnaJedinicaSO : SystemOperationBase
    {
        private SmestajnaJedinica sj;
        public ObrisiSmestajnaJedinicaSO(SmestajnaJedinica sj)
        {
            this.sj = sj;
        }

        protected override void ExecuteConcreteOperation()
        {
            repository.Delete(sj);
        }
    }
}
