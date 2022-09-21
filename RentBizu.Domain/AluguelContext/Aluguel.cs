using RentBizu.CrossCutting.Entity;
using RentBizu.Domain.LocadorContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentBizu.Domain.AluguelContext
{
    public class Aluguel : Entity<Guid>
    {
        public DateTime Data { get; set; }

        [ForeignKey("PlanoConta")]
        public Guid PlanoContaId { get; set; }

        [ForeignKey("Locatario")]
        public Guid LocatarioId { get; set; }

    }
}