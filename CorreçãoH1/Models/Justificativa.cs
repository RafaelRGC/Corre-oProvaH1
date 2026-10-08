using System.ComponentModel.DataAnnotations;

namespace CorreçãoH1.Models
{
    public class Justificativa
    {
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$",
    ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [Range(1, 2,
            ErrorMessage = "O turno deve ser 1 ou 2.")]
        public int Turno { get; set; }

        [Required(ErrorMessage = "A justificativa é obrigatória.")]
        public string Texto { get; set; } = string.Empty;
    }
}
