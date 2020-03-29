using System.ComponentModel.DataAnnotations;

namespace Censo.Application.Dtos.Types
{
    public class TypeBaseDto
    {
        [Required(ErrorMessage = "Identidicador(Id) não preenchido.")]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Descricao não preenchido.")]
        [MinLength(3, ErrorMessage = "Descricao deve ter mais que 3 caracteres")]
        [MaxLength(128, ErrorMessage = "Descricao deve ter menos que 128 caracteres")]
        public string Descricao { get; set; }
    }
}
