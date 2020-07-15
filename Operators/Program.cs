using System;

namespace Operators
{
    class Program
    {
        [Flags]
        public enum BaseState
        {
            None = 0,
            Inactive = 1 << 0, //1
            Deleted = 1 << 1, //2
            ReadOnly = 1 << 2, //4
            Locked = 1 << 3, //8
            Draft = 1 << 4 //16
        }

        static void Main(string[] args)
        {
            Guid? testGuid = null;

            Console.WriteLine(testGuid.Value.ToString());


            Console.WriteLine("Hello World!");

            BaseState? baseState = null;

            //baseState = baseState | BaseState.Deleted ?? BaseState.Deleted;

            BaseState? excludeStates = baseState | BaseState.Deleted ?? BaseState.Deleted;
            excludeStates ??= BaseState.None;

        }
    }
}
