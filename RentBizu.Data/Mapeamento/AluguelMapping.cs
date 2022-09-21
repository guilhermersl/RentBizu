using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentBizu.Domain.AluguelContext;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Data.Mapeamento
{
    public class AluguelMapping : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("Aluguel");
            builder.HasKey(aluguel => aluguel.Id);

            builder.Property(aluguel => aluguel.Id).ValueGeneratedOnAdd();
        }
    }
}
