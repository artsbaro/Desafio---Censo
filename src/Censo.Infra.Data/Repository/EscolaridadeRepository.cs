using Censo.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Censo.Domain.Types;

namespace Censo.Infra.Data.Repository
{
    public class EscolaridadeRepository : RepositoryBase, IEscolaridadeRepository
    {
        public EscolaridadeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Create(Escolaridade entity)
        {
            Connection.Execute(
                "SProc_Escolaridade_Insert",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Id,
                    entity.Descricao
                }
            );
        }


        public Escolaridade FindById(byte id)
        {
            return Connection.QueryFirstOrDefault<Escolaridade>(
               "SProc_Escolaridade_GetById",
               commandType: CommandType.StoredProcedure,
                param: new
                {
                    Id = id
                }
            );
        }

        public IEnumerable<Escolaridade> List()
        {
            return Connection.Query<Escolaridade>(
               "SProc_Escolaridade_GetAll",
               commandType: CommandType.StoredProcedure
           );
        }

        public void Update(Escolaridade entity)
        {
            Connection.Execute(
                "SProc_Escolaridade_Update",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Id,
                    entity.Descricao
                }
            );
        }
    }
}
