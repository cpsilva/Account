using Account.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.DataAccess.Database.Configuration
{
    class LancamentoEntityTypeConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ContaCorrenteId).IsRequired();
            builder.Property(x => x.LancamentoId).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
        }
    }
}