namespace Demo1
{
    public class Customer
    {
        private string Name;
        private int Code;

        public Customer(string name, int code)
        {
            this.Name = name;
            this.Code = code;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetCode()
        {
            return Code;
        }
    }
}
