using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class KomentarSlobJedinice
    {
        public SmestajnaJedinica SmestajnaJedinica { get; set; }

        public EvidencijaRez Evidencija { get; set; }

        public decimal IznosUsluge { get; set; }
    }
}
