using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test81b.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Departamento Departamento { get; set; }
        public string Cargo { get; set; }
        public string SupervisorInmediato { get; set; }
    }
}
