namespace FundosImobiliarios.Models.Corretoras
{
    public class CorretoraModalMais : ICorretora
    {
        private Ordem ordem;

        public void Operacao(Ordem ordem)
        {
            //TODO
            //Calcula taxa de corretagem de 10,00 por operação 
            //e debita na conta do cliente
            this.ordem = ordem;
        }

        public Ordem ObterOrdem()
        {
            return ordem;
        }
    }
}
