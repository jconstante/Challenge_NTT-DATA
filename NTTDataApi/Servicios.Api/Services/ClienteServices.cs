using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using Servicios.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios.Api.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await  _clienteRepository.GetAll();
        }

        
        public async Task<Cliente> GetId(int id)
        {
            return await _clienteRepository.GetId(id);
        }


        public async Task<int> Save(Cliente model)
        {
          
           return await _clienteRepository.Save(model);
        }

        public async Task<bool> Update(Cliente model)
        {
         
             return await _clienteRepository.Update(model);
        }

        public async Task<bool> Delete(int id)
        {
             return await _clienteRepository.Delete(id);
        }
    }
}
