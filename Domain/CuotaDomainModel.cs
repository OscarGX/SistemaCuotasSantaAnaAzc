using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CuotaDomainModel
    {
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public double? Monto { get; set; }
        public string Status { get; set; }
        public string Concepto { get; set; }
    }
}
