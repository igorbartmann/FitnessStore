using FitnessStore.API.Core.Entities;
using FitnessStore.API.Models.DTO;
using System;
using System.Linq;

namespace FitnessStore.API.Services
{
    /// <summary>
    /// Classe de serviço dos usuários do sistema.
    /// </summary>
    public class ServicoDeUsuario
    {
        #region Atributos

        private FitnessStoreDbContext _dbContext;

        #endregion

        /// <summary>
        /// Contrutor da classe.
        /// </summary>
        public ServicoDeUsuario(FitnessStoreDbContext dbContex)
        {
            _dbContext = dbContex;
        }

        /// <summary>
        /// Obter usuári a partir de um identificador.
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>DTO do usuário encontrado</returns>
        public DTODeUsuario ObterUsuarioPorId(int id)
        {
            var usuario = (
                from user in _dbContext.Usuarios
                where user.CodigoUsuario == id
                    && !user.Excluido
                select user).FirstOrDefault();

            if (usuario == null)
            {
                return null;
            }

            return new DTODeUsuario()
            {
                CodigoUsuario = usuario.CodigoUsuario,
                NomeCompleto = usuario.NomeCompleto,
                Altura = usuario.Altura,
                Peso = usuario.Peso,
                DataNascimento = usuario.DataNascimento,
                DataInclusao = usuario.DataInclusao
            };
        }

        /// <summary>
        /// Adicionar um novo usuário.
        /// </summary>
        /// <param name="dto">DTO do usuário a ser adicionado</param>
        /// <returns>DTO do usuário com o código do usuário adicionado</returns>
        public DTODeUsuario AdicionarUsuario(DTODeUsuario dto)
        {
            var nomeCompletoMaiusculo = dto.NomeCompleto.ToUpper();
            var usuarioJaExiste = (
                from user in _dbContext.Usuarios
                where user.NomeCompleto == nomeCompletoMaiusculo
                    && user.DataNascimento.Year == dto.DataNascimento.Year
                    && user.DataNascimento.Month == dto.DataNascimento.Month
                    && user.DataNascimento.Day == dto.DataNascimento.Day
                    && !user.Excluido
                select 1).Any();

            if (usuarioJaExiste)
            {
                return null;
            }

            var usuario = new Usuario()
            {
                NomeCompleto = nomeCompletoMaiusculo,
                Altura = dto.Altura,
                Peso = dto.Peso,
                DataNascimento = dto.DataNascimento,
                DataInclusao = DateTimeOffset.Now,
                Excluido = false,
            };

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            dto.CodigoUsuario = usuario.CodigoUsuario;
            return dto;
        }

        /// <summary>
        /// Editar um usuário existente.
        /// </summary>
        /// <param name="dto">DTO do usuário a ser editado</param>
        /// <returns>True caso o usuário tenha sido editado com sucesso<br/>
        /// False caso o usuário não tenha sido encontrado</returns>
        public bool EditarUsuario(DTODeUsuario dto)
        {
            var usuario = (
                from user in _dbContext.Usuarios
                where user.CodigoUsuario == dto.CodigoUsuario
                    && !user.Excluido
                select user).FirstOrDefault();

            if (usuario == null)
            {
                return false;
            }

            usuario.NomeCompleto = dto.NomeCompleto.ToUpper();
            usuario.Altura = dto.Altura;
            usuario.Peso = dto.Peso;
            usuario.DataNascimento = dto.DataNascimento;
            _dbContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// Excluir usuário existente.
        /// </summary>
        /// <param name="codigoUsuario">Codigo do usuario a ser excluído</param>
        /// <returns>True caso o usuário tenha sido deletado com sucesso<br/>
        /// False caso o usuário não tenha sido encontrado<br/>
        /// Note que faz a delação lógica, não deletando o registro de fato</returns>
        public bool ExcluirUsuario(int codigoUsuario)
        {
            var usuario = (
                from user in _dbContext.Usuarios
                where user.CodigoUsuario == codigoUsuario
                    && !user.Excluido
                select user).FirstOrDefault();

            if (usuario == null)
            {
                return false;
            }

            usuario.Excluido = true;
            _dbContext.SaveChanges();

            return true;
        }
    }
}