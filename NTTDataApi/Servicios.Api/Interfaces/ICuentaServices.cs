using Servicios.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Interfaces
{
    public interface ICuentaServices
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Cuenta>> GetAll();
        Task<Cuenta> GetId(int id);
        Task<int> Save(Cuenta model);
        Task<bool> Update(Cuenta model);
    }
}