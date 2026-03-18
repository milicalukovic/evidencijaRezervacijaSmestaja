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
                    Zahtev req = serializer.Receive<Zahtev>();
                    Odgovor r = ProcessRequest(req);
                    serializer.Send(r); // odgovor - podaci ako je server uspesno obavio operaciju
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

        private Odgovor ProcessRequest(Zahtev req) //obrada klijenskog zahteva
        {
            Odgovor r = new Odgovor();
            try
            {
                switch (req.Operation)
                {
                    case Operation.PrijaviVlasnik:
                        r.Result = Controller.Instance.PrijaviVlasnik(serializer.ReadType<Vlasnik>(req.Argument)); //readtype vraca obj ili null
                        break;
                    
                        //    Controller.Instance.AddPerson(serializer.ReadType<Klijent>(req.Argument)); //readtype vraca obj ili null
                    //    break;
                    //case Operation.Login:
                    //    r.Result = Controller.Instance.Login(serializer.ReadType<Zaposleni>(req.Argument));
                    //    break;
                    //case Operation.GetAllMesto:
                    //    r.Result = Controller.Instance.GetAllCity();
                    //    break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(r.ExceptionMessage);
                r.ExceptionMessage = ex.Message;
            }
            return r;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}
