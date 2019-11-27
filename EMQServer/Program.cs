using System;
using System.Text;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EMQServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient client = new MqttClient("192.168.12.107");

            string clientId = "jy002";
            client.Connect(clientId);


            var i = 0;


            while (true)
            {
                i++;
                Thread.Sleep(1000);


                Console.WriteLine($"PubTopic Start {i}");

                // publish a message on "/home/temperature" topic with QoS 2 
                client.Publish("/home/111", Encoding.UTF8.GetBytes(i.ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

            }

        }
    }
}
