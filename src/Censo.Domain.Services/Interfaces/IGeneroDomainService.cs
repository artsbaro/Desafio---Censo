using Censo.Domain.Types;
using System.Collections.Generic;

namespace Censo.Domain.Services.Interfaces
{
    public interface IGeneroDomainService
    {
        void Create(Genero entity);
        void Update(Genero entity);
        IEnumerable<Genero> List();
        Genero FindById(byte id);
    }
}
