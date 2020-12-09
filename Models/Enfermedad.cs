using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppiEnfermedades.Models
{
    public class Enfermedad
    {
        public int IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public Categoria Categoria { get; set; }
        public Sintoma Sintoma { get; set; }

        public DetalleEnfermedad DetalleEnfermedad { get; set; }

    }
}
