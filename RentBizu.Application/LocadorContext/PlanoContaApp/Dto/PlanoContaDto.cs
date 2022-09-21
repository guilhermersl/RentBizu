using RentBizu.CrossCutting.Enum;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Dto
{
    public record PlanoContaInputDto(
        string Nome,
        string Imagem,
        EProdutos Produto,
        double Valor,
        DateTime InicioPlano,
        DateTime? FimPlano,
        string LoginPlanoContaPlano,
        string SenhaPlanoContaPlano
    );

    public record PlanoContaOutputDto(
        Guid Id,        
        Guid LocadorId,
        string Nome,
        string Imagem,
        EProdutos Produto,
        double Valor,
        DateTime InicioPlano,
        DateTime? FimPlano,
        string LoginPlanoContaPlano,
        string SenhaPlanoContaPlano,
        EStatusPlanoConta StatusPlanoConta
    );
}
