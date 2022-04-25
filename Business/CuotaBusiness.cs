using Data.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CuotaBusiness
    {
        private readonly scazContext _context;
        public CuotaBusiness()
        {
            _context = new scazContext();
        }

        public List<CuotaDomainModel> GetAll()
        {
            var cuotas = _context.Cuotas.OrderByDescending(c => c.Folio).Select(cu => new CuotaDomainModel {
                Folio = cu.Folio,
                Concepto = cu.Concepto,
                Fecha = cu.Fecha,
                Hora = cu.Hora,
                Monto = cu.Monto,
                Status = cu.Status,
            }).ToList();
            return cuotas;
        }

        public List<CuotaDomainModel> GetCuotasDisponiblesByCiudadanoIdAndFechaRegistro(long ciudadanoId, DateTime fechaRegistro)
        {
            var availableCuotas = _context.Cuotas
                .Where(c => c.Fecha > fechaRegistro)
                .Select(cd => new CuotaDomainModel {
                    Fecha = cd.Fecha,
                    Concepto = cd.Concepto,
                    Folio = cd.Folio,
                    Hora = cd.Hora,
                    Monto = cd.Monto,
                    Status = cd.Status
                })
                .ToList();
            return availableCuotas;
        }

        public CuotaDomainModel GetCuotaById(int id)
        {
            var cuota = _context.Cuotas.FirstOrDefault(c => c.Folio == id);
            if (cuota != null)
            {
                var cuotaDM = new CuotaDomainModel
                {
                    Folio = cuota.Folio,
                    Concepto = cuota.Concepto,
                    Fecha = cuota.Fecha,
                    Hora = cuota.Hora,
                    Monto = cuota.Monto,
                    Status = cuota.Status,
                };
                return cuotaDM;
            }
            return null;
        }

        public bool Add(CuotaDomainModel cuotaDM)
        {
            var cuota = new Cuota {
                Concepto = cuotaDM.Concepto,
                Fecha = cuotaDM.Fecha,
                Hora = cuotaDM.Hora,
                Monto = cuotaDM.Monto,
                Status = cuotaDM.Status
            };
            var ciudadanos = _context.Ciudadanos
                .AsNoTracking()
                .Where(c => cuota.Fecha > c.FechaRegistro)
                .Where(x => x.Ocupacion != 7)
                .ToList()
                .Where(cd => cd.Fechanac.Year > GreatherThan60(cd.Fechanac))
                .ToList();
            if (ciudadanos.Count > 0)
            {
                foreach (var ciudadano in ciudadanos)
                {
                    cuota.Cuotasciudadanos.Add(new Cuotasciudadano {
                        Apoyo = 0,
                        Ciudadano = ciudadano.Clave,
                        Comentarios = "",
                        Descuento = 0,
                        Status = 2,
                        Saldo = 0,
                    });
                }
            }
            _context.Cuotas.Add(cuota);
            var affected = _context.SaveChanges();
            return affected > 0;
        }

        public bool UpdateOne(int id, CuotaDomainModel cuota)
        {
            var cuotaDB = _context.Cuotas.FirstOrDefault(c => c.Folio == id);
            if (cuotaDB != null)
            {
                if (cuota.Fecha != cuotaDB.Fecha)
                {
                    cuotaDB.Fecha = cuota.Fecha;
                    var ciudadanos = _context.Ciudadanos
                        .AsNoTracking()
                        .Include(x => x.Cuotasciudadanos)
                        .Where(c => cuota.Fecha > c.FechaRegistro)
                        .Where(x => x.Ocupacion != 7)
                        .ToList()
                        .Where(cd => cd.Fechanac.Year > GreatherThan60(cd.Fechanac))
                        .ToList();
                    if (ciudadanos.Count > 0)
                    {
                        foreach (var ciudadano in ciudadanos)
                        {
                            var cuotaRepetida = ciudadano.Cuotasciudadanos.Where(xd => xd.Folio == cuotaDB.Folio).ToList().Count();
                            if (cuotaRepetida == 0)
                            {
                                cuotaDB.Cuotasciudadanos.Add(new Cuotasciudadano
                                {
                                    Apoyo = 0,
                                    Ciudadano = ciudadano.Clave,
                                    Comentarios = "",
                                    Descuento = 0,
                                    Status = 2,
                                    Saldo = 0,
                                });
                            }
                        }
                    }
                }
                cuotaDB.Concepto = cuota.Concepto;
                cuotaDB.Monto = cuota.Monto;
                _context.Entry(cuotaDB).State = EntityState.Modified;
                var updated = _context.SaveChanges();
                return updated > 0;
            }
            return false;
        }

        private int GreatherThan60(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            DateTime birthday = fechaNacimiento;
            int anio60 = now.Year - 60;
            int age = now.Year - birthday.Year;
            if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day))
                age--; // aún no cumple años
            //if (age < 60)
            //    return fechaNacimiento.Year == anio60 ? anio60-- : anio60;
            //return anio60;
            return age < 60 && fechaNacimiento.Year == anio60 ? anio60 - 1 : anio60;
        }
    }
}
