using Account.DataAccess.Database.Context;
using Account.DataAccess.UnitOfWork;
using Account.DependencyInjection;
using Account.Domain;
using Account.Services.LancamentoService;
using System;
using Xunit;

namespace Account.Test
{
    public class LancamentoTest
    {
        private ILancamentoService _lancamentoService { get; }
        private IUnitOfWork _unitOfWork { get; }

        public LancamentoTest()
        {
            Container.RegisterServices();
            Container.AddDbContextInMemoryDatabase<DatabaseContext>();
            _unitOfWork = Container.GetService<IUnitOfWork>();
            _lancamentoService = Container.GetService<ILancamentoService>();
        }

        [Fact]
        public void DeveSerInvalidoUmaOperacaoComContaOrigemInvalida()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5E"),
                ContaDestino = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B0"),
                Valor = 1000.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.Equal("Conta origem não existe", resultCommand.Message);
        }

        [Fact]
        public void DeveSerInvalidoUmaOperacaoComContaDestinoInvalida()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                ContaDestino = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B1"),
                Valor = 1000.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.Equal("Conta destino não existe", resultCommand.Message);
        }

        [Fact]
        public void DeveSerInvalidoUmaOperacaoComContaOrigemIgualADestino()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                ContaDestino = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                Valor = 1000.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.Equal("Conta origem e destino devem ser diferentes para realizar esta operação", resultCommand.Message);
        }

        [Fact]
        public void DeveSerInvalidoUmaOperacaoComValorZerado()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                ContaDestino = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B0"),
                Valor = 0.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.Equal("O valor da operação deve ser maior que zero", resultCommand.Message);
        }

        [Fact]
        public void DeveSerInvalidoUmaOperacaoComValorMaiorQueOSaldoDisponivel()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                ContaDestino = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B0"),
                Valor = 10000.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.Equal("O saldo em conta não é o suficiente para realizar a operação", resultCommand.Message);
        }

        [Fact]
        public void DeveSerValidoUmaOperacaoComOsDadosValidos()
        {
            var operacao = new Operacao
            {
                ContaOrigem = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"),
                ContaDestino = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B0"),
                Valor = 1000.00
            };

            var resultCommand = _lancamentoService.Lancar(operacao);

            Assert.True(resultCommand.Success);
        }
    }
}