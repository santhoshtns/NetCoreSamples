using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsProgram
{
    abstract class CommandOutput
    {
        protected static List<string> data;

        protected string PrintChar = "x";

        public void Print()
        {
            if (data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Console.WriteLine(data[i]);
                }
            }
        }
    }
}
