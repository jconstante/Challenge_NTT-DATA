using Servicios.Api.Entity;
using Servicios.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Interfaces
{
    public interface IClienteServices
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetId(int id);
        Task<int> Save(Cliente model);
        Task<bool> Update(Cliente model);
    }
}