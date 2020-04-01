using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;
using System.Collections.Generic;
using System.Transactions;

namespace Censo.Domain.Services
{
    public class EscolariadeDomainService : IEscolaridadeDomainService
    {
        private readonly IEscolaridadeRepository  _EscolaridadeRepository;

        public EscolariadeDomainService( IEscolaridadeRepository escolaridadeRepository)
        {
            _EscolaridadeRepository = escolaridadeRepository;
        }

        public byte Create(Escolaridade entity)
        {
            using (var trans = new TransactionScope())
            {
                var id = _EscolaridadeRepository.Create(entity);
                trans.Complete();
                return id;
            }
        }

        public Escolaridade FindById(byte id)
        {
            return _EscolaridadeRepository.FindById(id);
        }

        public IEnumerable<Escolaridade> List()
        {
            return _EscolaridadeRepository.List();
        }

        public void Update(Escolaridade entity)
        {
            using (var trans = new TransactionScope())
            {
                _EscolaridadeRepository.Update(entity);
                trans.Complete();
            }
        }
    }
}
