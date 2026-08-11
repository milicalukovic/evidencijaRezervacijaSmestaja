using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SmestajnaJedinicaSO
{
    public class KreirajSmestajnuJedinicuSO : SystemOperationBase
    {
        private SmestajnaJedinica sj;
        public SmestajnaJedinica Result { get; set; }
        public KreirajSmestajnuJedinicuSO(SmestajnaJedinica sj) 
        {
            this.sj = sj;
        }
        protected override void ExecuteConcreteOperation()
        {
            long id = repository.InsertIntoOutput(sj);
            Result = sj;
            Result.Id = id;
        }
    }
}
