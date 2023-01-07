using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using Servicios.Api.Request;
using Servicios.Api.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Services
{
    public class MovimientoServices : IMovimientoServices
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository  _cuentaRepository;

        public MovimientoServices(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            return await _movimientoRepository.GetAll();
        }

        public async Task<Movimiento> GetId(int  id)
        {
            return await _movimientoRepository.GetId(id);
        }

        public IEnumerable<ListadoResponse> GetReporte(ListadoRequest model)
        {
            return _movimientoRepository.GetReporte(model);
        }

        public async Task<int> Save(Movimiento model)
        {
           
                var cta = await _cuentaRepository.GetId(model.IdCuenta);

                if (cta == null)
                    throw new Exception("Cuenta no Exsite");
                

                if (model.TipoMov == "R")
                {
                    if (cta.SaldoIncial == 0)
                    {
                        throw new Exception("Saldo Insuficiente");
                    }
                    else if (cta.SaldoIncial < model.Valor)
                    {
                        throw new Exception("Saldo Insuficiente");
                    }

                    model.Saldo = (decimal)(cta.SaldoIncial - model.Valor);

                }
                else
                {
                    model.Saldo = (decimal)(cta.SaldoIncial + model.Valor);
                }

                return await _movimientoRepository.Save(model);

        }

        public async Task<bool> Update(Movimiento model)
        {
              return await _movimientoRepository.Update(model);
        }

        public async Task<bool> Delete(int id)
        {
          
           return await _movimientoRepository.Delete(id);
        }
    }
}
