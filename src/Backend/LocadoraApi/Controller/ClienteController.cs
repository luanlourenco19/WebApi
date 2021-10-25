using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocadoraApi.Repository;
using LocadoraApi.Domain;
using LocadoraApi.Data;

namespace LocadoraApi.Controller
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<List<Cliente>> GetCliente([FromServices] DataContext context)
        {
            return context.Clientes.ToList();
        }

        [HttpPost]
        [Route("AddCliente")]
        public async Task<ActionResult<Cliente>> AddCliente([FromServices] DataContext context, [FromBody]Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("RemoveCliente/{id}")]
        public async Task RemoveCliente([FromServices] DataContext context, [FromRoute]int Id)
        {
            try
            {
                var filme = context.Clientes.FirstOrDefault(e => e.Id == Id);
                context.Clientes.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }

        [HttpPost]
        [Route("UpdateCliente/{id}")]
        public IActionResult UpdateCliente([FromServices] DataContext context, [FromRoute]int Id, [FromBody]Cliente model)
        {

            var data = _clienteRepository.UpdateCliente(model);

            return Ok(data);

            //try
            //{
            //    var cliente = context.Clientes.FirstOrDefault(e => e.Id == Id);
            //    cliente.Nome = model.Nome;
            //    cliente.CPF = model.CPF;
            //    cliente.DataNascimento = model.DataNascimento;

            //    context.Clientes.Update(cliente);
            //    await context.SaveChangesAsync();
            //}
            //catch (Exception e)
            //{

            //}
        }
    }
}