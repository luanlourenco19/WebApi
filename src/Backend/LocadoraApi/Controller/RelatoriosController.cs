using LocadoraApi.Data;
using LocadoraApi.Domain;
using LocadoraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraApi.Controller
{

    [Route("api/relatorios")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly ILogger<RelatoriosController> _logger;
        private readonly IRelatoriosRepository _relatoriosRepository;

        public RelatoriosController(ILogger<RelatoriosController> logger, IRelatoriosRepository relatoriosRepository)
        {
            _logger = logger;
            _relatoriosRepository = relatoriosRepository;
        }


        [HttpGet]
        [Route("GetClienteComAtraso")]
        public async Task<List<Cliente>> GetClienteComAtraso([FromServices] DataContext context)
        {
            int idClienteComAtraso;
            bool foraDoPrazo = false;
            var locacaoes = context.Locacoes.ToList();
            var clientes = new List<Cliente>();

            foreach (var locacao in locacaoes)
            {
                var filme = context.Filmes.FirstOrDefault(f => f.Id == locacao.Id_Filme);
                if(filme.Lancamento == 1)
                {
                    if ((locacao.DataLocacao.AddDays(2) > DateTime.Now || locacao.DataDevolucao == null))
                    {
                        idClienteComAtraso = locacao.Id_Cliente;
                    }
                }
                else
                {
                    if ((locacao.DataLocacao.AddDays(3) > DateTime.Now || locacao.DataDevolucao == null))
                    {
                        idClienteComAtraso = locacao.Id_Cliente;
                    }
                }
            }

            //clientes = context.Clientes.FirstOrDefault(c => c.Id == idClienteComAtraso);

            return context.Clientes.ToList();
        }


        [HttpGet]
        [Route("GetFilmesNaoAlugados")]
        public async Task<List<Filme>> GetFilmesNaoAlugados([FromServices] DataContext context)
        {
            var filmes = context.Filmes.ToList();
            var FilmesNaoAlugados = new List<Filme>();
            var locacoes = context.Locacoes.ToList();

            
            foreach (var filme in filmes)
            {
                foreach (var locacao in locacoes)
                {
                    if (filme.Id != locacao.Id_Filme)
                    {
                        FilmesNaoAlugados.Add(filme);
                    }
                }
            }


            return FilmesNaoAlugados;
        }


        [HttpGet]
        [Route("GetTopFilmesAlugados")]
        public IActionResult GetTopFilmesAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTopFilmesAlugados();

            return Ok(data);
        }

        [HttpGet]
        [Route("GetTopFilmesMenosAlugados")]
        public IActionResult GetTopFilmesMenosAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTopFilmesMenosAlugados();

            return Ok(data);
        }

        [HttpGet]
        [Route("GetSegundoClienteMaisAlugou")]
        public IActionResult GetSegundoClienteMaisAlugou([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetSegundoClienteMaisAlugou();

            return Ok(data.Skip(1));
        }
    }
}
