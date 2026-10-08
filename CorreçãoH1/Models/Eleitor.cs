using System.ComponentModel.DataAnnotations;

namespace CorreçãoH1.Models
{
    public class Eleitor
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, MinimumLength = 3,
    ErrorMessage = "O nome deve ter entre 3 e 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O título de eleitor é obrigatório.")]
        [StringLength(50,
            ErrorMessage = "O título pode ter no máximo 50 caracteres.")]
        public string TituloEleitor { get; set; } = string.Empty;

        [Required(ErrorMessage = "A UF é obrigatória.")]
        [UFValidacao]
        public string UF { get; set; } = string.Empty;
    }
}
