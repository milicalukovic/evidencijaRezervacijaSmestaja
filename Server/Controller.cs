using Common.Communication;
using Common.Domain;
using Server.SystemOperation.EvidencijaRezSO;
using Server.SystemOperation.IzvorOceneSO;
using Server.SystemOperation.KorisnikSO;
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
            PrijaviVlasnikaSO so = new PrijaviVlasnikaSO(vl);
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
            throw new Exception("Korisničko ime i šifra nisu ispravni!");
        }
        internal void OdjaviVlasnik(Vlasnik vlasnik)
        {
            ulogovani.Remove(vlasnik);
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
            KreirajSmestajnuJedinicuSO so = new KreirajSmestajnuJedinicuSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
            return so.Result;
        }
        internal void PromeniSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            PromeniSmestajnuJedinicuSO so = new PromeniSmestajnuJedinicuSO(smestajnaJedinica);
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
            PretraziSmestajnuJedinicuSO so = new PretraziSmestajnuJedinicuSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
            return so.Result;
        }
        internal void ObrisiSmestajnaJedinica(SmestajnaJedinica smestajnaJedinica)
        {
            ObrisiSmestajnuJedinicuSO so = new ObrisiSmestajnuJedinicuSO(smestajnaJedinica);
            so.ExecuteTemplate() ;
        }
        internal object VratiListuEvidencijaRez(EvidencijaRez evidencijaRez)
        {
            VratiListuEvidencijaRezSO so = new VratiListuEvidencijaRezSO(evidencijaRez);
            so.ExecuteTemplate() ;
            return so.ResultList;
        }
        internal object PretraziEvidencijaRez(EvidencijaRez evidencijaRez)
        {
            PretraziEvidencijuRezSO so = new PretraziEvidencijuRezSO(evidencijaRez);
            so.ExecuteTemplate() ;
            return so.Result;
        }
        internal object KreirajEvidencijaRez(EvidencijaRez evidencijaRez)
        {
            KreirajEvidencijuRezSO so = new KreirajEvidencijuRezSO(evidencijaRez);
            so.ExecuteTemplate() ;
            return so.Result;
        }
        internal object VratiListuSviKorisnik(Korisnik korisnik)
        {
            VratiListuSviKorisnikSO so = new VratiListuSviKorisnikSO(korisnik);
            so.ExecuteTemplate() ;
            return so.ResultList;
        }
        internal void UkloniEvidencijaRez(EvidencijaRez evidencijaRez)
        {
            UkloniEvidencijuRezSO so = new UkloniEvidencijuRezSO(evidencijaRez);
            so.ExecuteTemplate() ;
        }
        internal void PromeniEvidencijaRez(EvidencijaRez evidencijaRez)
        {
            PromeniEvidencijuRezSO so = new PromeniEvidencijuRezSO(evidencijaRez);
            so.ExecuteTemplate() ;
        }
        internal object DodajKorisnik(Korisnik korisnik)
        {
            DodajKorisnikaSO so = new DodajKorisnikaSO(korisnik);
            so.ExecuteTemplate() ;
            return so.Result;
        }
    }
}
