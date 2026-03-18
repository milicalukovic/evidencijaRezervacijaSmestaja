using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Zahtev //salje klijent, prima server
    {
        public Operation Operation { get; set; }
        public object Argument { get; set; }
    }
}
