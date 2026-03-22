using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;
        private readonly Server server;

        public ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequest() //prima zahtev  salje odg klijentu
        {
            try
            {
                while (true) //moze vise zahteva
                {
                    Zahtev klZahtev = serializer.Receive<Zahtev>();
                    Odgovor serverOdg = ProcessRequest(klZahtev);
                    serializer.Send(serverOdg); // odgovor - podaci ako je server uspesno obavio operaciju
                                        //podaci - null, exception message - info o exceptionu koji se desio
                }
            }
            catch (SocketException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
            }
            catch (IOException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
            }
            finally
            {
                if (socket.Connected)
                {
                    socket.Close();
                }
                server.RemoveClient(this);
            }
        }

        private Odgovor ProcessRequest(Zahtev klZahtev) //obrada klijenskog zahteva
        {
            Odgovor serverOdg = new Odgovor();
            try
            {
                switch (klZahtev.Operation)
                {
                    case Operation.PrijaviVlasnik:
                        serverOdg.Result = Controller.Instance.PrijaviVlasnik(serializer.ReadType<Vlasnik>(klZahtev.Argument)); //readtype vraca obj ili null
                        break;
                    case Operation.UbaciIzvorOcene:
                        serverOdg.Result = Controller.Instance.UbaciIzvorOcene(serializer.ReadType<IzvorOcene>(klZahtev.Argument));
                        break;
                    case Operation.VratiListuSviTipSmestaja:
                        serverOdg.Result = Controller.Instance.VratiListuSviTipSmestaja(serializer.ReadType<TipSmestaja>(klZahtev.Argument));
                        break;
                    case Operation.VratiListuSviSmestajnaJedinica:
                        serverOdg.Result = Controller.Instance.VratiListuSviSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;
                    case Operation.KreirajSmestajnaJedinica:
                        serverOdg.Result = Controller.Instance.KreirajSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;
                    case Operation.PromeniSmestajnaJedinica:
                        Controller.Instance.PromeniSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;
                    case Operation.VratiListuSmestajnaJedinica:
                        serverOdg.Result = Controller.Instance.VratiListuSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;
                    case Operation.PretraziSmestajnaJedinica:
                        serverOdg.Result = Controller.Instance.PretraziSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;
                    case Operation.ObrisiSmestajnaJedinica:
                        Controller.Instance.ObrisiSmestajnaJedinica(serializer.ReadType<SmestajnaJedinica>(klZahtev.Argument));
                        break;




                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(serverOdg.ExceptionMessage);
                serverOdg.ExceptionMessage = ex.Message;
            }
            return serverOdg;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}
