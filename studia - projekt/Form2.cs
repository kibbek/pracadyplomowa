using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studia___projekt
{
    public partial class Form2 : Form
    {
        
       
        public Form2()
        {
            InitializeComponent();

        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = SystemIoT.Instance.client.NickName;
            SystemIoT.Instance.subskrybuj("/pokoj/temp/czuj1");
            SystemIoT.Instance.subskrybuj("/pokoj/lampa2");
            SystemIoT.Instance.subskrybuj("/pokoj/temp/czuj2");
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SystemIoT.Instance.Wyloguj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemIoT.Instance.Opublikuj("/pokoj/lampa1","wlacz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SystemIoT.Instance.ZwrocDane("/pokoj/lampa2") == "wylacz")
            {
                SystemIoT.Instance.Opublikuj("/pokoj/lampa2", "wlacz");
            }
            else
            {
                SystemIoT.Instance.Opublikuj("/pokoj/lampa2", "wylacz");
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           label6.Text = SystemIoT.Instance.ZwrocDane("/pokoj/temp/czuj2");
        }

    }
}
