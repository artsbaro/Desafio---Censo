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
                Regiao = source.Regiao,
                Escolaridade = new Escolaridade { Id = source.EscolaridadeId },
                Genero = new Genero { Id = source.GeneroId },
                Etnia = new Etnia { Id = source.EtniaId },
                Filiacao = source.Filiacao == null ? new Filiacao() : new Filiacao
                {
                    Mae = new Pessoa { Id = source.Filiacao.MaeId.Value },
                    Pai = new Pessoa { Id = source.Filiacao.PaiId.Value }
                },
                Filhos = source.Filhos?.Select(f => new Pessoa
                {
                    Nome = f.Nome,
                    SobreNome = f.SobreNome,
                    Etnia = new Etnia { Id = f.EtniaId },
                    Escolaridade = new Escolaridade { Id = f.EscolaridadeId },
                    Genero = new Genero { Id = f.GeneroId}
                })
            };
        }

        public IEnumerable<Pessoa> Map(IEnumerable<PessoaInsertDto> source)
        {
            return source.Select(x => Map(x));
        }

        public Pessoa Map(PessoaUpdateDto source)
        {
            return new Pessoa
            {
                Id = source.Id,
                Nome = source.Nome,
                SobreNome = source.SobreNome,
                Regiao = source.Regiao,
                Escolaridade = new Escolaridade { Id = source.EscolaridadeId },
                Genero = new Genero { Id = source.GeneroId },
                Etnia = new Etnia { Id = source.EtniaId },
                Filiacao = source.Filiacao == null ? new Filiacao() : new Filiacao
                {
                    Mae = (source.Filiacao.MaeId != null) ? new Pessoa { Id = source.Filiacao.MaeId.Value } : null,
                    Pai = (source.Filiacao.PaiId != null) ? new Pessoa { Id = source.Filiacao.PaiId.Value } : null,
                },
                Filhos = source.Filhos?.Select(f => new Pessoa
                {
                    Nome = f.Nome,
                    SobreNome = f.SobreNome,
                    Etnia = new Etnia { Id = f.EtniaId },
                    Escolaridade = new Escolaridade { Id = f.EscolaridadeId },
                    Genero = new Genero { Id = f.GeneroId }
                })
            };
        }

        public IEnumerable<Pessoa> Map(IEnumerable<PessoaUpdateDto> source)
        {
            return source.Select(x => Map(x));
        }
    }
}
