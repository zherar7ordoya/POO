using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EJ0005
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false; textBox4.Enabled = false;
            textBox5.Enabled = false; textBox6.Enabled = false; textBox7.Enabled = false;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear();
            Persona[] P = { new Persona() { Nombre="Juan",Apellido="Garcia",Edad=22},
                            new Persona() { Nombre="Ana",Apellido="Kardo",Edad=34},
                            new Persona() { Nombre="Cecilia",Apellido="Perez",Edad=29},
                            new Persona() { Nombre="Leonardo",Apellido="Romano",Edad=41}};

            textBox1.Text = "Antes de Ordenar: " + Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox1.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.NombreAscendente());
            textBox2.Text += Environment.NewLine + Environment.NewLine + "Orden por Nombre ASC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox2.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.NombreDescendente());
            textBox3.Text += Environment.NewLine + Environment.NewLine + "Orden por Nombre DESC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox3.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.ApellidoAscendente());
            textBox4.Text += Environment.NewLine + Environment.NewLine + "Orden por Apellido ASC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox4.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.ApellidoDescendente());
            textBox5.Text += Environment.NewLine + Environment.NewLine + "Orden por Apellido DESC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox5.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.EdadAscendente());
            textBox6.Text += Environment.NewLine + Environment.NewLine + "Orden por Edad ASC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox6.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }

            Array.Sort(P, new Persona.EdadDescendente());
            textBox7.Text += Environment.NewLine + Environment.NewLine + "Orden por Edad DESC: " +
                             Environment.NewLine + Environment.NewLine;
            foreach (Persona xP in P)
            { textBox7.Text += "\t" + xP.Nombre + "\t" + xP.Apellido + "\t" + xP.Edad.ToString() + Environment.NewLine; }
        }
        public class Persona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }

            public class NombreAscendente : IComparer<Persona>
            {
                public int Compare(Persona x,
                                   Persona y)
                    => string.Compare(x.Nombre, y.Nombre);
            }

            public class NombreDescendente : IComparer<Persona>
            {
                public int Compare(Persona x,
                                   Persona y)
                    => string.Compare(x.Nombre, y.Nombre) * -1;
            }

            public class ApellidoAscendente : IComparer<Persona>
            {
                public int Compare(Persona x,
                                   Persona y)
                    => string.Compare(x.Apellido, y.Apellido);
            }

            public class ApellidoDescendente : IComparer<Persona>
            {
                public int Compare(Persona x,
                                   Persona y)
                    => string.Compare(x.Apellido, y.Apellido) * -1;
            }

            public class EdadAscendente : IComparer<Persona>
            {
                public int Compare(Persona x, Persona y)
                {
                    return x.Edad.CompareTo(y.Edad);
                }
            }

            public class EdadDescendente : IComparer<Persona>
            {
                public int Compare(Persona x, Persona y)
                {
                    /*
                     * El método CompareTo() de la clase int compara dos números
                     * enteros y devuelve:
                     *      -1 si el primer número es menor que el segundo.
                     *      0 si los números son iguales.
                     *      1 si el primer número es mayor que el segundo.
                     * Al utilizar x.Edad.CompareTo(y.Edad), obtenemos
                     * directamente la comparación de las edades en un solo paso.
                     */
                    int resultado = x.Edad.CompareTo(y.Edad);
                    return resultado * -1;
                }
            }
        }
    }
}
