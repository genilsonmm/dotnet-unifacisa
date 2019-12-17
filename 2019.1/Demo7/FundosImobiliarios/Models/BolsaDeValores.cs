namespace FundosImobiliarios.Models.Corretoras
{
    public class BolsaDeValores
    {
        protected ICorretora corretora;

        public BolsaDeValores(ICorretora corretora)
        {
            this.corretora = corretora;
        }

        public string ProcessaSolicitacao()
        {
            return $@"B3 -> Corretora: {corretora.GetType().Name},   
                            Ordem: {corretora.ObterOrdem()}";
        }
    }
}
