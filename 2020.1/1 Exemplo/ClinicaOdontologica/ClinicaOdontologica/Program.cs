using ClinicaOdontologica.Model;
using System;
using System.Linq;

namespace ClinicaOdontologica
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                ExibirMenu();

                try
                {
                    int opcao = int.Parse(Console.ReadLine());
                    if (opcao == 0) break;

                    ExecutarAcao(opcao);
                    Console.WriteLine("Enter para continuar...");
                    Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Opção inválida. Por favor digite uma opção válida!");
                    Console.WriteLine("Enter para continuar...");
                    Console.ReadLine();
                }
            } while (true);
        }

        private static void ExecutarAcao(int opcao)
        {
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    {
                        //1 - Cadastrar Paciente
                        CadastroDePaciente();
                    }
                    break;
                case 2:
                    {
                        //2 - Cadastrar Procedimentos
                        CadastroDeProcedimento();
                    }
                    break;
                case 3:
                    {
                        //3 - Pesquisar por Paciente
                        PesquisarPorPaciente();
                    }
                    break;
                case 4:
                    {
                        //4 - Atendimento
                        Procedimento();
                    }
                    break;
                default:
                    break;
            }
        }

        private static void Procedimento()
        {
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Paciente paciente = Clinica.pacientes.Where(p => p.CPF.Contains(cpf)).FirstOrDefault();

            if (paciente != null)
            {
                Console.WriteLine(paciente);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Lista de procedimentos:");
                Console.WriteLine("-------------------------------");

                foreach (var procedimento in Clinica.procedimentos)
                {
                    Console.WriteLine(procedimento);
                }
                Console.Write("Digite o código do procedimento: ");
                int idProcedimento = int.Parse(Console.ReadLine());

                paciente.AdicionaProcedimento(idProcedimento);
                Console.WriteLine("Atencimento cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Paciente não encontrado!");
            }
        }

        private static void PesquisarPorPaciente()
        {
            Console.WriteLine("Pesquisar por Paciente");
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Paciente paciente = Clinica.pacientes.Where(p => p.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Console.WriteLine("-------------------------------");

            if (paciente != null)
            {
                Console.WriteLine(paciente);
                foreach (var procedimento in paciente.ProcedimentosExecutados())
                {
                    Console.WriteLine(procedimento);
                }
            }
            else
                Console.WriteLine("Paciente não encontrado!");
        }

        private static void CadastroDeProcedimento()
        {
            Console.WriteLine("Cadastro de Procedimento");
            Console.Write("Digite o nome do procedimento: ");

            string nome = Console.ReadLine();
            int id = Clinica.procedimentos.Count + 1;

            Clinica.procedimentos.Add(new Procedimento(id, nome));
        }

        private static void CadastroDePaciente()
        {
            Console.WriteLine("Cadastro de Paciente");
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Clinica.pacientes.Add(new Paciente(cpf, nome));
        }

        private static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("******* Clínica Odontológica *******");
            Console.Write("");

            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Cadastrar Procedimentos");
            Console.WriteLine("3 - Pesquisar por Paciente");
            Console.WriteLine("4 - Atendimento");
            Console.WriteLine("0 - Sair");

            Console.Write("Digite uma opção: ");
        }
    }
}
