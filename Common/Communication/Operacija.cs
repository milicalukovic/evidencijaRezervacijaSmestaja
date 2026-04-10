using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        // Vlasnik
        PrijaviVlasnik,
        OdjaviVlasnik,
        //VratiListuSviVlasnik,

        // Evidencija rezervacija
        KreirajEvidencijaRez,
        PretraziEvidencijaRez,
        PromeniEvidencijaRez,
        VratiListuEvidencijaRez,

        ObrisiEvidencijaRez,

        // Smestajna jedinica
        VratiListuSviSmestajnaJedinica,
        KreirajSmestajnaJedinica,
        PretraziSmestajnaJedinica,
        PromeniSmestajnaJedinica,
        ObrisiSmestajnaJedinica,
        VratiListuSmestajnaJedinica,


        // Korisnik (gost)
        VratiListuSviKorinsik,
        DodajKorisnik,

        // Tip smestaja
        VratiListuSviTipSmestaja,

        // Izvor ocene
        UbaciIzvorOcene
    }
}
