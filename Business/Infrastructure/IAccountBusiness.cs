using Domain;

namespace Business.Infrastructure
{
    public interface IAccountBusiness
    {
        UsuarioDomainModel Login(string nombre, string password);
    }
}
