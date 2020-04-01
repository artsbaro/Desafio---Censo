using System;
using System.Collections.Generic;
using Censo.Application.Dtos.Etnia;
using Censo.Application.Interfaces;
using Censo.Application.Mappers.Default;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;

namespace Censo.Application.Services
{
    public class EtniaService : IEtniaService, IDisposable
    {
        private readonly IEtniaDomainService _service;

        public EtniaService(IEtniaDomainService service)
        {
            _service = service;
        }

        public byte Create(EtniaInsertDto entity)
        {
            var objPersistencia = TypeConverter.ConvertTo<Etnia>(entity);
            return _service.Create(objPersistencia);
        }

        public IEnumerable<EtniaDto> List()
        {
            var list = _service.List();
            return TypeConverter.ConvertTo<IEnumerable<EtniaDto>>(list);
        }

        //public void Remove(Guid id)
        //{
        //    _service.Remove(id);
        //}

        public EtniaDto FindById(byte id)
        {
            var Etnia = _service.FindById(id);
            return TypeConverter.ConvertTo<EtniaDto>(Etnia);
        }

        public void Update(EtniaDto entity)
        {
            _service.Update(TypeConverter.ConvertTo<Etnia>(entity));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}



