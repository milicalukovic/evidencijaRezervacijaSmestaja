using Common.Communication;
using Common.Domain;
using Server.SystemOperation.IzvorOceneSO;
using Server.SystemOperation.SmestajnaJedinicaSO;
using Server.SystemOperation.TipSmestajaSO;
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

        private List<Vlasnik> ulogovani = new List<Vlasnik>();
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
            if (so.Result != null)
            {
                if (ulogovani.Contains(so.Result))
                {
                    throw new Exception("Vlasnik je vec ulogovan!");
                }
                ulogovani.Add(so.Result);
                return so.Result;
            }
            throw new Exception("Korisnicno ime i sifra nisu ispravni!");
        }

        internal object UbaciIzvorOcene(IzvorOcene izvorOcene)
        {
            UbaciIzvorOceneSO so1 = new UbaciIzvorOceneSO(izvorOcene);
            so1.ExecuteTemplate();
            return so1.Result;
        }

        internal object VratiListuSviTipSmestaja(TipSmestaja tipSmestaja)
        {
            VratiListuSviTipSmestajaSO so = new VratiListuSviTipSmestajaSO(tipSmestaja);
            so.ExecuteTemplate();
            return so.ResultList;
        }

        internal object VratiListuSviSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            VratiListuSviSmestajnaJedinicaSO so = new VratiListuSviSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate();
            return so.ResultList;
        }

        internal object KreirajSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            KreirajSmestajnaJedinicaSO so = new KreirajSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
            return so.Result;
        }

        internal void PromeniSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            PromeniSmestajnaJedinicaSO so = new PromeniSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
        }

        internal object VratiListuSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            VratiListuSmestajnaJedinicaSO so = new VratiListuSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
            return so.ResultList;
        }

        internal object PretraziSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            PretraziSmestajnaJedinicaSO so = new PretraziSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
            return so.Result;
        }

        internal void ObrisiSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            ObrisiSmestajnaJedinicaSO so = new ObrisiSmestajnaJedinicaSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
        }

        internal void OdjaviVlasnik(Vlasnik vlasnik)
        {
            ulogovani.Remove(vlasnik);
        }
    }
}
