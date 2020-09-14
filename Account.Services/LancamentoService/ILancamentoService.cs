using Account.Domain;

namespace Account.Services.LancamentoService
{
    public interface ILancamentoService
    {
        Result Lancar(Operacao operacao);
    }
}