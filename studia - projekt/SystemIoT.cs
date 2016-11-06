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
    public class SystemIoT
    {
        public Form1 form1 { get; set; }
        public Form2 form2 { get; set; }
        public Klient client;
        private SqlDane sqldane;

        private static SystemIoT instance;
        public static SystemIoT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemIoT();
                }
                return instance;
            }
        }

        public bool Zaloguj(string ServerName, string nickname, string password,Int32 port)
        {
            MqttClient mqttclient;
            byte code;
            try
            {
                mqttclient = new MqttClient(ServerName,port,false,null,null,MqttSslProtocols.None);
                code = mqttclient.Connect(Guid.NewGuid().ToString(), nickname, password);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
            if (code == 0)
            {
                DodajKlienta(new Klient(mqttclient, ServerName, nickname, password,port));
                DodajBazeDanych(new SqlDane());
                System.Windows.Forms.MessageBox.Show("Welcome " + nickname);
                form1.Enabled = false;
                form1.Hide();
                form2 = new Form2();
                form2.Enabled = true;
                form2.Visible = true;
                return true;
            }
            else {
                System.Windows.Forms.MessageBox.Show("Try again.");
                return false;
            }
        }
        public void Wyloguj()
        {
            UsunKlienta();
            form2.Enabled = false;
            form2.Hide();
            form1.Enabled = true;
            form1.Visible = true;
        }

        private void DodajKlienta(Klient client)
        {
            this.client = client;
        }
        private void DodajBazeDanych(SqlDane sqldane)
        {
            this.sqldane = sqldane;
        }
        private void UsunKlienta()
        {
            client = null;
            GC.Collect();
        }

        public void Opublikuj(string topic, string data)
        {
            try
            {
                client.mqtt.Publish(topic, Encoding.UTF8.GetBytes(data));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        public void subskrybuj(string topic)
        {
            try
            {
               client.mqtt.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
               client.mqtt.MqttMsgPublishReceived += SystemIoT.Instance.client_MqttMsgPublishReceived;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }   

        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            sqldane.OdbierzDane(Encoding.UTF8.GetString(e.Message), e.Topic);
        }

        public string ZwrocDane(string temat)
        {
           return sqldane.UstawDane(temat);
        }
    }
}
