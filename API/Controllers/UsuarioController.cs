using System;
using Microsoft.AspNetCore.Mvc;
using FitnessStore.API.Services;
using FitnessStore.API.Models.DTO;
using FitnessStore.API;

namespace DevFitness.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        #region Atributos

        private readonly ServicoDeUsuario _servicoDeUsuario;

        #endregion

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="DbContext">Contexto</param>
        public UsuarioController(FitnessStoreDbContext dbContext)
        {
            _servicoDeUsuario = new ServicoDeUsuario(dbContext);
        }

        #region Métodos Http

        [HttpGet("{codigoUsuario}")]
        public IActionResult Get(int codigoUsuario)
        {
            var usuario = _servicoDeUsuario.ObterUsuarioPorId(codigoUsuario);
            return Ok(usuario);
        }


        [HttpPost]
        public IActionResult Post([FromBody] DTODeUsuario dto)
        {
            var usuario = _servicoDeUsuario.AdicionarUsuario(dto);
            if (usuario == null)
            {
                return BadRequest(("Erro! Usuário já cadastrado no banco de dados."));
            }

            return CreatedAtAction(nameof(Get), new { CodigoUsuario = usuario.CodigoUsuario }, usuario);
        }


        [HttpPut]
        public IActionResult Put([FromBody] DTODeUsuario dto)
        {
            var sucesso = _servicoDeUsuario.EditarUsuario(dto);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{codigoUsuario}")]
        public IActionResult Delete(int codigoUsuario)
        {
            var sucesso = _servicoDeUsuario.ExcluirUsuario(codigoUsuario);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion
    }
}
