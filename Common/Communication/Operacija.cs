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
        VratiListuSviVlasnik,

        // Evidencija rezervacija
        KreirajEvidencijaRez,
        PretraziEvidencijaRez,
        PromeniEvidencijaRez,
        VratiListuEvidencijaRez,

        // Smestajna jedinica
        VratiListuSviSmestajnaJedinica,
        KreirajSmestajnaJedinica,
        PretraziSmestajnaJedinica,
        PromeniSmestajnaJedinica,
        ObrisiSmestajnaJedinica,
        VratiListuSmestajnaJedinica,


        // Korisnik (gost)
        VratiListuSviKorinsik,

        // Tip smestaja
        VratiListuSviTipSmestaja,

        // Izvor ocene
        UbaciIzvorOcene,
        PromeniIzvorOcene,
    }
}
