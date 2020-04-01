using Censo.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Censo.Domain.Types;

namespace Censo.Infra.Data.Repository
{
    public class EtniaRepository : RepositoryBase, IEtniaRepository
    {
        public EtniaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public byte Create(Etnia entity)
        {
            var id =  Connection.QuerySingle<byte>(
                "SProc_Etnia_Insert",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Descricao
                }
            );

            return id;
        }


        public Etnia FindById(byte id)
        {
            return Connection.QueryFirstOrDefault<Etnia>(
               "SProc_Etnia_GetById",
               commandType: CommandType.StoredProcedure,
                param: new
                {
                    Id = id
                }
            );
        }

        public IEnumerable<Etnia> List()
        {
            return Connection.Query<Etnia>(
               "SProc_Etnia_GetAll",
               commandType: CommandType.StoredProcedure
           );
        }

        public void Update(Etnia entity)
        {
            Connection.Execute(
                "SProc_Etnia_Update",
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
