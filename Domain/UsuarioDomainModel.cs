using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UsuarioDomainModel
    {
        public int Nctrl { get; set; }
        public string Nombre { get; set; }
        //public string Password { get; set; }
        public int Tipo { get; set; }

        public NivelDomainModel NivelDomainModel { get; set; }
    }
}
