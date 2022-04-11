using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Teste.Api.Models.v1;
using Teste.Api.Models.v1.Request;
using Teste.Api.Services.Interface;
namespace Teste.Api.Controllers
{
    [ApiController]
    [Route("v{version:ApiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [EnableCors("AllowOrigin")]
    public class ClientesController : Controller
    {
        //private readonly ILogger<ClientesController> _logger;
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            //_logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("SearchById/{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> SearchById([FromRoute,Required] int id)
        {
            try
            {
                var response = await _clienteService.GetById(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetAll")]
        [MapToApiVersion("1.0")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _clienteService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("SearchByName/{nome}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> SearchByNameStartWith([FromRoute,Required] string nome)
        {
            try
            {
                var response = await _clienteService.GetByNameStartWith(nome);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("Insert")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Insert([FromBody] ClienteModels clienteRequest)
        {
            try
            {
                var response = await _clienteService.Insert(clienteRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }            
        }
        [HttpPost]
        [Route("Delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                var response = await _clienteService.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("Update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Update([FromBody] ClienteModels clienteRequest)
        {
            try
            {
                var response = await _clienteService.Update(clienteRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }           
        }
    }
}
