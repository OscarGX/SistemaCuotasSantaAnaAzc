using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Ocupacione
    {
        public Ocupacione()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public int Idocup { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
