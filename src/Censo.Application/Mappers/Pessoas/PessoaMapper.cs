using Censo.Application.Dtos.Pessoa;
using Censo.Domain.Entities;
using Censo.Domain.Types;
using System.Collections.Generic;
using System.Linq;

namespace Censo.Application.Mappers.Pessoas
{
    public class PessoaMapper : IPessoaMapper
    {
        public Pessoa Map(PessoaInsertDto source)
        {
            return new Pessoa
            {
                Nome = source.Nome,
                SobreNome = source.SobreNome,
                Escolaridade = new Escolaridade { Id = source.EscolaridadeId },
                Genero = new Genero { Id = source.GeneroId },
                Etnia = new Etnia { Id = source.EtniaId },
                Filiacao = source.Filiacao == null ? new Filiacao() : new Filiacao
                {
                    Mae = new Pessoa { Id = source.Filiacao.MaeId.Value },
                    Pai = new Pessoa { Id = source.Filiacao.PaiId.Value }
                }
            };
        }

        public IEnumerable<Pessoa> Map(IEnumerable<PessoaInsertDto> source)
        {
            return source.Select(x => Map(x));
        }
    }
}
