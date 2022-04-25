using Data.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CiudadanoBusiness
    {
        private readonly scazContext _context;
        public CiudadanoBusiness()
        {
            _context = new scazContext();
        }

        public List<CiudadanoDomainModel> GetAll()
        {
            // var ciudadanos = _context.Ciudadanos.Include(ci => ci.OcupacionNavigation).Include(ciud => ciud.Cuotasciudadanos).OrderByDescending(c => c.Clave).ToList();

            var ciudadanos = _context.Ciudadanos
                .AsNoTracking()
                .Include(ci => ci.OcupacionNavigation)
                .Include(ciud => ciud.Cuotasciudadanos).OrderByDescending(c => c.Clave).Select(cd => new CiudadanoDomainModel
            {
                Clave = cd.Clave,
                Nombre = cd.Nombre,
                ApellidoPaterno = cd.ApellidoPaterno,
                ApellidoMaterno = cd.ApellidoMaterno,
                FechaRegistro = cd.FechaRegistro,
                Curp = cd.Curp,
                Comentarios = cd.Comentarios,
                Direccion = cd.Direccion,
                Fechanac = cd.Fechanac,
                Manzana = cd.Manzana,
                Ocupacion = cd.Ocupacion,
                Sexo = cd.Sexo,
                Status = cd.Status,
                OcupacionDomainModel = new OcupacionDomainModel
                {
                    Idocup = cd.OcupacionNavigation.Idocup,
                    Nombre = cd.OcupacionNavigation.Nombre,
                    Descripcion = cd.OcupacionNavigation.Descripcion
                },
                Cuotasciudadanos = cd.Cuotasciudadanos.Select(ccd => new CuotaCiudadanoDomainModel {
                    Apoyo = ccd.Apoyo,
                    Ciudadano = ccd.Ciudadano,
                    Comentarios = ccd.Comentarios,
                    Descuento = ccd.Descuento,
                    Folio = ccd.Folio,
                    Saldo = ccd.Saldo,
                    Status = ccd.Status,
                }).ToList(),
            }).ToList();
            return ciudadanos;
        }

        public CiudadanoDomainModel GetCiudadanoByIdWithCuotas(long clave)
        {
            var ciudadano = _context.Ciudadanos.Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .FirstOrDefault(c => c.Clave == clave);
            if (ciudadano != null)
            {
                var ciudadanoDM = new CiudadanoDomainModel()
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.OrderByDescending(x => x.Id).Select(ciu => new CuotaCiudadanoDomainModel {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                };
                return ciudadanoDM;
            }
            return null;
        }

        public CiudadanoDomainModel GetCiudadanoByIdAll(long clave)
        {
            var ciudadano = _context.Ciudadanos
                .AsNoTracking()
                .Include(x => x.OcupacionNavigation)
                .Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .FirstOrDefault(c => c.Clave == clave);
            if (ciudadano != null)
            {
                var ciudadanoDM = new CiudadanoDomainModel()
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    OcupacionDomainModel = new OcupacionDomainModel
                    {
                        Descripcion = ciudadano.OcupacionNavigation.Descripcion,
                        Idocup = ciudadano.OcupacionNavigation.Idocup,
                        Nombre = ciudadano.OcupacionNavigation.Nombre,
                    },
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.OrderByDescending(z => z.Id).Select(ciu => new CuotaCiudadanoDomainModel
                    {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                };
                return ciudadanoDM;
            }
            return null;
        }

        public CiudadanoDomainModel GetCiudadanoByIdWithCuotasAll(long clave)
        {
            var ciudadano = _context.Ciudadanos
                .AsNoTracking()
                .Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .FirstOrDefault(c => c.Clave == clave);
            if (ciudadano != null)
            {
                var ciudadanoDM = new CiudadanoDomainModel()
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.Select(ciu => new CuotaCiudadanoDomainModel
                    {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                };
                return ciudadanoDM;
            }
            return null;
        }

        public List<CiudadanoDomainModel> GetCiudadanosByNameWithCuotas(string nombre)
        {
            var ciudadanos = _context.Ciudadanos.Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .Include(cddd => cddd.OcupacionNavigation)
                .Where(c => c.Nombre.Contains(nombre))
                .Select(ciudadano => new CiudadanoDomainModel
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    OcupacionDomainModel = new OcupacionDomainModel
                    {
                        Descripcion = ciudadano.OcupacionNavigation.Descripcion,
                        Idocup = ciudadano.OcupacionNavigation.Idocup,
                        Nombre = ciudadano.OcupacionNavigation.Nombre,
                    },
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.Select(ciu => new CuotaCiudadanoDomainModel
                    {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                }).ToList();
            return ciudadanos;
        }

        public List<CiudadanoDomainModel> GetCiudadanosByManzanaWithCuotas(int? manzana = null)
        {
            var ciudadanos = new List<CiudadanoDomainModel>();
            if (manzana == null)
            {
                ciudadanos = _context.Ciudadanos
                .AsNoTracking()
                .Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .Include(cddd => cddd.OcupacionNavigation)
                .OrderBy(c => c.Manzana)
                .ThenBy(x => x.ApellidoPaterno)
                .Select(ciudadano => new CiudadanoDomainModel
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    OcupacionDomainModel = new OcupacionDomainModel
                    {
                        Descripcion = ciudadano.OcupacionNavigation.Descripcion,
                        Idocup = ciudadano.OcupacionNavigation.Idocup,
                        Nombre = ciudadano.OcupacionNavigation.Nombre,
                    },
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.Select(ciu => new CuotaCiudadanoDomainModel
                    {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                }).ToList();
            } else
            {
                ciudadanos = _context.Ciudadanos
                .AsNoTracking()
                .Include(cd => cd.Cuotasciudadanos)
                .ThenInclude(cdd => cdd.FolioNavigation)
                .Include(cddd => cddd.OcupacionNavigation)
                .Where(c => c.Manzana == manzana.Value)
                .OrderBy(x => x.ApellidoPaterno)
                .Select(ciudadano => new CiudadanoDomainModel
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    OcupacionDomainModel = new OcupacionDomainModel
                    {
                        Descripcion = ciudadano.OcupacionNavigation.Descripcion,
                        Idocup = ciudadano.OcupacionNavigation.Idocup,
                        Nombre = ciudadano.OcupacionNavigation.Nombre,
                    },
                    Cuotasciudadanos = ciudadano.Cuotasciudadanos.Select(ciu => new CuotaCiudadanoDomainModel
                    {
                        Apoyo = ciu.Apoyo,
                        Ciudadano = ciu.Ciudadano,
                        Comentarios = ciu.Comentarios,
                        Descuento = ciu.Descuento,
                        Folio = ciu.Folio,
                        Saldo = ciu.Saldo,
                        Status = ciu.Status,
                        Id = ciu.Id,
                        CuotaDomainModel = new CuotaDomainModel
                        {
                            Concepto = ciu.FolioNavigation.Concepto,
                            Fecha = ciu.FolioNavigation.Fecha,
                            Folio = ciu.FolioNavigation.Folio,
                            Hora = ciu.FolioNavigation.Hora,
                            Monto = ciu.FolioNavigation.Monto,
                            Status = ciu.FolioNavigation.Status,
                        },
                    }).ToList(),
                }).ToList();
            }
            return ciudadanos;
        }

        public CiudadanoDomainModel GetCiudadanoById(long clave)
        {
            var ciudadano = _context.Ciudadanos.Include(cd => cd.OcupacionNavigation).FirstOrDefault(c => c.Clave == clave);
            if (ciudadano != null)
            {
                var ciudadanoDM = new CiudadanoDomainModel()
                {
                    Clave = ciudadano.Clave,
                    Status = ciudadano.Status,
                    Sexo = ciudadano.Sexo,
                    Comentarios = ciudadano.Comentarios,
                    Curp = ciudadano.Curp,
                    Direccion = ciudadano.Direccion,
                    Fechanac = ciudadano.Fechanac,
                    Manzana = ciudadano.Manzana,
                    Nombre = ciudadano.Nombre,
                    ApellidoPaterno = ciudadano.ApellidoPaterno,
                    ApellidoMaterno = ciudadano.ApellidoMaterno,
                    FechaRegistro = ciudadano.FechaRegistro,
                    Ocupacion = ciudadano.Ocupacion,
                    OcupacionDomainModel = new OcupacionDomainModel
                    {
                        Idocup = ciudadano.OcupacionNavigation.Idocup,
                        Nombre = ciudadano.OcupacionNavigation.Nombre,
                        Descripcion = ciudadano.OcupacionNavigation.Descripcion,
                    }
                };
                return ciudadanoDM;
            }
            return null;
        }

        public long GetLastCiudadanoId()
        {
            var ciudadano = _context.Ciudadanos.OrderByDescending(c => c.Clave).FirstOrDefault();
            if (ciudadano != null)
            {
                return ciudadano.Clave;
            }
            return 0;
        }

        public bool Add(CiudadanoDomainModel ciudadadoDM)
        {
            var ciudadano = new Ciudadano
            {
                Clave = ciudadadoDM.Clave,
                Nombre = ciudadadoDM.Nombre,
                ApellidoPaterno = ciudadadoDM.ApellidoPaterno,
                ApellidoMaterno = ciudadadoDM.ApellidoMaterno,
                FechaRegistro = ciudadadoDM.FechaRegistro,
                Sexo = ciudadadoDM.Sexo,
                Curp = ciudadadoDM.Curp,
                Direccion = ciudadadoDM.Direccion,
                Manzana = ciudadadoDM.Manzana,
                Fechanac = ciudadadoDM.Fechanac,
                Ocupacion = ciudadadoDM.Ocupacion,
                Comentarios = ciudadadoDM.Comentarios,
                Status = ciudadadoDM.Status
            };
            if (ciudadadoDM.Edad < 60 && ciudadadoDM.Ocupacion != 7)
            {
                var cuotas = _context.Cuotas.AsNoTracking().Where(c => c.Fecha > ciudadano.FechaRegistro).ToList();
                if (cuotas.Count > 0)
                {
                    foreach (var cuota in cuotas)
                    {
                        ciudadano.Cuotasciudadanos.Add(new Cuotasciudadano
                        {
                            Apoyo = 0,
                            Folio = cuota.Folio,
                            Comentarios = "",
                            Descuento = 0,
                            Status = 2,
                            Saldo = 0,
                        });
                    }
                }
            }
            _context.Ciudadanos.Add(ciudadano);
            var affected = _context.SaveChanges();
            return affected > 0;
        }

        public bool UpdateOne(CiudadanoDomainModel ciudadanoDM)
        {
            var ciudadano = _context.Ciudadanos.FirstOrDefault(cd => cd.Clave == ciudadanoDM.Clave);
            if (ciudadano != null)
            {
                ciudadano.Comentarios = ciudadanoDM.Comentarios;
                ciudadano.Nombre = ciudadanoDM.Nombre;
                ciudadano.ApellidoPaterno = ciudadanoDM.ApellidoPaterno;
                ciudadano.ApellidoMaterno = ciudadanoDM.ApellidoMaterno;
                ciudadano.Manzana = ciudadanoDM.Manzana;
                ciudadano.Ocupacion = ciudadanoDM.Ocupacion;
                ciudadano.Sexo = ciudadanoDM.Sexo;
                ciudadano.Curp = ciudadanoDM.Curp;
                ciudadano.Direccion = ciudadanoDM.Direccion;
                ciudadano.Fechanac = ciudadanoDM.Fechanac;
                if (ciudadano.Ocupacion == 7)
                {
                    var cuotasCiudadano = _context.Cuotasciudadanos.Where(c => c.Ciudadano == ciudadano.Clave).ToList();
                    cuotasCiudadano.ForEach(c => c.Status = 1);
                }
                _context.Entry(ciudadano).State = EntityState.Modified;
                var updated = _context.SaveChanges();
                return updated > 0;
            }
            return false;
        }

        public bool DeleteOne(long id)
        {
            //var ciudadanoDM = GetCiudadanoByIdWithCuotas(id);
            var ciudadano = _context.Ciudadanos.Include(cd => cd.Cuotasciudadanos).FirstOrDefault(c => c.Clave == id);
            if (ciudadano != null)
            {
                //Ciudadano ciudadano = new Ciudadano {
                //    Clave = ciudadanoDM.Clave,
                //    Status = ciudadanoDM.Status,
                //    Sexo = ciudadanoDM.Sexo,
                //    Comentarios = ciudadanoDM.Comentarios,
                //    Curp = ciudadanoDM.Curp,
                //    Direccion = ciudadanoDM.Direccion,
                //    Fechanac = ciudadanoDM.Fechanac,
                //    Manzana = ciudadanoDM.Manzana,
                //    Nombre = ciudadanoDM.Nombre,
                //    Ocupacion = ciudadanoDM.Ocupacion,
                //    Cuotasciudadanos = ciudadanoDM.Cuotasciudadanos.Select(cc => new Cuotasciudadano {
                //        Apoyo = cc.Apoyo,
                //        Ciudadano = cc.Ciudadano,
                //        Comentarios = cc.Comentarios,
                //        Descuento = cc.Descuento,
                //        Folio = cc.Folio,
                //        Saldo = cc.Saldo,
                //        Status = cc.Status,
                //    }).ToList()
                //};
                //foreach (var cuota in ciudadanoDM.Cuotasciudadanos)
                //{
                //    ciudadano.Cuotasciudadanos.Add(new Cuotasciudadano
                //    {
                //        Apoyo = cuota.Apoyo,
                //        Ciudadano = cuota.Ciudadano,
                //        Comentarios = cuota.Comentarios,
                //        Descuento = cuota.Descuento,
                //        Folio = cuota.Folio,
                //        Saldo = cuota.Saldo,
                //        Status = cuota.Status,
                //    });
                //}
                _context.Ciudadanos.Remove(ciudadano);
                var deleted = _context.SaveChanges();
                return deleted > 0;
            }
            return false;
        }
    }
}
