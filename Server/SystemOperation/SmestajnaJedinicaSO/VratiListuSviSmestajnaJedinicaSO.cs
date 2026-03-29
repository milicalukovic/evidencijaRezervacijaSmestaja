using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SmestajnaJedinicaSO
{
    internal class VratiListuSviSmestajnaJedinicaSO : SystemOperationBase
    {
        private SmestajnaJedinica sj;
        public List<SmestajnaJedinica> ResultList { get; set; }
        public VratiListuSviSmestajnaJedinicaSO(SmestajnaJedinica sj) 
        {
            this.sj = sj;
        }
        protected override void ExecuteConcreteOperation() //vraca sve smestajne jedinice koje je kreirao vlasnik koji je prijavljen
        {
            List<SmestajnaJedinica> lista = repository.GetAll(sj).Cast<SmestajnaJedinica>().ToList();
            ResultList = lista.Where(x => x.Vlasnik.Equals(this.sj.Vlasnik)).ToList(); 
        }
    }
}
