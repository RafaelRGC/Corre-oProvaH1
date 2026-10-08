using System.ComponentModel.DataAnnotations;

namespace CorreçãoH1.Models
{
    public class UFValidacao : ValidationAttribute
    {
        private readonly string[] ufsPermitidas =
        {
            "MG", "SP", "RJ", "ES"
        };

        public UFValidacao()
        {
            ErrorMessage = "A UF deve ser MG, SP, RJ ou ES.";
        }

        public override bool IsValid(object? value)
        {
            return value is string uf &&
                   ufsPermitidas.Contains(uf);
        }
    }
}
