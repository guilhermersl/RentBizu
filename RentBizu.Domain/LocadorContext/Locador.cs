using RentBizu.CrossCutting.Entity;
using RentBizu.Domain.AluguelContext;

namespace RentBizu.Domain.LocadorContext
{
    public class Locador : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public IList<PlanoConta> PlanoContas { get; set; }

        public Locador() { }

        public Locador(string nome, string cpf, string email, string telefone, IList<PlanoConta> planoContas)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            PlanoContas = planoContas;
        }
    }
}