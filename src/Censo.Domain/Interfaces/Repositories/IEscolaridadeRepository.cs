using Censo.Domain.Types;
using System;
using System.Collections.Generic;

namespace Censo.Domain.Interfaces.Repositories
{
    public interface IEscolaridadeRepository : IRepository
    {
        byte Create(Escolaridade entity);
        IEnumerable<Escolaridade> List();
        Escolaridade FindById(byte id);
        void Update(Escolaridade entity);
    }
}
