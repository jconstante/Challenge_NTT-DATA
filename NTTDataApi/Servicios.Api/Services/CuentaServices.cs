using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Api.Services
{
    public class CuentaServices : ICuentaServices
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaServices(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public Task<IEnumerable<Cuenta>> GetAll()
        {
            return _cuentaRepository.GetAll();
        }

        public Task<Cuenta> GetId(int id)
        {
            return _cuentaRepository.GetId(id);
        }

        public Task<int> Save(Cuenta model)
        {
            try
            {
                return _cuentaRepository.Save(model);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> Update(Cuenta model)
        {
            try
            {
                return _cuentaRepository.Update(model);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                return _cuentaRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
