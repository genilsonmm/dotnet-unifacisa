using System;
using System.Collections.Generic;
using SupplyControl.exceptions;
using SupplyControl.interfaces;
using SupplyControl.model.equipment;
using SupplyControl.model.supply;

namespace SupplyControl
{
    class Program
    {
        private static List<Refrigerator> equipments;
        static void Main(string[] args)
        {
            equipments = new List<Refrigerator>();
            CreateEquipments();

            int option = 0;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                
                if(option == 0) break;

                DoAction(option);
                Console.ReadLine();
                
            }while(true);
        }
        
        static void DoAction(int option)
        {
            Console.Clear();
            switch(option)
            {
                case 1:
                {
                    CheckIn();
                }
                break;
                case 2:
                {
                    CheckOut();
                }
                break;    
                case 3:
                {
                    ShowAllEquipments();
                }   
                break;
                case 4:
                {
                    ShowSuppliesByEquipment();
                }   
                break;                
            }

            Console.WriteLine("Enter para voltar");
        }
        
        static void CreateEquipments()
        {
            Refrigerator refrigeratorToSolderPaste = new Refrigerator(typeof(SolderPaste), 1);          
            Refrigerator refrigeratorToGlue = new Refrigerator(typeof(Glue), 2);

            equipments.Add(refrigeratorToSolderPaste);
            equipments.Add(refrigeratorToGlue);
        }

        static void CheckIn()
        {
            try
            {
                Console.Write("Digite o tipo de insumo (P - para pasta de solda e C - para cola): ");
                string supplyType = Console.ReadLine().ToUpper();

                Console.Write("Digite o código do novo insumo: ");
                string supplyCode = Console.ReadLine();

                ISupply supply = null;
                if(supplyType.Equals("P"))
                    supply = new SolderPaste(supplyCode);
                else
                    supply = new Glue(supplyCode); 

                Console.Write("Digite o código do refrigerador: ");
                int refrigeradorId = int.Parse(Console.ReadLine());

                Refrigerator refrigerator = equipments.Find(r=>r.Id == refrigeradorId);
                refrigerator.CheckIn(supply);

                Console.WriteLine("Check-in realizado com sucesso!");
            }
            catch(CheckInException error)
            {
                Console.WriteLine(error.Message);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao realizar Check-in do insumo");
            }
        }

        static void CheckOut()
        {
            try
            {
                Console.Write("Digite o código do novo insumo: ");
                string supplyCode = Console.ReadLine();

                Console.Write("Digite o código do refrigerador: ");
                int refrigeradorId = int.Parse(Console.ReadLine());

                Refrigerator refrigerator = equipments.Find(r=>r.Id == refrigeradorId);
                refrigerator.CheckOut(supplyCode);

                Console.WriteLine("Check-out realizado com sucesso!");
            }
            catch(CheckOutException error)
            {
                Console.WriteLine(error.Message);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao realizar Check-out do insumo");
            }
        }

        static void ShowAllEquipments()
        {
            foreach(var equipment in equipments)
            {
                Console.WriteLine($"Refrigerador: {equipment.Id} Tipo: {equipment.RefrigeratorType.Name}");
            }
        }

        static void ShowSuppliesByEquipment()
        {
            Console.Write("Digite o código do refrigerador: ");
            int refrigeradorId = int.Parse(Console.ReadLine());

            Refrigerator refrigerator = equipments.Find(r=>r.Id == refrigeradorId);
            foreach(var supply in refrigerator.GetAllSupplies())
            {
                Console.WriteLine($"Código do insumo: {supply.GetCode()}");
            }
        }
        
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("###### Gerenciamento de consumo de insumos ######");
            Console.Write("");

            Console.WriteLine("1 - Realizar Check-in");
            Console.WriteLine("2 - Realizar Check-out");
            Console.WriteLine("3 - Visualizar equipamentos");
            Console.WriteLine("4 - Visualizar insumos");
            Console.WriteLine("0 - Sair");

            Console.Write("Digite uma opção: ");
        }
    }
}