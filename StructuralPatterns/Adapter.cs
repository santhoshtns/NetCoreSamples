namespace StructuralPatterns
{
    internal interface IAdapter
    {
        void Add();
    }

    public class ToClass
    {
        public void Push()
        {

        }
    }

    public class FromClass : IAdapter
    {
        private ToClass _toClass = new ToClass();

        public void Add()
        {
            _toClass.Push();
        }
    }
}
