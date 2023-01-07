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
    public class CuentaRepository : ICuentaRepository
    {
        private readonly developerContext _context;

        public CuentaRepository(developerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cuenta>> GetAll()
        {

            return await _context.Cuentas.Include(c =>c.Cliente)
                                         .Include(c => c.Cliente.Persona).ToListAsync();
        }

        public async Task<Cuenta> GetId(int id)
        {
            return await _context.Cuentas.Include(c => c.Cliente)
                                         .Include(c => c.Cliente.Persona)
                                         .Where(d => d.IdCuenta == id).FirstOrDefaultAsync();
        }

        public async Task<Cuenta> GetCuenta(string cuenta)
        {
            return await _context.Cuentas.Where(d => d.NumCuenta == cuenta).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Cuenta model)
        {
            try
            {
                var cuenta = await _context.Cuentas.Where(d => d.IdCuenta == model.IdCuenta).FirstOrDefaultAsync();

                if (cuenta != null)
                {
                    throw new Exception("Cuenta ya Existe");
                }

                model.FechaCreacion = DateTime.Now;
                await _context.Cuentas.AddAsync(model);
                int rows = await _context.SaveChangesAsync();

                return model.IdCuenta;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Update(Cuenta model)
        {
            try
            {
                var cuenta = await _context.Cuentas.Where(d => d.IdCuenta == model.IdCuenta).FirstOrDefaultAsync();

                if (cuenta == null)
                {
                      throw new Exception("Cuenta no Existe");
                }

                cuenta.SaldoIncial = model.SaldoIncial;
                cuenta.TipoCuenta = model.TipoCuenta;
                cuenta.FechaModificacion = DateTime.Now;

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
                var cuenta = await _context.Cuentas.Where(d => d.IdCuenta == id).FirstOrDefaultAsync();

                if (cuenta == null)
                {
                    throw new Exception("Cuenta no Existe");
                }

                cuenta.Estado = false;
                cuenta.FechaModificacion = DateTime.Now;

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
