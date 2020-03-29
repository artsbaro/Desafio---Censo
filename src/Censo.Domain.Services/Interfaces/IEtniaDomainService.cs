using Censo.Domain.Types;
using System.Collections.Generic;

namespace Censo.Domain.Services.Interfaces
{
    public interface IEtniaDomainService
    {
        void Create(Etnia entity);
        void Update(Etnia entity);
        IEnumerable<Etnia> List();
        Etnia FindById(byte id);
    }
}
