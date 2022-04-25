using System;
using System.Collections.Generic;

namespace Domain
{
    public class CiudadanoDomainModel
    {
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
        public string FullName
        {
            get
            {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
        }
        public int Edad
        {
            get
            {
                DateTime now = DateTime.Today;
                DateTime birthday = this.Fechanac;
                int age = now.Year - birthday.Year;
                if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day))
                    age--;
                return age;
            }
        }
        public string CuotasStatus
        {
            get
            {
                if (Cuotasciudadanos != null && Cuotasciudadanos.Count > 0)
                {
                    var adeudos = false;
                    foreach (var cuota in Cuotasciudadanos)
                    {
                        if (cuota.Status == 2)
                        {
                            adeudos = true;
                            break;
                        }
                        adeudos = false;
                    }
                    return adeudos ? "Con adeudos" : "Sin adeudos";
                }
                return "Sin cuotas asignadas";
            }
        }
        public OcupacionDomainModel OcupacionDomainModel { get; set; }
        public List<CuotaCiudadanoDomainModel> Cuotasciudadanos { get; set; }
    }
}
