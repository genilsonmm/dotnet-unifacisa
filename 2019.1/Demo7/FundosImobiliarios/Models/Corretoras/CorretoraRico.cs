namespace FundosImobiliarios.Models.Corretoras
{
    public class CorretoraRico : ICorretora
    {
        private Ordem ordem;

        public void Operacao(Ordem ordem)
        {
            //TODO
            //A corretagem é grátis
            this.ordem = ordem;
        }

        public Ordem ObterOrdem()
        {
            return ordem;
        }
    }
}
