using System;
using System.Collections.Generic;

namespace MyCsProgram
{
    /// <summary>
    /// Command Output Abstract Class.
    /// </summary>
    internal abstract class CommandOutput
    {
        protected static List<string> data;
        protected static string PrintChar = "x";

        /// <summary>
        /// Prints this instance.
        /// </summary>
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
