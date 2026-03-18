using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
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

        
    }
}
