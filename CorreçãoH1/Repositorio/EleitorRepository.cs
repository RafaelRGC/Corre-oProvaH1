using CorreçãoH1.Interfaces;
using CorreçãoH1.Models;

namespace CorreçãoH1.Repositorio
{
    public class EleitorRepository : IEleitorRepository
    {
        private readonly List<Eleitor> eleitores = new();
        private readonly List<Justificativa> justificativas = new();

        public List<Eleitor> ListarEleitores()
        {
            return eleitores;
        }

        public bool CadastrarEleitor(Eleitor eleitor)
        {
            bool cpfExiste = eleitores.Any(e =>
                e.CPF == eleitor.CPF);

            if (cpfExiste)
            {
                return false;
            }

            eleitores.Add(eleitor);
            return true;
        }

        public bool RegistrarJustificativa(
            Justificativa justificativa)
        {
            bool jaRegistrada = justificativas.Any(j =>
                j.CPF == justificativa.CPF &&
                j.Turno == justificativa.Turno);

            if (jaRegistrada)
            {
                return false;
            }

            justificativas.Add(justificativa);
            return true;
        }

        public List<Justificativa> ListarJustificativas()
        {
            return justificativas;
        }
    }
}
