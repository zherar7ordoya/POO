using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace EJ0011
{
    public partial class Form1 : Form
    {
        // Declaración del delegate
        public delegate void Delegado(string texto);

        // Declaración de la variable de tipo Delegado
        Delegado delegadoA;
        Delegado delegadoB;
        Delegado delegadoC;
        Delegado delegadoMulticast;
        bool booleano;

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            delegadoA = MetodoA;
            delegadoB = MetodoB;
            delegadoC = MetodoC;
            delegadoMulticast = delegadoA + delegadoB;
            delegadoMulticast += delegadoC;
        }

        public void MetodoA(string txt) => 
            MessageBox.Show("EL método 1 se ejecutó y muestra el texto: " + txt);
        public void MetodoB(string txt) => 
            MessageBox.Show("EL método 2 se ejecutó y muestra el texto: " + txt);
        public void MetodoC(string txt) => 
            MessageBox.Show("EL método 3 se ejecutó y muestra el texto: " + txt);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                delegadoMulticast(Interaction.InputBox("Ingrese Texto: "));
                if (!booleano)
                {
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    booleano = !booleano; 
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            delegadoMulticast -= MetodoA;
            button2.Visible = false; 
            button5.Visible = true; 
            button1_Click(null, null);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            delegadoMulticast -= MetodoB;
            button3.Visible = false; 
            button6.Visible = true; 
            button1_Click(null, null);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            delegadoMulticast -= MetodoC;
            button4.Visible = false;
            button7.Visible = true;
            button1_Click(null, null);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            delegadoMulticast += MetodoA;
            button5.Visible = false;
            button2.Visible = true;
            button1_Click(null, null);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            delegadoMulticast += MetodoB;
            button6.Visible = false;
            button3.Visible = true;
            button1_Click(null, null);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            delegadoMulticast += MetodoC;
            button7.Visible = false;
            button4.Visible = true;
            button1_Click(null, null);
        }
    }
}

