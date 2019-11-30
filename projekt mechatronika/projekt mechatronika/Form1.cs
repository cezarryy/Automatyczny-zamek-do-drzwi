using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace projekt_mechatronika
{

    public partial class Form1 : Form
    {

        string data;


        //inicjalizacja
        public Form1()
        {
            InitializeComponent();
        }

        //załatowanie dostępnych portów
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
        }


        //połączenie z arduino 
        private void buttonConnect_Click(object sender, EventArgs e)
        {

            try 
            {
                serialPort1.PortName = comboBoxPorts.Text;
                serialPort1.Open();
                progressBar1.Value = 100;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
            }
            catch (Exception err) //w przypadku problemów z połączeniem np. brak wybrania COM wyświetla się Message Box
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //rozłączenie z arduino
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
            }

        }


        //otrzymywanie danych od arduino i uruchomianie funkcji DataReceive
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DataReceive));

        }

        //funkcja sterująca wyświetlanymi danymi w Events i zapisująca dane do pliku tekstowego
        private void DataReceive(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            string lines = "";


            if (data == "1")
            {
                lines = now.ToString() + " | ID: 3989a299 | " + textBoxUser1.Text + "\n";  //dane do pliku
                textBoxEvents.AppendText(now.ToString() + " | ID: 3989a299 | " + textBoxUser1.Text + "\r\n"); //dane do wyświetlania w Events
                data = "";

            }

            if (data == "2")
            {
                lines = now.ToString() + " | ID: fb779a1b | " + textBoxUser2.Text + "\n";
                textBoxEvents.AppendText(now.ToString() + " | ID: fb779a1b | " + textBoxUser2.Text + "\r\n");
                data = "";
            }

            if (data == "3")
            {
                lines = now.ToString() + " | ID: ba1be68b | " + textBoxUser3.Text + "\n";
                textBoxEvents.AppendText(now.ToString() + " | ID: ba1be68b | " + textBoxUser3.Text + "\r\n");
                data = "";
            }
            if (data == "4")
            {
                lines = now.ToString() + " | Access dennied " + "\n";
                textBoxEvents.AppendText(now.ToString() + " | Access dennied " + "\r\n");
                data = "";
            }

            if (data == "5")
            {
                lines = now.ToString() + " | Access granted - proximity sensor " + "\n";
                textBoxEvents.AppendText(now.ToString() + " | Access granted - proximity sensor " + "\r\n");
                data = "";
            }

            if (data == "0")
            {
                lines = now.ToString() + " | Access granted - remote controller " + "\n";
                textBoxEvents.AppendText(now.ToString() + " | Access granted - remote controller " + "\r\n");
                data = "";
            }
           
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\cwiat\Desktop\projmech\logi.txt", true)) //zapisywanie do pliku
            {
                file.Write(lines);
            }

        }

        //Funkcja wysyła dane do arduino podczas zmiany checkboxa
        private void checkBoxUser1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxUser1.Checked)
                {
                    serialPort1.Write("#act1\n"); //w arduino pobierane są znaki 'act1' które przypisują 1 użytkownikowi jego ID i aktywują jego karte
                }
                else
                {
                    serialPort1.Write("#dis1\n");//w arduino pobierane są znaki 'dis1' które przypisują 1 użytkownikowi ID='000000000' i dezaktywują jego karte
                }
            }
        }

        //analogicznie do checkBoxUser1_CheckedChanged
        private void checkBoxUser2_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxUser2.Checked)
                {
                    serialPort1.Write("#act2\n"); 
                }
                else
                {
                    serialPort1.Write("#dis2\n");
                }
            }
        }


        //analogicznie do checkBoxUser1_CheckedChanged
        private void checkBoxUser3_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxUser3.Checked)
                {
                    serialPort1.Write("#act3\n"); 
                }
                else
                {
                    serialPort1.Write("#dis3\n");
                }
            }
        }

        //otwieranie drzwi za pomocą przycisku w aplikacji
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DateTime now = DateTime.Now;
                string lines = "";

                serialPort1.Write("#open\n"); //analogicznie do  checkBoxUser1_CheckedChanged

                textBoxEvents.AppendText(now.ToString() + " | Access granted - Open button " + "\r\n");

                lines = now.ToString() + " | Access granted - Open button " + "\n";
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\cwiat\Desktop\projmech\logi.txt", true)) //zapisywanie do pliku
                {
                    file.Write(lines);
                }

            }
                

        }

        //czyszczenie pola tekstowego akcji
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEvents.Text = "";
        }

        private void textBoxUser1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
