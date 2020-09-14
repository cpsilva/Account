using Account.DataAccess.UnitOfWork;
using Account.Domain;
using Account.Domain.Enum;

namespace Account.Services.LancamentoService
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LancamentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Lancar(Operacao operacao)
        {
            var contaOrigem = _unitOfWork.QueryStack.ContaCorrente.Selecionar(x => x.ContaCorrenteId == operacao.ContaOrigem);
            var contaDestino = _unitOfWork.QueryStack.ContaCorrente.Selecionar(x => x.ContaCorrenteId == operacao.ContaDestino);

            var resultContas = ValidarContas(contaOrigem, contaDestino);

            if (!resultContas.Success) { return resultContas; }

            var consultaSaldo = ChecaSaldoConta(contaOrigem.Saldo, operacao.Valor);

            if (!consultaSaldo.Success) { return consultaSaldo; }

            RealizarLancamento(contaOrigem, operacao.Valor, (int)TipoLancamentoEnum.Debito);

            RealizarLancamento(contaDestino, operacao.Valor, (int)TipoLancamentoEnum.Credito);

            return new Result(true);
        }

        private void RealizarLancamento(ContaCorrente conta, double valor, int lancamentoId)
        {
            if (lancamentoId == (int)TipoLancamentoEnum.Credito)
            {
                conta.Saldo = conta.Saldo + valor;
            }

            if (lancamentoId == (int)TipoLancamentoEnum.Debito)
            {
                conta.Saldo = conta.Saldo - valor;
            }

            _unitOfWork.CommandStack.Lancamento.Adicionar(new Lancamento { ContaCorrenteId = conta.ContaCorrenteId, LancamentoId = lancamentoId, Valor = valor });
            _unitOfWork.CommandStack.ContaCorrente.Atualizar(conta);
            _unitOfWork.CommandStack.SaveChanges();
        }

        private Result ValidarContas(ContaCorrente contaOrigem, ContaCorrente contaDestino)
        {
            if (contaOrigem == null || !_unitOfWork.QueryStack.ContaCorrente.Existe(x => x.ContaCorrenteId == contaOrigem.ContaCorrenteId))
            {
                return new Result(false, "Conta origem não existe");
            }

            if (contaDestino == null || !_unitOfWork.QueryStack.ContaCorrente.Existe(x => x.ContaCorrenteId == contaDestino.ContaCorrenteId))
            {
                return new Result(false, "Conta destino não existe");
            }

            if (contaOrigem.ContaCorrenteId == contaDestino.ContaCorrenteId)
            {
                return new Result(false, "Conta origem e destino devem ser diferentes para realizar esta operação");
            }

            return new Result(true);
        }

        private Result ChecaSaldoConta(double saldoContaOrigem, double valorOperacao)
        {
            if (valorOperacao <= 0)
            {
                return new Result(false, "O valor da operação deve ser maior que zero");
            }

            if (saldoContaOrigem < valorOperacao)
            {
                return new Result(false, "O saldo em conta não é o suficiente para realizar a operação");
            }

            return new Result(true);
        }
    }
}