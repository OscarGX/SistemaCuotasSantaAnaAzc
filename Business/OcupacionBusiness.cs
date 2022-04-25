using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class OcupacionBusiness
    {
        private readonly scazContext _context;

        public OcupacionBusiness()
        {
            _context = new scazContext();
        }

        public List<OcupacionDomainModel> GetOcupaciones()
        {
            var ocupacionesDM = _context.Ocupaciones.Select(o => new OcupacionDomainModel {
                Idocup = o.Idocup,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion
            }).ToList();
            return ocupacionesDM;
        }
    }
}
