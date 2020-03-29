using Censo.Application.Dtos.Pessoa;

namespace Censo.Application.Dtos.Filiacao
{
    public class FiliacaoDto
    {
        public PessoaDto Mae { get; set; }
        public PessoaDto Pai { get; set; }
    }
}
