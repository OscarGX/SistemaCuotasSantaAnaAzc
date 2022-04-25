using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CuotaCiudadanoDomainModel
    {
        public int Id { get; set; }
        public int? Folio { get; set; }
        public long? Ciudadano { get; set; }
        public double Saldo { get; set; }
        public string Comentarios { get; set; }
        public double? Descuento { get; set; }
        public int Status { get; set; }
        public sbyte Apoyo { get; set; }
        public string StatusString
        {
            get
            {
                return Status == 1 ? "Pagado" : "No pagado";
            }
        }
        public string ApoyoString
        {
            get
            {
                return Apoyo == 1 ? "Si" : "No";
            }
        }
        public CiudadanoDomainModel CiudadanoDomainModel { get; set; }
        public CuotaDomainModel CuotaDomainModel { get; set; }
    }
}
