using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.IzvorOceneSO
{
    public class UbaciIzvorOceneSO : SystemOperationBase
    {
        private IzvorOcene izvor;

        public UbaciIzvorOceneSO(IzvorOcene izvorOcene)
        {
            this.izvor = izvorOcene;
        }

        public IzvorOcene Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            long id = repository.InsertIntoOutput(izvor);
            Result = izvor;
            Result.Id = id;

        }
    }
}
