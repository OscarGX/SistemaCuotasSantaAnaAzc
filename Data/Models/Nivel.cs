using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Nivel
    {
        public Nivel()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idnivel { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
