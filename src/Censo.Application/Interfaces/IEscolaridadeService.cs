using Censo.Application.Dtos.Escolaridade;
using System.Collections.Generic;

namespace Censo.Application.Interfaces
{
    public interface IEscolaridadeService
    {
        byte Create(EscolaridadeInsertDto entity);
        EscolaridadeDto FindById(byte id);
        IEnumerable<EscolaridadeDto> List();
        void Update(EscolaridadeDto entity);
    }
}
