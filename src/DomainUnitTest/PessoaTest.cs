using Censo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DomainUnitTest
{    
    public class PessoaTest
    {
        [Fact]
        public void PessoaHasChildrenTrue()
        {
            Pessoa pessoa = new Pessoa {
                Id = Guid.NewGuid(),
                Nome = "Antonio",
                SobreNome = "Raulande",
                Regiao = "Leste",
                Filhos = new List<Pessoa> { 
                    new Pessoa
                    {
                        Nome = "Fabio",
                        SobreNome = "Silva"
                    }
                }
            };

            Assert.True(pessoa.HasChildren);
        }

        [Fact]
        public void PessoaHasChildrenNoSet()
        {
            Pessoa pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Antonio",
                SobreNome = "Raulande",
                Regiao = "Leste"
            };

            Assert.False(pessoa.HasChildren);
        }

        [Fact]
        public void PessoaHasChildrenNull()
        {
            Pessoa pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Antonio",
                SobreNome = "Raulande",
                Regiao = "Leste",
                Filhos = null
            };

            Assert.False(pessoa.HasChildren);
        }

        [Fact]
        public void PessoaHasChildrenCount()
        {
            Pessoa pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = "Antonio",
                SobreNome = "Raulande",
                Regiao = "Leste",
                Filhos = Enumerable.Empty<Pessoa>()
            };

            Assert.False(pessoa.HasChildren);
        }
    }
}
