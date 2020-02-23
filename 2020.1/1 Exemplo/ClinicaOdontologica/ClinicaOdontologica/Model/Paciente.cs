using System.Collections.Generic;
using System.Linq;

namespace ClinicaOdontologica.Model
{
    public class Paciente
    {
        public string CPF { get; }
        public string Nome { get; }
        private List<int> procedimentos;

        public Paciente(string cpf, string nome)
        {
            this.CPF = cpf;
            this.Nome = nome;
            procedimentos = new List<int>();
        }

        public void AdicionaProcedimento(int procedimento)
        {
            this.procedimentos.Add(procedimento);
        }

        public List<Procedimento> ProcedimentosExecutados()
        {
            List<Procedimento> procedimentosExecutados = new List<Procedimento>();
            foreach (var id in procedimentos)
            {
                Procedimento procedimento = Clinica.procedimentos.Where(p => p.Id == id).FirstOrDefault();
                if (procedimento != null) procedimentosExecutados.Add(procedimento);
            }

            return procedimentosExecutados;
        }

        public override string ToString()
        {
            return $"CPF: {this.CPF} Nome: {this.Nome}";
        }
    }
}
