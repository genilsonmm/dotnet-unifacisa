using System;
using Aula2.interfaces;

namespace Aula2.model
{
    public class Glue : Supply, ISupply
    {
        public Glue(int code, double temperature)
        {
            base.temperature = temperature;
            base.code = code;
        }

        public int GetCode()
        {
            return code;
        }

        public double GetTemperature()
        {
            return temperature;
        }
    }
}