using Censo.Domain.Types;
using System.Collections.Generic;

namespace Censo.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public Genero Genero { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Etnia Etnia { get; set; }
        public Filiacao Filiacao { get; set; }
        public IEnumerable<Pessoa> Filhos { get; set; }
    }
}
