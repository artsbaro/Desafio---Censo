﻿using Censo.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Censo.Domain.Types;

namespace Censo.Infra.Data.Repository
{
    public class GeneroRepository : RepositoryBase, IGeneroRepository
    {
        public GeneroRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Create(Genero entity)
        {
            Connection.Execute(
                "SProc_Genero_Insert",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    entity.Id,
                    entity.Descricao
                }
            );
        }


        public Genero FindById(byte id)
        {
            return Connection.QueryFirstOrDefault<Genero>(
               "SProc_Genero_GetById",
               commandType: CommandType.StoredProcedure,
                param: new
                {
                    Id = id
                }
            );
        }

        public IEnumerable<Genero> List()
        {
            return Connection.Query<Genero>(
               "SProc_Genero_GetAll",
               commandType: CommandType.StoredProcedure
           );
        }

        //public void Remove(byte id)
        //{
        //    throw new NotImplementedException();

        //    //Connection.Execute(
        //    //    "SProc_Genero_Delete",
        //    //    commandType: CommandType.StoredProcedure,
        //    //    param: new
        //    //    {
        //    //        Id = id
        //    //    }
        //    //);
        //}

        public void Update(Genero entity)
        {
            Connection.Execute(
                "SProc_Genero_Update",
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
