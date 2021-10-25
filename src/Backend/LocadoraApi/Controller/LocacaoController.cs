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
    [Route("api/locacao")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        [HttpGet]
        [Route("GetLocacao")]
        public async Task<List<Locacao>> GetLocacao([FromServices] DataContext context)
        {
            return context.Locacoes.ToList();
        }

        [HttpPost]
        [Route("AddLocacao")]
        public async Task<ActionResult<Locacao>> AddLocacao([FromServices] DataContext context, [FromBody]Locacao model)
        {
            DateTime dataDevolucao;

            if (ModelState.IsValid)
            {
                
                //var filme = context.Filmes.FirstOrDefault(f => f.Id == model.Id_Filme);

                //if(filme.Lancamento == 1)
                //{
                //    dataDevolucao = model.DataLocacao.AddDays(2);
                //}
                //else
                //{
                //    dataDevolucao = model.DataLocacao.AddDays(3);
                //}

                //model.DataDevolucao = dataDevolucao;

                context.Locacoes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("RemoveLocacao/{id}")]
        public async Task RemoveLocacao([FromServices] DataContext context, [FromRoute]int Id)
        {
            try
            {
                var filme = context.Locacoes.FirstOrDefault(e => e.Id == Id);
                context.Locacoes.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }


        [HttpPost]
        [Route("UpdateLocacao/{id}")]
        public async Task UpdateLocacao([FromServices] DataContext context, [FromRoute]int Id, [FromBody]Locacao model)
        {
            try
            {
                var locacao = context.Locacoes.FirstOrDefault(e => e.Id == Id);
                locacao.Id_Cliente = model.Id_Cliente;
                locacao.Id_Filme = model.Id_Filme;
                locacao.DataLocacao = model.DataLocacao;

                context.Locacoes.Update(locacao);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}
