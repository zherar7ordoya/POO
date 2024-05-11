using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace EJ0010
{
    // Declaración del delegado
    public delegate void Delegado(string texto);

    public partial class Form1 : Form
    {
        // Declaración de la variable de tipo "Delegado"
        Delegado delegado;

        public Form1() => InitializeComponent();

        private void Form_Load(object sender, EventArgs e)
        {
            // Intanciación. Se denomina así al hecho de asignarle un método.
            delegado = MetodoDelegado;
        }

        public void MetodoDelegado(string texto)
        {
            MessageBox.Show(texto);
        }

        public void RecibeDelegado(string pTexto, Delegado pDelegado)
        {
            pDelegado(pTexto);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            RecibeDelegado(Interaction.InputBox("Ingrese Texto: "), delegado);
        }
    }
}
