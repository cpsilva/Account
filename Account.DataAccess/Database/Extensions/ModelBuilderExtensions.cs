using Account.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Account.DataAccess.Database.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaCorrente>().HasData(
                new ContaCorrente { ContaCorrenteId = Guid.Parse("B27F745D-F088-4259-8B84-932F8257AF5D"), Saldo = 9000d },
                new ContaCorrente { ContaCorrenteId = Guid.Parse("B623272E-CD42-47C4-BFD0-B4AC2776E4B0"), Saldo = 4500d }
            );
        }
    }
}