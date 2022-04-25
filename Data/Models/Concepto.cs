using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            Cuota = new HashSet<Cuota>();
        }

        public int Idcon { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cuota> Cuota { get; set; }
    }
}
