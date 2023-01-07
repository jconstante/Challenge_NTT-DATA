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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServices clienteServices, IMapper mapper)
        {
            _clienteServices = clienteServices;
            _mapper = mapper;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes  = await _clienteServices.GetAll();
            var model = _mapper.Map<IEnumerable<ClienteModel>>(clientes);
            var respuesta = new ApiResponse<IEnumerable<ClienteModel>>(model);

            return Ok(respuesta);
        }

        [HttpGet("getId/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var cliente = await _clienteServices.GetId(id);
                var model = _mapper.Map<ClienteModel>(cliente);
                var respuesta = new ApiResponse<ClienteModel>(model);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<ClienteModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClienteModel model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                var resultado = await _clienteServices.Save(cliente);
                var respuesta = new ApiResponse<int>(resultado);
                respuesta.Message = "Cliente Creado";
                respuesta.Error = "false";
              
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<ClienteModel>(null);
                error.Error = "true";
                error.Message = ex.Message;

                return BadRequest(error);
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ClienteModel model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                var resultado = await _clienteServices.Update(cliente);
                var respuesta = new ApiResponse<ClienteModel>(null);
                respuesta.Message = "Cliente Actualiado";
                respuesta.Error = "false";

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<ClienteModel>(null);
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
                var resultado = await _clienteServices.Delete(id);
                var respuesta = new ApiResponse<ClienteModel>(null);
                respuesta.Message = "Cliente Eliminado";
                respuesta.Error = "false";
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<ClienteModel>(null);
                error.Error = "true";
                error.Message = ex.Message;
                return BadRequest(error);
            }
        }
    }
}
