using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentBizu.CrossCutting.Enum;
using RentBizu.Domain.LocadorContext;

namespace RentBizu.Data.Mapeamento
{
    public class PlanoContaMapping : IEntityTypeConfiguration<PlanoConta>
    {
        public void Configure(EntityTypeBuilder<PlanoConta> builder)
        {
            builder.ToTable("PlanoConta");
            builder.HasKey(planoConta => planoConta.Id);

            builder.Property(planoConta => planoConta.Id).ValueGeneratedOnAdd();
            builder.Property(planoConta => planoConta.Nome).IsRequired().HasMaxLength(200);
            builder.Property(planoConta => planoConta.Produto).HasConversion(v => v.ToString(), v => (EProdutos)Enum.Parse(typeof(EProdutos), v));
            builder.Property(planoConta => planoConta.StatusPlanoConta).HasConversion(v => v.ToString(), v => (EStatusPlanoConta)Enum.Parse(typeof(EStatusPlanoConta), v));

            builder.HasMany(planoConta => planoConta.Alugueis).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
