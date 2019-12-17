using System;
using System.Collections.Generic;
using SupplyControl.exceptions;
using SupplyControl.interfaces;

namespace SupplyControl.model.equipment
{
    public class Refrigerator
    {
        private List<ISupply> supplies;
        public int Id {get;private set;}
        public Type RefrigeratorType {get; private set;} 

        public Refrigerator(Type type, int id)
        {
            this.Id = id;
            this.RefrigeratorType = type;

            supplies = new List<ISupply>();
        }

        public void CheckIn(ISupply supply)
        {
            if(supply.GetType() != RefrigeratorType)
                throw new CheckInException("Tipo de insumo não suportado neste equipamento");

            if(GetSupplyByCode(supply.GetCode()) != null)
                throw new CheckInException($"O insumo {supply.GetCode()} já está no refrigerador");

            supplies.Add(supply);
        }

        public ISupply CheckOut(string code)
        {
            ISupply supply = GetSupplyByCode(code);

            if(supply == null)
                throw new CheckOutException($"Insumo {code} não foi localizado");

            return GetSupplyByCode(code);
        }

        public List<ISupply> GetAllSupplies()
        {
            return supplies;
        }

        private ISupply GetSupplyByCode(string code)
        {
            return this.supplies.Find(s=>s.GetCode().Equals(code));
        }
    }
}