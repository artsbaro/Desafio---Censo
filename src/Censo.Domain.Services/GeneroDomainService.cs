using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;
using System.Collections.Generic;
using System.Transactions;

namespace Censo.Domain.Services
{
    public class GeneroDomainService : IGeneroDomainService
    {
        private readonly IGeneroRepository _GeneroRepository;

        public GeneroDomainService(IGeneroRepository GeneroRepository)
        {
            _GeneroRepository = GeneroRepository;
        }

        public void Create(Genero entity)
        {
            using (var trans = new TransactionScope())
            {
                _GeneroRepository.Create(entity);
                trans.Complete();
            }
        }

        public Genero FindById(byte id)
        {
            return _GeneroRepository.FindById(id);
        }

        public IEnumerable<Genero> List()
        {
            return _GeneroRepository.List();
        }

        public void Update(Genero entity)
        {
            using (var trans = new TransactionScope())
            {
                _GeneroRepository.Update(entity);
                trans.Complete();
            }
        }
    }
}
