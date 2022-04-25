using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Ciudadano
    {
        public Ciudadano()
        {
            Cuotasciudadanos = new HashSet<Cuotasciudadano>();
        }

        public long Clave { get; set; }
        public string Curp { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public int Manzana { get; set; }
        public DateTime Fechanac { get; set; }
        public string Comentarios { get; set; }
        public int Ocupacion { get; set; }
        public sbyte? Status { get; set; }
        public string Sexo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Ocupacione OcupacionNavigation { get; set; }
        public virtual ICollection<Cuotasciudadano> Cuotasciudadanos { get; set; }
    }
}
