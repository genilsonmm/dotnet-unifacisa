using System;
using System.Collections.Generic;
using Aula2.interfaces;

namespace Aula2.model
{
    public class RestMachine : IDevice
    {
        private List<ISupply> supplies = new List<ISupply>();
        private readonly double minTemperature = 10;

        public void CheckIn(ISupply supply)
        {
            double realTemperature = (supply.GetType().Name == typeof(Glue).Name) ? minTemperature : minTemperature + 10; 

            //Regra de negócio
            if(supply.GetTemperature() >= realTemperature)
            {             
                supplies.Add(supply);
                Console.WriteLine($"Checkin realizado - {this.GetType().Name}");
            }
            else
            {
                throw new Exception($"A temperatura da {supply.GetType().Name} deve ser maior ou igual à {realTemperature}°");
            }
            
        }

        public void CheckOut(int code)
        {
            ISupply supply = supplies.Find(s=>s.GetCode() == code);

            if(supply == null) throw new Exception("Insumo não encontrado!");

            supplies.Remove(supply);
            Console.WriteLine($"CheckOut realizado - {this.GetType().Name}");
        }

        public void ShowAll()
        {
            foreach(ISupply supply in supplies)
            {
                Console.WriteLine($"Insumo {supply.GetType().Name} Código:  {supply.GetCode()}");
            }
        }

        public int GetNextCode()
        {
            return supplies.Count+1;
        }
    }
}