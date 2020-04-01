using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;
using System.Collections.Generic;
using System.Transactions;

namespace Censo.Domain.Services
{
    public class EtniaDomainService : IEtniaDomainService
    {
        private readonly IEtniaRepository  _EtniaRepository;

        public EtniaDomainService( IEtniaRepository EtniaRepository)
        {
            _EtniaRepository = EtniaRepository;
        }

        public byte Create(Etnia entity)
        {
            using (var trans = new TransactionScope())
            {
                var id =_EtniaRepository.Create(entity);
                trans.Complete();
                return id;
            }
        }

        public Etnia FindById(byte id)
        {
            return _EtniaRepository.FindById(id);
        }

        public IEnumerable<Etnia> List()
        {
            return _EtniaRepository.List();
        }

        public void Update(Etnia entity)
        {
            using (var trans = new TransactionScope())
            {
                _EtniaRepository.Update(entity);
                trans.Complete();
            }
        }
    }
}
