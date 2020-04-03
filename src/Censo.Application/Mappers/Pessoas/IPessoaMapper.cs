using Censo.Application.Dtos.Pessoa;
using Censo.Domain.Entities;
using System.Collections.Generic;

namespace Censo.Application.Mappers.Pessoas
{
    public interface IPessoaMapper : IMapper<PessoaInsertDto, Pessoa>
    {
        Pessoa Map(PessoaUpdateDto source);

        IEnumerable<Pessoa> Map(IEnumerable<PessoaUpdateDto> source);
    }
}
