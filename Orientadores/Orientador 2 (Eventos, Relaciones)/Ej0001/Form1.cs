using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ej0001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Alumno alumno;
        private void Form1_Load(object sender, EventArgs e)
        {
            alumno = new Alumno();

            // (3) SUSCRIPCIÓN AL EVENTO <<-----------------------------------<<
            alumno.CambioEnNombre += OnCambioEnNombre;
        }

        // (4) MÉTODO MANEJADOR DEL EVENTO <<---------------------------------<<
        private void OnCambioEnNombre(object sender, EventArgs e)
        {
            MessageBox.Show("Se produjo un cambio en el nombre, ahora es: " + alumno.Nombre);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            alumno.Nombre = Interaction.InputBox("Ingrese el Nombre:");
            //alumno.CambioEnNombre -= OnCambioEnNombre;
        }
    }
    public class Alumno
    {
        // (1) DEFINICIÓN DEL EVENTO <<---------------------------------------<<
        public event EventHandler CambioEnNombre;

        private string nombre = string.Empty;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;

                // (2) DESENCADENA EL EVENTO <<-------------------------------<<
                CambioEnNombre(this, null);
            }
        }
    }
}
