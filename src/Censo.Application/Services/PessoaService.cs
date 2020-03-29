using System;
using System.Collections.Generic;
using Censo.Application.Dtos.Pessoa;
using Censo.Application.Interfaces;
using Censo.Application.Mappers.Default;
using Censo.Application.Mappers.Pessoas;
using Censo.Domain.Entities;
using Censo.Domain.Filters;
using Censo.Domain.Services.Interfaces;

namespace Censo.Application.Services
{
    public class PessoaService : IPessoaService, IDisposable
    {
        private readonly IPessoaDomainService _service;
        private readonly IPessoaMapper _PessoaMapper;
        private readonly IPessoaDtoMapper _PessoaDtoMapper;


        public PessoaService(IPessoaDomainService service,
                                IPessoaMapper PessoaMapper,
                                IPessoaDtoMapper PessoaDtoMapper)
        {
            _service = service;
            _PessoaMapper = PessoaMapper;
            _PessoaDtoMapper = PessoaDtoMapper;
        }

        public Guid Create(PessoaInsertDto dto)
        {
            var pessoa = _PessoaMapper.Map(dto);
            _service.Create(pessoa);
            return pessoa.Id;
        }

        public IEnumerable<PessoaDto> List(PessoaFilter filter)
        {
            var list = _service.List(filter);
            return _PessoaDtoMapper.Map(list);
        }

        public void Remove(Guid id)
        {
            _service.Remove(id);
        }

        public PessoaDto FindById(Guid id)
        {
            var Pessoa = _service.FindById(id);
            if (Pessoa == null)
                throw new ArgumentException("Pessoa não encontrada");

            return _PessoaDtoMapper.Map(Pessoa);
        }

        public void Update(PessoaDto entity)
        {
            _service.Update(TypeConverter.ConvertTo<Pessoa>(entity));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}



