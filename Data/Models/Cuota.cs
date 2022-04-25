using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Cuota
    {
        public Cuota()
        {
            Cuotasciudadanos = new HashSet<Cuotasciudadano>();
        }

        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public double? Monto { get; set; }
        public string Status { get; set; }
        public string Concepto { get; set; }

        public virtual ICollection<Cuotasciudadano> Cuotasciudadanos { get; set; }
    }
}
