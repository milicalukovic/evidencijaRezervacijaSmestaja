using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class InfoRaspolozivosti
    {
        public StatusRaspolozivosti Status { get; set; }

        // sve relevantne jedinice tog datuma
        public int UkupnoJedinica { get; set; }

        // samo slobodne
        public List<KomentarSlobJedinice> SlobodneJedinice = new();
        public VrstaUsluge IzabranaUsluga { get; set; } = VrstaUsluge.Noćenje;
    }
    
}
