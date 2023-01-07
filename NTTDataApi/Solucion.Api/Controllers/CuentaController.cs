using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Entity;
using Servicios.Api.Interfaces;
using Servicios.Api.Models;
using Servicios.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaServices _cuentaServices;
        private readonly IMapper _mapper;

        public CuentaController(ICuentaServices cuentaServices, IMapper mapper)
        {
            _cuentaServices = cuentaServices;
            _mapper = mapper;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planes = await _cuentaServices.GetAll();
            var model = _mapper.Map<IEnumerable<CuentaModel>>(planes);
            var respuesta = new ApiResponse<IEnumerable<CuentaModel>>(model);

            return Ok(respuesta);
        }

        [HttpGet("getId/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var plan = await _cuentaServices.GetId(id);
                var model = _mapper.Map<CuentaModel>(plan);
                var respuesta = new ApiResponse<CuentaModel>(model);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CuentaModel model)
        {
            try
            {

                var cuenta = _mapper.Map<Cuenta>(model);
                var resultado = await _cuentaServices.Save(cuenta);
                var respuesta = new ApiResponse<int>(resultado);
                if (respuesta.Data == 0)
                {
                    respuesta.Message = "Cuenta ya Existe";
                    respuesta.Error = "true";
                }
                else
                {
                    respuesta.Message = "Cuenta Creada";
                    respuesta.Error = "false";
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<CuentaModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CuentaModel model)
        {
            try
            {
                var cuenta = _mapper.Map<Cuenta>(model);
                var resultado = await _cuentaServices.Update(cuenta);
                var respuesta = new ApiResponse<bool>(resultado);
                respuesta.Message = "Cuenta Actualizada";
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<CuentaModel>(null);
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
                var resultado = await _cuentaServices.Delete(id);
                var respuesta = new ApiResponse<bool>(resultado);
                respuesta.Message = "Cuenta Eliminado";
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<CuentaModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }
    }
}
