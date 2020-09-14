using System;

namespace Account.Domain
{
    public class ContaCorrente : BaseDomain
    {
        public Guid ContaCorrenteId { get; set; }
        public double Saldo { get; set; }
    }
}