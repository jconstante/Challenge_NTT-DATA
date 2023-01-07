using Servicios.Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Interfaces
{
    public interface IPersonasRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Persona>> GetAll();
        Task<Persona> GetId(int id);
        Task<bool> Save(Persona model);
        Task<bool> Update(Persona model);
    }
}