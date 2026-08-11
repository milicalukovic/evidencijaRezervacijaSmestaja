using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.KorisnikSO
{
    internal class DodajKorisnikaSO : SystemOperationBase
    {
        private Korisnik k;
        public Korisnik Result { get; set; }
        public DodajKorisnikaSO(Korisnik k)
        {
            this.k = k;
        }
        protected override void ExecuteConcreteOperation()
        {
            long id = repository.InsertIntoOutput(k);
            Result = k;
            Result.Id = id;
        }
    }
}
