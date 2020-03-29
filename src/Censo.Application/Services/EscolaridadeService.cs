using System;
using System.Collections.Generic;
using Censo.Application.Dtos.Escolaridade;
using Censo.Application.Interfaces;
using Censo.Application.Mappers.Default;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;

namespace Censo.Application.Services
{
    public class EscolaridadeService : IEscolaridadeService, IDisposable
    {
        private readonly IEscolaridadeDomainService _service;

        public EscolaridadeService(IEscolaridadeDomainService service)
        {
            _service = service;
        }

        public byte Create(EscolaridadeInsertDto entity)
        {
            var objPersistencia = TypeConverter.ConvertTo<Escolaridade>(entity);
            _service.Create(objPersistencia);
            return objPersistencia.Id;
        }

        public IEnumerable<EscolaridadeDto> List()
        {
            var list = _service.List();
            return TypeConverter.ConvertTo<IEnumerable<EscolaridadeDto>>(list);
        }

        //public void Remove(Guid id)
        //{
        //    _service.Remove(id);
        //}

        public EscolaridadeDto FindById(byte id)
        {
            var Escolaridade = _service.FindById(id);
            return TypeConverter.ConvertTo<EscolaridadeDto>(Escolaridade);
        }

        public void Update(EscolaridadeDto entity)
        {
            _service.Update(TypeConverter.ConvertTo<Escolaridade>(entity));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}



