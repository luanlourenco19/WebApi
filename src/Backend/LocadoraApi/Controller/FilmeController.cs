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
    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        [HttpGet]
        [Route("GetFilme")]
        public async Task<List<Filme>> GetFilme([FromServices] DataContext context)
        {
            return  context.Filmes.ToList();
        }

        [HttpPost]
        [Route("AddFilme")]
        public async Task<ActionResult<Filme>> AddFilme([FromServices] DataContext context, [FromBody]Filme model)
        {
            if (ModelState.IsValid)
            {
                context.Filmes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("RemoveFilme/{id}")]
        public async Task RemoveFilme([FromServices] DataContext context, [FromRoute]int Id)
        {
            try
            {
                var filme = context.Filmes.FirstOrDefault(e => e.Id == Id);
                context.Filmes.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {

            }
        }

        [HttpPost]
        [Route("UpdateFilme/{id}")]
        public async Task UpdateFilme([FromServices] DataContext context, [FromRoute]int Id, [FromBody]Filme model)
        {
            try
            {
                var filme = context.Filmes.FirstOrDefault(e => e.Id == Id);
                filme.Titulo = model.Titulo;
                filme.ClassificacaoIndicativa = model.ClassificacaoIndicativa;
                filme.Lancamento = model.Lancamento;

                context.Filmes.Update(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}