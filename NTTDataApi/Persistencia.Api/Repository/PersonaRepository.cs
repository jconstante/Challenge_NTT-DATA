using Microsoft.EntityFrameworkCore;
using Persistencia.Api.Data;
using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Api.Repository
{
    public class PersonasRepository : IPersonasRepository
    {

        private readonly developerContext _context;

        public PersonasRepository(developerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Persona>> GetAll()
        {

            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetId(int id)
        {
            return await _context.Personas.Where(d => d.IdPersona == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save(Persona model)
        {
            try
            {
                var detalle = await _context.Personas.Where(d => d.IdPersona == model.IdPersona).FirstOrDefaultAsync();

                if (detalle != null)
                {
                    throw new Exception("Persona ya existe");
                }

                model.FechaCreacion = DateTime.Now;
                await _context.Personas.AddAsync(model);
                int rows = await _context.SaveChangesAsync();

                return rows > 0;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Update(Persona model)
        {
            try
            {
                var persona = await _context.Personas.Where(d => d.IdPersona == model.IdPersona).FirstOrDefaultAsync();

                if (persona == null)
                {
                    throw new Exception("Persona no existe");
                }

                persona.FechaCreacion = DateTime.Now;
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
                var persona = await _context.Personas.Where(d => d.IdPersona == id).FirstOrDefaultAsync();

                if (persona == null)
                {
                    throw new Exception("Persona no existe");
                }

                persona.FechaModificacion = DateTime.Now;
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
