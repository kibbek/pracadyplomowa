using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using uPLibrary.Networking.M2Mqtt;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace studia___projekt
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
            SystemIoT.Instance.form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 port = 0;

            if (Int32.TryParse(textBox4.Text, out port))
            {
               // SystemIoT.Instance.Zaloguj(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), port);
                SystemIoT.Instance.Zaloguj("m20.cloudmqtt.com", "napengcd", "X17PdC9LRURL", 19928);
            }
            else MessageBox.Show("Wpisz poprawnie numer Portu.");
                
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
