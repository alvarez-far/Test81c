using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test81b.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
