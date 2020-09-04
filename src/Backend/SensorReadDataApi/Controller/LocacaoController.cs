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
                
                var filme = context.Filmes.FirstOrDefault(f => f.Id == model.Id_Filme);

                if(filme.Lancamento == 1)
                {
                    dataDevolucao = model.DataLocacao.AddDays(2);
                }
                else
                {
                    dataDevolucao = model.DataLocacao.AddDays(3);
                }

                model.DataDevolucao = dataDevolucao;

                context.Locacoes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
