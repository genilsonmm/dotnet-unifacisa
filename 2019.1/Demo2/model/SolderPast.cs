using System;
using Aula2.interfaces;

namespace Aula2.model
{
    public class SolderPast : Supply, ISupply
    {
        public SolderPast(int code, double temperature)
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