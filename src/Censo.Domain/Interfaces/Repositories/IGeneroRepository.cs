using Censo.Domain.Types;
using System;
using System.Collections.Generic;

namespace Censo.Domain.Interfaces.Repositories
{
    public interface IGeneroRepository : IRepository
    {
        void Create(Genero entity);
        IEnumerable<Genero> List();
        Genero FindById(byte id);

        void Update(Genero entity);
    }
}
