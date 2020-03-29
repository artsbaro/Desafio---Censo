using Censo.Application.Dtos.Pessoa;
using Censo.Domain.Filters;
using System;
using System.Collections.Generic;

namespace Censo.Application.Interfaces
{
    public interface IPessoaService
    {
        Guid Create(PessoaInsertDto entity);
        void Remove(Guid id);
        PessoaDto FindById(Guid id);
        IEnumerable<PessoaDto> List(PessoaFilter filter);
        void Update(PessoaDto entity);
    }
}
