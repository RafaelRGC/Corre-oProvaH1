using CorreçãoH1.Models;

namespace CorreçãoH1.Interfaces
{
    public interface IEleitorRepository
    {
        List<Eleitor> ListarEleitores();

        bool CadastrarEleitor(Eleitor eleitor);

        bool RegistrarJustificativa(
            Justificativa justificativa);

        List<Justificativa> ListarJustificativas();
    }
}
