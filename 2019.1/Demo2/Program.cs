using System;
using Aula2.interfaces;
using Aula2.model;

namespace Aula2
{
    class Program
    {
        static void Main(string[] args)
        { 
            RestMachine restMachine = new RestMachine();
            
            int option = 0;
            do
            {
                Console.Clear();
                PrintLn("########- Aula 2 (Demo 2) -########");
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                if(option == 9) break;

                switch(option)
                {
                    case 1:
                    {
                        Print("Digite a temperatura do Tubo de Cola: ");
                        double temperature = double.Parse(Console.ReadLine());
                        DoCheckIn(new Glue(restMachine.GetNextCode(), temperature), restMachine);
                    }
                    break;
                   case 2:
                    {
                        Print("Digite o código do Tubo de Cola: ");
                        int code = int.Parse(Console.ReadLine());
                        DoCheckOut(code, restMachine);
                    }
                    break;
                    case 3:
                    {
                        Print("Digite a temperatura do Tubo de Pasta de Solda: ");
                        double temperature = double.Parse(Console.ReadLine());
                        DoCheckIn(new SolderPast(restMachine.GetNextCode(), temperature), restMachine);
                    }
                    break;
                    case 4:
                    {
                        Print("Digite o código do Tubo de Pasta de Solda: ");
                        int code = int.Parse(Console.ReadLine());
                        DoCheckOut(code, restMachine);
                    }
                    break;
                }
                
                PrintLn("");
                PrintLn("--Itens na máquina de descanso--");
                restMachine.ShowAll();
                PrintLn("----------------------");

                Print("Enter para Voltar");
                Console.ReadKey();

            }while(true);
        }

        //Entrada de insumo na máquina de descanso
        static void DoCheckIn(ISupply supply, RestMachine refrigerator)
        {                  
            try
            {
                refrigerator.CheckIn(supply);
            }
            catch(Exception error)
            {
                PrintLn($"Erro: {error.Message.ToString()}");
            }
        }

        //Saída do insumo da máquina de descanso
        static void DoCheckOut(int code, RestMachine refrigerator)
        {
            try
            {
                refrigerator.CheckOut(code);
            }
            catch(Exception error)
            {
                PrintLn($"Erro: {error.Message.ToString()}");
            }
        }

        static void ShowMenu()
        {
            PrintLn("1 - Realizar CheckIn do tubo de Cola");
            PrintLn("2 - Realizar CheckOut do tubo de Cola");
            PrintLn("3 - Realizar CheckIn do tubo de Pasta de Solda");
            PrintLn("4 - Realizar CheckOut do tubo de Pasta de Solda");
            PrintLn("9 - Para sair");
            Print("Digite sua opção: ");
        }

        static void Print(string message)
        {
            Console.Write(message);
        }
        static void PrintLn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
