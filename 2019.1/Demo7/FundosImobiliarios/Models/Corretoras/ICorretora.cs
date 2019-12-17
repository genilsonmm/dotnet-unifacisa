namespace FundosImobiliarios.Models.Corretoras
{
    public interface ICorretora
    {
        void Operacao(Ordem ordem);

        Ordem ObterOrdem();
    }
}
