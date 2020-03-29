using Censo.Application.Dtos.Etnia;
using System;
using System.Collections.Generic;

namespace Censo.Application.Interfaces
{
    public interface IEtniaService
    {
        byte Create(EtniaInsertDto entity);
        EtniaDto FindById(byte id);
        IEnumerable<EtniaDto> List();
        void Update(EtniaDto entity);
    }
}
