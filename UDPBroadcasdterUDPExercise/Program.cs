using System;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using SensorDataLibraryUDPExercise;

namespace UDPBroadcasdterUDPExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Broadcaster");

            UdpClient socket = new UdpClient();
            while (true)
            {
                var dataObject = GetSensorData();
                var JsonData = JsonSerializer.Serialize(dataObject);
                byte[] data = Encoding.UTF8.GetBytes(JsonData);
                socket.Send(data, data.Length, "255.255.255.255", 10100);
                Thread.Sleep(RandomTimeSpan());
            }
        }


        public static int RandomTimeSpan()
        {
            Random randon = new Random();
            return randon.Next(1000, 10000);
        }

       
        public static SensorData GetSensorData()
        {
            Random random = new Random();
            int speed = random.Next(5, 150);
            SensorData data = new SensorData(10, "NohelySensor", speed, DateTime.Now);
            return data;
        }

    }

       
        
    
}
