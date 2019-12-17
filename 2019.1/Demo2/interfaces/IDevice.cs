namespace Aula2.interfaces
{
    public interface IDevice
    {
        void CheckIn(ISupply supply);
        void CheckOut(int code);
    }
}