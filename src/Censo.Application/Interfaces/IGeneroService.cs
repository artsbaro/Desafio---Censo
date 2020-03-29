using Censo.Application.Dtos.Genero;
using System.Collections.Generic;

namespace Censo.Application.Interfaces
{
    public interface IGeneroService
    {
        byte Create(GeneroInsertDto entity);
        GeneroDto FindById(byte id);
        IEnumerable<GeneroDto> List();
        void Update(GeneroDto entity);
    }
}
