using FitnessStore.API.Core.Entities;
using FitnessStore.API.Models.DTO;
using FitnessStore.API.Models.Projecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessStore.API.Services
{
    /// <summary>
    /// Classe de serviço para as refeições do sistema.
    /// </summary>
    public class ServicoDeRefeicao
    {
        #region Atributos

        private readonly FitnessStoreDbContext _dbContext;

        #endregion  

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="dbContext"></param>
        public ServicoDeRefeicao(FitnessStoreDbContext dbContex)
        {
            _dbContext = dbContex;
        }

        /// <summary>
        /// Obtem uma refeição através do seu identificador.
        /// </summary>
        /// <param name="codigoUsuario">Codigo identificador do usuário ao qual a refeição pertence</param>
        /// <param name="codigoRefeicao">Codigo identificador da refeição</param>
        /// <returns>DTO da refeição encontrada</returns>
        public DTODeRefeicao ObterRefeicaoPorId(int codigoUsuario, int codigoRefeicao)
        {
            var refeicao = (
                from refeic in _dbContext.Refeicoes
                where refeic.CodigoUsuario == codigoUsuario
                    && refeic.CodigoRefeicao == codigoRefeicao
                    && !refeic.Excluido
                select refeic).FirstOrDefault();

            if (refeicao == null)
            {
                return null;
            }

            return new DTODeRefeicao()
            {
                CodigoRefeicao = refeicao.CodigoRefeicao,
                Descricao = refeicao.Descricao,
                Calorias = refeicao.Calorias,
                DataRealizada = refeicao.DataRealizada,
                CodigoUsuario = refeicao.CodigoUsuario
            };
        }

        /// <summary>
        /// Adicionar uma nova refeição no sistema.
        /// </summary>
        /// <param name="dto">DTO da refeição a ser adicionada</param>
        /// <returns>DTO da refeição com o código da refeição adicionada</returns>
        public DTODeRefeicao AdicionarRefeicao(DTODeRefeicao dto)
        {
            var descricaoMaiusculo = dto.Descricao.ToUpper();
            var refeicaoJaExiste = (
                from refeic in _dbContext.Refeicoes
                where refeic.Descricao == descricaoMaiusculo
                    && refeic.Calorias == dto.Calorias
                    && refeic.CodigoUsuario == dto.CodigoUsuario
                    && !refeic.Excluido
                select 1).Any();

            if (refeicaoJaExiste)
            {
                return null;
            }

            var refeicao = new Refeicao()
            {
                Descricao = descricaoMaiusculo,
                Calorias = dto.Calorias,
                DataRealizada = dto.DataRealizada,
                CodigoUsuario = dto.CodigoUsuario,
                DataInclusao = DateTimeOffset.Now,
                Excluido = false
            };

            _dbContext.Refeicoes.Add(refeicao);
            _dbContext.SaveChanges();

            dto.Descricao = descricaoMaiusculo;
            dto.CodigoRefeicao = refeicao.CodigoRefeicao;
            dto.CodigoUsuario = refeicao.CodigoUsuario;
            return dto;
        }

        /// <summary>
        /// Editar uma refeição existente.
        /// </summary>
        /// <param name="dto">DTO da refeição com os dados atualizados</param>
        /// <returns>True caso a refeição tenha sido editada<br/>
        /// False caso a refeição não tenha sido encontrada no sistema</returns>
        public bool EditarRefeicao(DTODeRefeicao dto)
        {
            var refeicao = (
                from refeic in _dbContext.Refeicoes
                where refeic.CodigoRefeicao == dto.CodigoRefeicao
                    && refeic.CodigoUsuario == dto.CodigoUsuario
                    && !refeic.Excluido
                select refeic).FirstOrDefault();

            if (refeicao == null)
            {
                return false;
            }

            refeicao.Descricao = dto.Descricao.ToUpper();
            refeicao.Calorias = dto.Calorias;
            refeicao.DataRealizada = dto.DataRealizada;
            _dbContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// Deletar uma refeição do sistema
        /// </summary>
        /// <param name="codigoUsuario">Código identificador do usuário ao qual a refeição pertence</param>
        /// <param name="codigoRefeicao">Código identificador da refeição</param>
        /// <returns>True caso a refeição tenha sido deletada<br/>
        /// False caso a refeição não tenha sido encontrada<br/>
        /// Note que a deleção é lógica e não de fato removido do sistema.</returns>
        public bool DeletarRefeicao(int codigoUsuario, int codigoRefeicao)
        {
            var refeicao = (
                from refeic in _dbContext.Refeicoes
                where refeic.CodigoRefeicao == codigoRefeicao
                    && refeic.CodigoUsuario == codigoUsuario
                    && !refeic.Excluido
                select refeic).First();

            if (refeicao == null)
            {
                return false;
            }

            refeicao.Excluido = true;
            _dbContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// Listar todas as refeições do sistema pertencentes ao usuário informado
        /// </summary>
        /// <param name="id">Identificador do usuário a ser utilizado como filtro da consulta </param>
        /// <returns>Lista com todas as refeições do usuário informado</returns>
        public IEnumerable<ProjecaoDeRefeicao> ListarTodas(int id)
        {
            var existeUsuario = (
                from user in _dbContext.Usuarios
                where user.CodigoUsuario == id
                    && !user.Excluido
                select 1).Any();

            if (!existeUsuario)
            {
                return null;
            }

            var refeicoes = (
                from refeic in _dbContext.Refeicoes
                where refeic.CodigoUsuario == id
                    && !refeic.Excluido
                select new ProjecaoDeRefeicao
                {
                    Descricao = refeic.Descricao,
                    Calorias = refeic.Calorias,
                    DataRealizada = refeic.DataRealizada
                }).ToList();

            return refeicoes;
        }
    }
}