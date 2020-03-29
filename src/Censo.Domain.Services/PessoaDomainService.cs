using Censo.Domain.Entities;
using Censo.Domain.Filters;
using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Censo.Domain.Services
{
    public class PessoaDomainService : IPessoaDomainService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaDomainService(IPessoaRepository receitaRepository)
        {
            _pessoaRepository = receitaRepository;
        }

        public void Create(Pessoa entity)
        {

            using (var trans = new TransactionScope())
            {
                _pessoaRepository.Create(entity);
                foreach (var item in entity.Filhos ?? Enumerable.Empty<Pessoa>())
                {
                    _pessoaRepository.Create(item);
                }
                trans.Complete();
            }
        }

        public Pessoa FindById(Guid id)
        {
            var pessoa = _pessoaRepository.FindById(id);
            //pessoa.Filhos = _pessoaRepository(receita.Id); Buscar Filhos da pessoa
            return pessoa;
        }

        public IEnumerable<Pessoa> List(PessoaFilter filter)
        {
            return _pessoaRepository.List(filter);
        }

        public void Remove(Guid id)
        {
            _pessoaRepository.Remove(id);
        }

        public void Update(Pessoa entity)
        {
            using (var trans = new TransactionScope())
            {
                _pessoaRepository.Update(entity);
                foreach (var item in entity.Filhos ?? Enumerable.Empty<Pessoa>())
                {
                    _pessoaRepository.Create(item);
                }
                trans.Complete();
            }
        }
    }
}

