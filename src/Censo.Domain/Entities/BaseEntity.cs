using System;

namespace Censo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
    }
}