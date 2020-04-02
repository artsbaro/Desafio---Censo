using System;

namespace Censo.Application.Dtos.Filiacao
{
    public class FiliacaoInsertDto
    {
        public Guid? MaeId { get; set; }
        public Guid? PaiId { get; set; }
    }
}
