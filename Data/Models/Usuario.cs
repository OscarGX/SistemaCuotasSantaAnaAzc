using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Usuario
    {
        public int Nctrl { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Tipo { get; set; }

        public virtual Nivel TipoNavigation { get; set; }
    }
}
