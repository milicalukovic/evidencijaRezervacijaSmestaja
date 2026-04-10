using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.KorisnikSO
{
    internal class VratiListuSviKorisnikSO : SystemOperationBase
    {
        private Korisnik k;
        public List<Korisnik> ResultList { get; set; }
        public VratiListuSviKorisnikSO(Korisnik k)
        {
            this.k = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IDomainObj> Tipovi = repository.GetAll(k);
            ResultList = Tipovi.Cast<Korisnik>().ToList();
        }
    }
}
