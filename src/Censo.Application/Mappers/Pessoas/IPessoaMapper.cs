using Censo.Application.Dtos.Pessoa;
using Censo.Domain.Entities;

namespace Censo.Application.Mappers.Pessoas
{
    public interface IPessoaMapper : IMapper<PessoaInsertDto, Pessoa>
    {
    }
}
