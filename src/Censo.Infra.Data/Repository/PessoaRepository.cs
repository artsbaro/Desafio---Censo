using System.Collections.Generic;
using System.Data;
using Dapper;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Censo.Domain.Entities;
using Censo.Domain.Filters;
using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Types;

namespace Censo.Infra.Data.Repository
{
    public class PessoaRepository : RepositoryBase, IPessoaRepository
    {
        public PessoaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Create(Pessoa entity)
        {
            Connection.Execute(
                "SProc_Pessoa_Insert",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Id,
                    entity.Nome,
                    entity.SobreNome,
                    entity.Regiao,
                    MaeId = entity.Filiacao?.Mae?.Id,
                    PaiId = entity.Filiacao?.Pai?.Id,
                    GeneroId = entity.Genero.Id,
                    EscolaridadeId = entity.Escolaridade.Id,
                    EtniaId = entity.Etnia.Id,
                    entity.DataCadastro
                }
            );
        }

        public void Remove(Guid id)
        {
            Connection.Execute(
                "SProc_Pessoa_Delete",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    Id = id
                }
            );
        }

        public Pessoa FindById(Guid id)
        {
            var obj = Connection.QuerySingleOrDefault("SProc_Pessoa_GetById",
            commandType: CommandType.StoredProcedure,
            param: new { Id = id });

            if (obj == null)
                throw new ArgumentException("Pessoa não encontrada");

            return MapFromDB(obj);
        }

        public IEnumerable<Pessoa> List(PessoaFilter filter)
        {
            var result = Connection.Query("SProc_Pessoa_GetByFilter",
           commandType: CommandType.StoredProcedure,
           param: new
           {
               filter.Nome,
               filter.SobreNome,
               filter.Regiao,
               filter.NomeDaMae,
               filter.NomeDoPai,
               filter.GeneroId,
               filter.EtniaId,
               filter.EscolaridadeId
           });

            return MapFromDB(result);
        }

        public IEnumerable<Pessoa> ListChildren(Guid idParent)
        {
           var result = Connection.Query("SProc_Pessoa_GetByParentId",
           commandType: CommandType.StoredProcedure,
           param: new
           {
               idParent
           });

            return MapFromDB(result);
        }

        public void Update(Pessoa entity)
        {
            Connection.Execute(
                "SProc_Pessoa_Update",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Id,
                    entity.Nome,
                    entity.SobreNome,
                    entity.Regiao,
                    MaeId = entity.Filiacao?.Mae?.Id,
                    PaiId = entity.Filiacao?.Pai?.Id,
                    GeneroId = entity.Genero.Id,
                    EscolaridadeId = entity.Escolaridade.Id,
                    EtniaId = entity.Etnia.Id,
                }
            );
        }


        public decimal GetPercentPersonWhitNameByRegion(string region, string name)
        {
            var razao = Connection.QueryFirstOrDefault<decimal>("SProc_Pessoa_GetPercentPersonWhitNameByRegion",
            commandType: CommandType.StoredProcedure,
            param: new { Regiao = region, Nome = name });
            return razao;
        }


        #region Map
        public Pessoa MapFromDB(dynamic obj)
        {
            return new Pessoa
            {
                Id = obj.Id,
                Nome = obj.Nome,
                SobreNome = obj.SobreNome,
                Regiao = obj.Regiao,
                Etnia = new Etnia { Id = obj.EtniaId, Descricao = obj.EtniaNome },
                Genero = new Genero { Id = obj.GeneroId, Descricao = obj.GeneroNome },
                Escolaridade = new Escolaridade { Id = obj.EscolaridadeId, Descricao = obj.EscolaridadeNome },
                DataCadastro = obj.DataCadastro,
            };
        }

        public IEnumerable<Pessoa> MapFromDB(IEnumerable<dynamic> obj)
        {
            return obj.Select(x => (Pessoa)MapFromDB(x));
        }
        #endregion
    }
}
