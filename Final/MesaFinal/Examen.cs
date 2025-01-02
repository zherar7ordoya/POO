using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

/**
 * ENUNCIADO:
 * 
 * Crear un array o una lista con objetos (de cadena dura).
 * Que LinQ lo consuma usando foreach.
 * 
 */

namespace MesaFinal
{
    public partial class Examen : Form
    {
        public Examen() => InitializeComponent();

        private void Form_Load(object sender, EventArgs e)
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona(32776789, "Gerardo"),
                new Persona(30666999, "Darío"),
                new Persona(15258456, "Tordoya"),
                new Persona(25148654, "Darío"),
                new Persona(10456123, "Cardacci")
            };

            // Búsquedas con LinQ
            // Estuve viendo el código. No es necesario hacer un foreach para
            // recorrer los datos. Pero se hace a pedido del enunciado.

            // ==> Para comparar técnicas, comentá las líneas que no uses. <==

            //..................................................................

            // Así lo haría yo ahora:

            var porDNI = personas.Where(x => x.DNI > 22222222).ToList();
            var todos = personas.Select(x => x).ToList();
            var porNombre = personas.Where(x => x.Nombre == "Darío").ToList();
            DataGridView.DataSource = null;
            DataGridView.DataSource = porNombre;
            MessageBox.Show("Se usó LinQ para crear una lista.");

            // O incluso:

            DataGridView.DataSource = null;
            DataGridView.DataSource = personas.Where(x => x.Nombre == "Darío").ToList();
            MessageBox.Show("Se usó LinQ para crear un DataSource.");

            //..................................................................

            // ...pero así lo resolví en el final.

            var xDNI = from x
                       in personas
                       where x.DNI > 22222222
                       select x;

            var xTodos = from x
                         in personas
                         select x;

            var xNombre = from x
                          in personas
                          where x.Nombre == "Darío"
                          select x;

            List <Persona> datos = new List<Persona>();

            foreach (var item in xNombre)
            {
                datos.Add(item);
            }

            DataGridView.DataSource = null;
            DataGridView.DataSource = datos;

            MessageBox.Show("Se usó LinQ con un foreach.");
        }
    }

    //..........................................................................

    public class Persona
    {
        public Persona() { } // Constructor por defecto, vacío.
        public Persona(int dni, string nombre)
        {
            DNI = dni;
            Nombre = nombre;
        }

        //......................................................................

        public string Nombre { get; set; }
        public int DNI { get; set; }
    }
}
