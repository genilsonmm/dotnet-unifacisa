namespace FundosImobiliarios.Models
{
    public class Ordem
    {
        private string ativo;
        private int quantidade;
        private double valor;
        private TipoOperacao tipoOperacao;

        public Ordem(string ativo, int quantidade, double valor, TipoOperacao tipoOperacao)
        {
            this.ativo = ativo;
            this.quantidade = quantidade;
            this.valor = valor;
            this.tipoOperacao = tipoOperacao;
        }

        public override string ToString()
        {
            return $"Ativo: {ativo}, Quantidade: {quantidade}, Valor: {valor}, Operação: {tipoOperacao.ToString()}";
        }
    }

}
