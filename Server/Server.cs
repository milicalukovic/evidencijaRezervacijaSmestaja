using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket socket;
        private List<ClientHandler> handlers;
        private FrmServer frm;

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            handlers = new List<ClientHandler>();
            frm = new FrmServer();
        }

        public void Start()
        {
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            socket.Bind(endPoint);
            Debug.WriteLine("Server pokrenut");
            socket.Listen(); //osluskujemo mrezu

            Thread nitServera = new Thread(AcceptClient);
            nitServera.Start();
        }



        private void AcceptClient() //prihvatamo klijente 
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = socket.Accept(); // klijent poslao zahtev
                    Debug.WriteLine("Klijent se povezao!");
                    ClientHandler handler = new ClientHandler(klijentskiSoket, this); //prosledjujemo Client Handleru konkretnog klijenta koji se povezao i pokazivac na servera
                    handlers.Add(handler);


                    //napraviti nit za svakog handlera da se zahtevi obradjuju na posebnim nitima
                    Thread obradaZahteva = new Thread(handler.HandleRequest);
                    obradaZahteva.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }

        }
        //metoda koja resava sta se desava kada zatvormo formu server?
        public void Stop() //kada pritisnemo stop na serverskoj formi
        {
            List<ClientHandler> copy = new List<ClientHandler>(handlers);
            foreach (ClientHandler handler in copy)
            {

                handler.CloseSocket();

            }
            handlers.Clear();
            socket.Close();

            Debug.WriteLine("Server zaustavljen");
        }

        private object _lock = new object(); //sinhronizacija niti, ako je jedna nit obrade zahteva usla u removeClient nijedna druga nit nece uci dok ona ne zavrsi



        internal void RemoveClient(ClientHandler clientHandler) //izbacuje konkretnog handlera iz liste, u ClientHandleru se zatvara socket ako vec nije zatvroren u Stop metodi
        {
            lock (_lock)
            {

                handlers.Remove(clientHandler);
            }
        }
    }
}
