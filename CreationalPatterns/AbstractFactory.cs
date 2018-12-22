namespace CreationalPatterns
{
    public interface IProduct
    {
        string GetName();
        string SetPrice(double price);
    }

    public interface IFactory1
    {
        IPeople GetPeople();
    }

    public interface IFactory2
    {
        IProduct GetProduct();
    }

    public abstract class AbstractFactory
    {
        public abstract IFactory1 GetFactory1();
        public abstract IFactory2 GetFactory2();
    }

    public class ConcreteFactory : AbstractFactory
    {
        public override IFactory1 GetFactory1()
        {
            return new Factory1();
        }

        public override IFactory2 GetFactory2()
        {
            return new Factory2();
        }
    }

    internal class Factory2 : IFactory2
    {
        public IProduct GetProduct()
        {
            return new IPhone();
        }
    }

    internal class IPhone : IProduct
    {
        private double _price;

        public string GetName()
        {
            return "Apple TouchPad";
        }

        public string SetPrice(double price)
        {
            this._price = price;
            return "success";
        }
    }

    internal class Factory1 : IFactory1
    {
        public IPeople GetPeople()
        {
            return new Villager();
        }
    }
}
