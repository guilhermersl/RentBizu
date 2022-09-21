using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Data.Mapeamento
{
    public class LocadorMapping : IEntityTypeConfiguration<Locador>
    {
        public void Configure(EntityTypeBuilder<Locador> builder)
        {
            builder.ToTable("Locador");
            builder.HasKey(locador => locador.Id);

            builder.Property(locador => locador.Id).ValueGeneratedOnAdd();
            builder.Property(locador => locador.Nome).HasMaxLength(200);
            builder.Property(locador => locador.Cpf).HasMaxLength(11);
            builder.Property(locador => locador.Email).HasMaxLength(100);
            builder.Property(locador => locador.Telefone);

            builder.HasMany(locador => locador.PlanoContas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
