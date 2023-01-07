using Microsoft.EntityFrameworkCore;
using Persistencia.Api.Data;
using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using Servicios.Api.Request;
using Servicios.Api.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Api.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly developerContext _context;

        public MovimientoRepository(developerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movimiento>> GetAll()
        {

            return await _context.Movimientos.ToListAsync();
        }

        public IEnumerable<ListadoResponse> GetReporte(ListadoRequest model)
        {
           
            var formats = "dd/MM/yyyy";

            var query = _context.Movimientos.Include(c => c.Cuenta)
                                            .Include(c => c.Cuenta.Cliente)                                     
                                            .Include(c => c.Cuenta.Cliente.Persona).AsQueryable();

            if (model.IdCliente > 0)
            {
                query = query.Where(q => q.Cuenta.IdCliente == model.IdCliente);
            }

            if (DateTime.TryParseExact(model.Fecha, formats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var startDateFrom))
            {
                var endtDateTo = startDateFrom.AddDays(1);
                query = query.Where(q => q.Fecha >= startDateFrom  &&  q.Fecha < endtDateTo);
            }

            var listado = query
                            .Select(MapperToModel)
                            .ToList();

            return listado;
        }

        private ListadoResponse MapperToModel(Movimiento m)
        {
           
            var reporte = new ListadoResponse
            {
                Fecha = m.Fecha.ToShortDateString(),
                Cliente = m.Cuenta.Cliente.Persona.Nombre,
                Estado = m.Cuenta.Estado,
                NumeroCuenta = m.Cuenta.NumCuenta,
                SaldoDisponible = m.Saldo,
                SaldoInicial = m.Cuenta.SaldoIncial, 
                Tipo = m.Cuenta.TipoCuenta == "A" ? "Ahorro" : "Corriente",
                Movimiento = m.Valor
            };

            return reporte;
        }

        public async Task<Movimiento> GetId(int id)
        {
            return await _context.Movimientos.Where(d => d.IdMov == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Movimiento model)
        {
            try
            {
                var mov = await _context.Movimientos.Where(d => d.IdMov == model.IdMov).FirstOrDefaultAsync();

                if (mov != null)
                {
                    throw new Exception("Movimiento ya Existe");
                };

                model.Fecha = DateTime.Now;

                await _context.Movimientos.AddAsync(model);
                int rows = await _context.SaveChangesAsync();

                return model.IdMov;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Update(Movimiento model)
        {
            try
            {
                var registro = await _context.Movimientos.Where(d => d.IdMov == model.IdMov).FirstOrDefaultAsync();

                if (registro == null)
                {
                    throw new Exception("Movimiento no Existe");
                }

               
                registro.FechaModificacion = DateTime.Now;

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
                var registro = await _context.Movimientos.Where(d => d.IdMov == id).FirstOrDefaultAsync();

                if (registro == null)
                {
                    throw new Exception("Movimiento no Existe");
                }

                registro.FechaModificacion = DateTime.Now;

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