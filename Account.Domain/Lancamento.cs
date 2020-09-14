using System;

namespace Account.Domain
{
    public class Lancamento : BaseDomain
    {
        public int Id { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public double Valor { get; set; }
        public int LancamentoId { get; set; }
    }
}