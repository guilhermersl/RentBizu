using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentBizu.Domain.LocatarioContext;

namespace RentBizu.Data.Mapeamento
{
    public class LocatarioMapping : IEntityTypeConfiguration<Locatario>
    {
        public void Configure(EntityTypeBuilder<Locatario> builder)
        {
            builder.ToTable("Locatario");
            builder.HasKey(locador => locador.Id);

            builder.Property(locador => locador.Id).ValueGeneratedOnAdd();
            builder.Property(locador => locador.Nome).HasMaxLength(200);
            builder.Property(locador => locador.Cpf).HasMaxLength(11);
            builder.Property(locador => locador.Email).HasMaxLength(100);
            builder.Property(locador => locador.Telefone);

            builder.HasMany(locador => locador.Alugueis).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
