using Servicios.Api.Entity;
using Servicios.Api.Request;
using Servicios.Api.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Movimiento>> GetAll();
        Task<Movimiento> GetId(int id);
        IEnumerable<ListadoResponse> GetReporte(ListadoRequest model);
        Task<int> Save(Movimiento model);
        Task<bool> Update(Movimiento model);
    }
}