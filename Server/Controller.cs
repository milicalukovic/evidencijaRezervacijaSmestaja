using Common.Domain;
using Server.SystemOperation.VlasnikSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private static Controller instance;

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        private Controller() { }
        public Vlasnik PrijaviVlasnik(Vlasnik vl)
        {
            PrijaviVlasnikSO so = new PrijaviVlasnikSO(vl);
            so.ExecuteTemplate();
            return so.Result;
        }
        
    }
}
