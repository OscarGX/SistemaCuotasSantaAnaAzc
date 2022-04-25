using Data.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CuotaCiudadanoBusiness
    {
        private readonly scazContext _context;
        public CuotaCiudadanoBusiness()
        {
            _context = new scazContext();
        }

        public CuotaCiudadanoDomainModel GetCuotaCiudadanoById(int id)
        {
            var cuota = _context.Cuotasciudadanos.Include(cc => cc.FolioNavigation)
                .SingleOrDefault(c => c.Id == id);
            if (cuota != null)
            {
                var cuotaDM = new CuotaCiudadanoDomainModel
                {
                    Id = id,
                    Apoyo = cuota.Apoyo,
                    Ciudadano = cuota.Ciudadano,
                    Comentarios = cuota.Comentarios,
                    Descuento = cuota.Descuento,
                    Folio = cuota.Folio,
                    Saldo = cuota.Saldo,
                    Status = cuota.Status,
                    CuotaDomainModel = new CuotaDomainModel
                    {
                        Concepto = cuota.FolioNavigation.Concepto,
                        Fecha = cuota.FolioNavigation.Fecha,
                        Folio = cuota.FolioNavigation.Folio,
                        Hora = cuota.FolioNavigation.Hora,
                        Monto = cuota.FolioNavigation.Monto,
                        Status = cuota.FolioNavigation.Status,
                    },
                };
                return cuotaDM;
            }
            return null;
        }

        public CuotaCiudadanoDomainModel AddOne(CuotaCiudadanoDomainModel cuotaCdDM)
        {
            var cuotaCiudadano = new Cuotasciudadano
            {
                Apoyo = cuotaCdDM.Apoyo,
                Ciudadano = cuotaCdDM.Ciudadano,
                Comentarios = cuotaCdDM.Comentarios,
                Descuento = cuotaCdDM.Descuento,
                Folio = cuotaCdDM.Folio,
                Saldo = cuotaCdDM.Saldo,
                Status = cuotaCdDM.Status,
            };
            var cuota = _context.Cuotasciudadanos.Add(cuotaCiudadano);
            var affected = _context.SaveChanges();
            if (affected > 0)
            {
                cuotaCdDM.Id = cuota.Entity.Id;
                return cuotaCdDM;
            }
            return null;
        }

        public bool UpdateOne(int id, CuotaCiudadanoDomainModel cuotaCdDM)
        {
            var cuota = _context.Cuotasciudadanos.SingleOrDefault(c => c.Id == id);
            if (cuota != null)
            {
                cuota.Saldo = cuotaCdDM.Saldo;
                cuota.Descuento = cuotaCdDM.Descuento;
                cuota.Comentarios = cuotaCdDM.Comentarios;
                cuota.Apoyo = cuotaCdDM.Apoyo;
                cuota.Status = cuotaCdDM.Status;
                _context.Entry(cuota).State = EntityState.Modified;
                var affected = _context.SaveChanges();
                return affected > 0;
            }
            return false;
        }
    }
}
