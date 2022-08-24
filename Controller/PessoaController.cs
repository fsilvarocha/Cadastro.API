using Cadastro.API.Data;
using Cadastro.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Controller
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> ObterTodos([FromServices] DataContext dataContext)
        {
            var paciente = await dataContext.Pessoas.ToListAsync();

            return paciente.Any() ? Ok(paciente) : NotFound("Paciente não encontrado");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pessoa>> ObterPorId([FromServices] DataContext dataContext, int id)
        {
            var paciente = await dataContext.Pessoas.Where(x => x.Id == id).FirstOrDefaultAsync();

            return paciente != null ? Ok(paciente) : NotFound("Paciente não encontrado");
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Salvar([FromServices] DataContext dataContext, [FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest("Favor preencher os campos");

            dataContext.Add(pessoa);

            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return pessoa;
        }

        [HttpPut]
        public async Task<ActionResult<Pessoa>> Atualizar([FromServices] DataContext dataContext, [FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest("Favor preencher os campos");

            dataContext.Update(pessoa);

            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return pessoa;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pessoa>> Excluir([FromServices] DataContext dataContext, int id)
        {
            var pessoa = await dataContext.Pessoas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (pessoa == null)
                return BadRequest("Pessoa não encontrada!");

            dataContext.Remove(pessoa);

            try
            {
                await dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok();
        }
    }
}
