using System.Collections.Generic;
using System.Linq;
using Censo.Application.Dtos.Pessoa;
using Censo.Application.Mappers.Default;
using Censo.Domain.Entities;

namespace Censo.Application.Mappers.Pessoas
{
    public class PessoaDtoMapper : IPessoaDtoMapper
    {
        public PessoaDto Map(Pessoa source)
        {
            return TypeConverter.ConvertTo<PessoaDto>(source);
        }

        public IEnumerable<PessoaDto> Map(IEnumerable<Pessoa> source)
        {
            return source.Select(x => Map(x));
        }
    }
}
