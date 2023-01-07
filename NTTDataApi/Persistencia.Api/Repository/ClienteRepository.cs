using Microsoft.EntityFrameworkCore;
using Persistencia.Api.Data;
using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Api.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly developerContext _context;

        public ClienteRepository(developerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetAll()
        {

            return await _context.Clientes.Include("Persona").ToListAsync();
        }

        public async Task<Cliente> GetId(int id)
        {
            return await _context.Clientes.Include("Persona").Where(d => d.IdCliente == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Cliente model)
        {
            try
            {
                var cliente = await _context.Clientes.Where(d => d.IdCliente == model.IdCliente).FirstOrDefaultAsync();

                if (cliente != null)
                {
                    return 0;
                }

                model.FechaCreacion = DateTime.Now;
                model.Persona.FechaCreacion = DateTime.Now;
                await _context.Clientes.AddAsync(model);
                await _context.SaveChangesAsync();

                return model.IdCliente;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Update(Cliente model)
        {
            try
            {
                var cliente = await _context.Clientes.Include( p => p.Persona)
                                                     .Where(d => d.IdCliente == model.IdCliente).FirstOrDefaultAsync();

                if (cliente == null)
                {
                    throw new Exception("Cliente no Exsite");
                }

                cliente.Password = model.Password;
                cliente.Persona.Nombre = model.Persona.Nombre;
                cliente.Persona.Edad = model.Persona.Edad;
                cliente.Persona.Genero = model.Persona.Genero;
                cliente.Persona.Telefono = model.Persona.Telefono;
                cliente.Persona.Direccion = model.Persona.Direccion;
                cliente.FechaModificacion = DateTime.Now;

                int rows = await _context.SaveChangesAsync();

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var cliente = await _context.Clientes.Where(d => d.IdCliente == id).FirstOrDefaultAsync();

                cliente.Estado = false;
                cliente.FechaModificacion = DateTime.Now;

                int rows = await _context.SaveChangesAsync();

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
