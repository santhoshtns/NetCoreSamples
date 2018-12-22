namespace CreationalPatterns
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
