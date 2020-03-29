using Censo.Application.Dtos.Escolaridade;
using Censo.Application.Dtos.Etnia;
using Censo.Application.Dtos.Filiacao;
using Censo.Application.Dtos.Genero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Censo.Application.Dtos.Pessoa
{
    public class PessoaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome não preenchido.")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais que 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter menos que 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "SobreNome não preenchido.")]
        [MinLength(3, ErrorMessage = "SobreNome deve ter mais que 3 caracteres")]
        [MaxLength(100, ErrorMessage = "SobreNome deve ter menos que 100 caracteres")]
        public string SobreNome { get; set; }
        public GeneroDto Genero { get; set; }
        public EscolaridadeDto Escolaridade { get; set; }
        public EtniaDto Etnia { get; set; }
        public FiliacaoDto Filiacao { get; set; }
        public IEnumerable<PessoaDto> Filhos { get; set; }

    }
}


