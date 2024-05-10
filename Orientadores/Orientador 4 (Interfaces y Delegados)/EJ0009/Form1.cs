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

namespace EJ0009
{
    // Declaración del Delegado
    public delegate string Delegado(string texto);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Declaración de la variable D del tipo Delegado (Delegado es un delegate)
        Delegado delegado;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Intanciación. Se denomina así al hecho de asignarle 
            delegado = MetodoQueUsaraElDelegado;
        }

        public string MetodoQueUsaraElDelegado(string texto)
        {
            MessageBox.Show("1) " + texto);
            return texto; 
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Llamada al delegado.
            //MessageBox.Show(delegado(Interaction.InputBox("Ingrese un Texto: ")));
            delegado(Interaction.InputBox("Ingrese un Texto: "));
        }
    }
}
