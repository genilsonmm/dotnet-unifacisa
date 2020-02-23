namespace ClinicaOdontologica.Model
{
    public class Procedimento
    {
        public int Id { get; }
        public string Nome { get; }
        public Procedimento(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override string ToString()
        {
            return $"Código: {this.Id} Procedimento: {this.Nome}";
        }
    }
}
