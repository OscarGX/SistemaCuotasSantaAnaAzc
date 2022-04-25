using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Cuotasciudadano
    {
        public int Id { get; set; }
        public int? Folio { get; set; }
        public long? Ciudadano { get; set; }
        public double Saldo { get; set; }
        public string Comentarios { get; set; }
        public double? Descuento { get; set; }
        public int Status { get; set; }
        public sbyte Apoyo { get; set; }

        public virtual Ciudadano CiudadanoNavigation { get; set; }
        public virtual Cuota FolioNavigation { get; set; }
    }
}
