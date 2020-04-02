using System;

namespace Censo.Domain.Filters
{
    public class PessoaFilter
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public byte? GeneroId { get; set; }
        public byte? EscolaridadeId { get; set; }
        public byte? EtniaId { get; set; }
    }
}
