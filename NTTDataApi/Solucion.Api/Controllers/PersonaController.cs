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
    public class PersonaController : ControllerBase
    {
       
        private readonly IPersonaServices _personaServices;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaServices personaServices, IMapper mapper)
        {
            _personaServices = personaServices;
            _mapper = mapper;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var planes = await _personaServices.GetAll();
            var model = _mapper.Map<IEnumerable<PersonaModel>>(planes);
            var respuesta = new ApiResponse<IEnumerable<PersonaModel>>(model);

            return Ok(respuesta);
        }

        [HttpGet("getId/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var plan = await _personaServices.GetId(id);
                var model = _mapper.Map<PersonaModel>(plan);
                var respuesta = new ApiResponse<PersonaModel>(model);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PersonaModel model)
        {
            try
            {
                var plan = _mapper.Map<Persona>(model);
                var resultado = await _personaServices.Save(plan);
                var respuesta = new ApiResponse<bool>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return BadRequest(error);
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] PersonaModel model)
        {
            try
            {
                var plan = _mapper.Map<Persona>(model);
                var resultado = await _personaServices.Update(plan);
                var respuesta = new ApiResponse<bool>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return BadRequest(error);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _personaServices.Delete(id);
                var respuesta = new ApiResponse<bool>(resultado);
                return Ok(respuesta);
            }catch(Exception ex)
            {
                var error = ex.Message;
                return BadRequest(error);
            }
        }
    }
}
