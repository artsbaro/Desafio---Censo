using Censo.Domain.Types;
using System.Collections.Generic;

namespace Censo.Domain.Services.Interfaces
{
    public interface IEscolaridadeDomainService
    {
        void Create(Escolaridade entity);
        void Update(Escolaridade entity);
        IEnumerable<Escolaridade> List();
        Escolaridade FindById(byte id);
    }
}
