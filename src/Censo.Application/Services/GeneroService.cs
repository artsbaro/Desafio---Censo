using System;
using System.Collections.Generic;
using Censo.Application.Dtos.Genero;
using Censo.Application.Interfaces;
using Censo.Application.Mappers.Default;
using Censo.Domain.Services.Interfaces;
using Censo.Domain.Types;

namespace Censo.Application.Services
{
    public class GeneroService : IGeneroService, IDisposable
    {
        private readonly IGeneroDomainService _service;

        public GeneroService(IGeneroDomainService service)
        {
            _service = service;
        }

        public byte Create(GeneroInsertDto entity)
        {
            var objPersistencia = TypeConverter.ConvertTo<Genero>(entity);
            return _service.Create(objPersistencia);
        }

        public IEnumerable<GeneroDto> List()
        {
            var list = _service.List();
            return TypeConverter.ConvertTo<IEnumerable<GeneroDto>>(list);
        }

        //public void Remove(Guid id)
        //{
        //    _service.Remove(id);
        //}

        public GeneroDto FindById(byte id)
        {
            var Genero = _service.FindById(id);
            return TypeConverter.ConvertTo<GeneroDto>(Genero);
        }

        public void Update(GeneroDto entity)
        {
            _service.Update(TypeConverter.ConvertTo<Genero>(entity));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}



