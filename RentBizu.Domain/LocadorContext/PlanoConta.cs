using RentBizu.CrossCutting.Entity;
using RentBizu.CrossCutting.Enum;
using RentBizu.Domain.AluguelContext;

namespace RentBizu.Domain.LocadorContext
{
    public class PlanoConta : Entity<Guid>
    {
        public Guid LocadorId { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public EProdutos Produto { get; set; }
        public double Valor { get; set; }
        public DateTime DataOferta { get; set; } = DateTime.Now;
        public DateTime InicioPlano { get; set; }
        public DateTime? FimPlano { get; set; }
        public string LoginPlanoContaPlano { get; set; }
        public string SenhaPlanoContaPlano { get; set; }
        public EStatusPlanoConta StatusPlanoConta { get; set; }
        public IList<Aluguel> Alugueis { get; set; }
    }
}