using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Diagnostics;

namespace studia___projekt
{
     public class Klient
    {
        public MqttClient mqtt;
        public string NickName { get; set; }
        private string Password { get; set; }
        private string IpServer { get; set; }
        private Int32 Port { get; set; }

        public Klient(MqttClient mqtt, string IpServer, string NickName, string Password,Int32 Port)
        {
            this.mqtt = mqtt;
            this.NickName = NickName;
            this.Password = Password;
            this.IpServer = IpServer;
            this.Port = Port;
        }
        ~Klient()
        {
            mqtt.Disconnect();
        }    

    }
}
