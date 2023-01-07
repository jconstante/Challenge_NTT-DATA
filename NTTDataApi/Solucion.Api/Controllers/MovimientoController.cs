using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Api.Data;
using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using Servicios.Api.Models;
using Servicios.Api.Request;
using Servicios.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoServices _movimientoServices;
        private readonly IMapper _mapper;
        
        public MovimientoController(IMovimientoServices movimientoServices, IMapper mapper)
        {
            _movimientoServices = movimientoServices;
            _mapper = mapper;
           
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planes = await _movimientoServices.GetAll();
            var model = _mapper.Map<IEnumerable<MovimientoModel>>(planes);
            var respuesta = new ApiResponse<IEnumerable<MovimientoModel>>(model);

            return Ok(respuesta);
        }

        [Route("getReporte")]
        [HttpGet]
        public  IActionResult GetReporte([FromBody] ListadoRequest model)
        {
            var listado =  _movimientoServices.GetReporte(model);
            var respuesta = new ApiResponse<IEnumerable<ListadoResponse>>(listado);

            return Ok(respuesta);
        }

        [HttpGet("getId/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var listado = await _movimientoServices.GetId(id);
                var model = _mapper.Map<MovimientoModel>(listado);
                var respuesta = new ApiResponse<MovimientoModel>(model);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MovimientoModel model)
        {
            try
            {
                var movto = _mapper.Map<Movimiento>(model);
                var resultado = await _movimientoServices.Save(movto);
                var respuesta = new ApiResponse<int>(resultado);
                respuesta.Message = "Movimiento Creado";
                respuesta.Error = "false";

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<MovimientoModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MovimientoModel model)
        {
            try
            {
                var Movimiento = _mapper.Map<Movimiento>(model);
                var resultado = await _movimientoServices.Update(Movimiento);
                var respuesta = new ApiResponse<bool>(resultado);
                respuesta.Message = "Movimiento Actualizada";
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<MovimientoModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }

        [Route("delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _movimientoServices.Delete(id);
                var respuesta = new ApiResponse<bool>(resultado);
                respuesta.Message = "Movimiento Eliminado";
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<MovimientoModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }
    }
}
