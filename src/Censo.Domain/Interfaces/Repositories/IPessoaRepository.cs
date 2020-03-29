using Censo.Domain.Entities;
using Censo.Domain.Filters;

namespace Censo.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa, PessoaFilter>
    {

    }
}

