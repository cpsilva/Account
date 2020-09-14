using Account.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.DataAccess.Database.Configuration
{
    public class ContaCorrenteEntityTypeConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");

            builder.HasKey(x => x.ContaCorrenteId);

            builder.Property(x => x.ContaCorrenteId).IsRequired();
            builder.Property(x => x.Saldo).IsRequired();
        }
    }
}