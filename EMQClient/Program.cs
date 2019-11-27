using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // create client instance 
            MqttClient client = new MqttClient("192.168.12.107");

            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = "jy001";
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "/home/111" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


            Console.ReadLine();
        }




        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received 
            Console.WriteLine(Encoding.UTF8.GetString( e.Message));

        }

    }




}
