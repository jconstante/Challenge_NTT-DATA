using Servicios.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Interfaces
{
    public interface ICuentaRepository
    {
        Task<IEnumerable<Cuenta>> GetAll();
        Task<Cuenta> GetId(int id);
        Task<Cuenta> GetCuenta(string cuenta);
        Task<int> Save(Cuenta model);
        Task<bool> Update(Cuenta model);
        Task<bool> Delete(int id);
    }
}