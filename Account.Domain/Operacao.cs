using System;

namespace Account.Domain
{
    public class Operacao
    {
        public Guid ContaOrigem { get; set; }
        public Guid ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}