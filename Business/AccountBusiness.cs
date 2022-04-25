using Business.Infrastructure;
using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly scazContext _context;

        public AccountBusiness()
        {
            _context = new scazContext();
        }

        public UsuarioDomainModel Login(string nombre, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre && u.Password == password);
            if (user != null)
            {
                var userDM = new UsuarioDomainModel()
                {
                    Nctrl = user.Nctrl,
                    Tipo = user.Tipo,
                    Nombre = user.Nombre
                };
                return userDM;
            }
            return null;
        }
    }
}
