using System;
using FitnessStore.API;
using FitnessStore.API.Models.DTO;
using FitnessStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFitness.API.Controllers
{
    [Route("api/usuarios/{codigoUsuario}/refeicoes")]
    public class RefeicaoController : ControllerBase
    {
        #region Atributos

        private readonly ServicoDeRefeicao _servicoDeRefeicao;

        #endregion  

        /// <summary>
        /// Contrutor do controlador.
        /// </summary>
        public RefeicaoController(FitnessStoreDbContext dbContext)
        {
            _servicoDeRefeicao = new ServicoDeRefeicao(dbContext);
        }


        #region Métodos Http

        [HttpGet]
        public IActionResult GetAll(int codigoUsuario)
        {
            var refeicoes = _servicoDeRefeicao.ListarTodas(codigoUsuario);

            if (refeicoes == null)
            {
                return NotFound("Erro! Usuário não encontrado.");
            }

            return Ok(refeicoes);
        }


        [HttpGet("{codigoRefeicao}")]
        public IActionResult Get(int codigoUsuario, int codigoRefeicao)
        {
            var refeicao = _servicoDeRefeicao.ObterRefeicaoPorId(codigoUsuario, codigoRefeicao);
            if (refeicao == null)
            {
                return NotFound("Erro! Refeição não encontrada");
            }

            return Ok(refeicao);
        }


        [HttpPost]
        public IActionResult Post(int codigoUsuario, [FromBody] DTODeRefeicao dto)
        {
            var refeicao = _servicoDeRefeicao.AdicionarRefeicao(dto);
            if (refeicao == null)
            {
                return BadRequest("Erro! Refeição já cadastrada no sistema.");
            }
            return CreatedAtAction(nameof(Get), new { codigoUsuario = refeicao.CodigoUsuario, codigoRefeicao = refeicao.CodigoRefeicao }, refeicao);
        }


        [HttpPut]
        public IActionResult Put(int codigoUsuario, [FromBody] DTODeRefeicao dto)
        {
            var sucesso = _servicoDeRefeicao.EditarRefeicao(dto);
            if (!sucesso)
            {
                return NotFound("Erro! Refeicao não encontrada.");
            }

            return NoContent();
        }


        [HttpDelete("{codigoRefeicao}")]
        public IActionResult Delete(int codigoUsuario, int codigoRefeicao)
        {
            var sucesso = _servicoDeRefeicao.DeletarRefeicao(codigoUsuario, codigoRefeicao);
            if (!sucesso)
            {
                return NotFound("Erro! Refeição não encontrada.");
            }
            return NoContent();
        }

        #endregion  
    }
}