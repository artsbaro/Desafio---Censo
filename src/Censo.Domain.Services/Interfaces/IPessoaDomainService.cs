using Censo.Domain.Entities;
using Censo.Domain.Filters;
using System;
using System.Collections.Generic;

namespace Censo.Domain.Services.Interfaces
{
    public interface IPessoaDomainService
    {
        void Create(Pessoa entity);
        void Update(Pessoa entity);
        void Remove(Guid id);
        IEnumerable<Pessoa> List(PessoaFilter filter);
        Pessoa FindById(Guid id);
        IEnumerable<Pessoa> ListChildren(Guid idParent);

        decimal GetPercentPersonWhitNameByRegion(string region, string name);

        Pessoa GetGenealogy(Guid id, byte level);
    }
}
