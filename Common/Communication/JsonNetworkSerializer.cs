using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly Socket s;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }
        //salje obj i pretvara u json
        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }
        //prihvata json i pretvara u obj
        public T Receive<T>() where T : class
        {
            string json = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(json))
                return null;

            return JsonSerializer.Deserialize<T>(json);
        }
        //obj pretvara u konkretan tip
        public T ReadType<T>(object podaci) where T : class
        {
            return podaci == null ? null : JsonSerializer.Deserialize<T>((JsonElement)podaci);
        }

        public void Close()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }
    }
}
