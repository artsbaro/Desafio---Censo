using Censo.Domain.Entities;
using Censo.Domain.Filters;
using System;
using System.Collections.Generic;

namespace Censo.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa, PessoaFilter>
    {
        IEnumerable<Pessoa> ListChildren(Guid idParent);
        decimal GetPercentPersonWhitNameByRegion(string region, string name);
    }
}

