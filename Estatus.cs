using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduccion_a_ADO
{
    public class Estatus
    {
        public Estatus()
        {
        }
        public Estatus(int Id, string Clave, string Nombre)
        {
            this.Id = Id;
            this.Clave = Clave;
            this.Nombre = Nombre;
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}
