using SupplyControl.interfaces;

namespace SupplyControl.model.supply
{
    public class Glue : SupplyBase, ISupply
    {
        public Glue(string code) : base(code) 
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}