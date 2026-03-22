using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {
        private static Communication instance;

        public static Communication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Communication();
                }
                return instance;
            }

        }

        private Communication() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect() //povezivanje sa serverom

        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9000);
            serializer = new JsonNetworkSerializer(socket); //pravi stream readera i writera za komunikaciju
        }

        public Odgovor PrijaviVlasnik(Vlasnik vl)
        {
            Zahtev zahtev = new Zahtev
            {
                Argument = vl,
                Operation = Operation.PrijaviVlasnik
            };

            serializer.Send(zahtev); //saljemo zahtev kroz mrezu do servera

            //ocekujemo odgovor od servera
            Odgovor odgovor
                = serializer.Receive<Odgovor>(); //ostajemo na ovoj liniji sve dok ne dobijemo odgovor od servera

            //iz odgovora od servera uzimamo podatke i konvertujemo u konkretan tip koji nam treba
            //treba nam Vlasnik jer pokusavamo da se prijavimo 
            odgovor.Result = serializer.ReadType<Vlasnik>(odgovor.Result);

            return odgovor; //saljemo sta je odgovor od servera koji cemo dalje proveravati u GUIControlleru
        }

        internal void OdjaviVlasnik(Vlasnik ulogovaniVlasnik)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = ulogovaniVlasnik,
                Operation = Operation.OdjaviVlasnik
            };
            serializer.Send(klZahtev);
            socket.Close();
            Debug.WriteLine("Zaposleni se odjavljuje...");
            Environment.Exit(0);
        }

        internal Odgovor UbaciIzvorOcene(IzvorOcene izvor)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = izvor,
                Operation = Operation.UbaciIzvorOcene,
            };
            serializer.Send(klZahtev);
            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<IzvorOcene>(serverOdg.Result);
            return serverOdg;
            
        }

        ///////////////////////
        /// VRATI LISTU SVI
        ///////////////////////
        internal Odgovor VratiListuSviTipSmestaja(TipSmestaja tip)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = tip,
                Operation = Operation.VratiListuSviTipSmestaja,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<List<TipSmestaja>>(serverOdg.Result);
            return serverOdg;
        }
        internal Odgovor VratiListuSviSmestajnaJedinica(SmestajnaJedinica sj)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = sj,
                Operation = Operation.VratiListuSviSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<List<SmestajnaJedinica>>(serverOdg.Result);
            return serverOdg;
        }

        ///////////////////////
        /// SMESTAJNA JEDINICA
        ///////////////////////
        internal Odgovor KreirajSmestajnaJedinica(SmestajnaJedinica sj)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = sj,
                Operation = Operation.KreirajSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<SmestajnaJedinica>(serverOdg.Result);
            return serverOdg;

        }

        internal Odgovor PromeniSmestajnaJedinica(SmestajnaJedinica nova)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = nova,
                Operation = Operation.PromeniSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<SmestajnaJedinica>(serverOdg.Result);
            return serverOdg;
        }

        internal Odgovor VratiListuSmestajnaJedinica(SmestajnaJedinica filtrirana)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = filtrirana,
                Operation = Operation.VratiListuSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<List<SmestajnaJedinica>>(serverOdg.Result);
            return serverOdg;
        }

        internal Odgovor PretraziSmestajnaJedinica(SmestajnaJedinica izabranaSJ)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = izabranaSJ,
                Operation = Operation.PretraziSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            serverOdg.Result = serializer.ReadType<SmestajnaJedinica>(serverOdg.Result);
            return serverOdg;
        }

        internal Odgovor ObrisiSmestajnaJedinica(SmestajnaJedinica izabranaSJ)
        {
            Zahtev klZahtev = new Zahtev
            {
                Argument = izabranaSJ,
                Operation = Operation.ObrisiSmestajnaJedinica,
            };
            serializer.Send(klZahtev);

            Odgovor serverOdg = serializer.Receive<Odgovor>();
            return serverOdg;
        }
    }
}
