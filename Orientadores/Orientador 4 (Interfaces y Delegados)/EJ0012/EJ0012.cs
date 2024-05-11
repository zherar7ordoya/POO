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
using System.Collections;


namespace EJemplo12
{
    // Define que se recibe un string y retorna un bool.
    delegate bool DelegadoTexto(string texto);

    // Define que recibe un array de string como primer parámetro y un
    // entero como segundo y que retorna un IEnumerable<string>.
    delegate IEnumerable<string> DelegadoArray(string[] pArray, int pLimite);

    //**************************************************************************

    public partial class EJ0012 : Form
    {
        public EJ0012() => InitializeComponent();
        private void Form_Load(object sender, EventArgs e) { }

        IEnumerable<string> FiltrarLargosMayoresQue(string[] pArray, int pLimite)
        {
            return pArray.Where(n => n.Length >= pLimite);
        }
        private void EjecutarLambda_Click(object sender, EventArgs e)
        {
            bool delegado(string texto) 
            {
                return texto.Length > 6; 
            }
            MessageBox.Show("¿La cadena ingresada mide más de 6 caracteres? " +
                            delegado(Interaction.InputBox("Ingrese el Texto:")));
        }

        private void EjecutarLinQ_Click(object sender, EventArgs e)
        {
            string[] nombres = 
            {
                "Ana","Pedro", "Cecilia", "Guillermo", "Sol", "Ezequiel", "Martin", "María", "Marcelo", "Adriana" 
            };

            DelegadoArray delegado = FiltrarLargosMayoresQue;
            
            textBox1.Clear();
            
            foreach (string texto in delegado(nombres,
                     int.Parse(Interaction.InputBox("Ingrese la cantidad de caracteres mínima"))))
            {
                textBox1.Text += texto + Environment.NewLine;
            }
        }


    }
}
