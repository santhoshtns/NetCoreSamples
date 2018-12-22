using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    public interface IBuilder
    {
        string RunBuilderTask1();
        string RunBuilderTask2();
    }

    class Builder1 : IBuilder
    {
        public string RunBuilderTask1()
        {
            throw new ApplicationException("Task1");
        }

        public string RunBuilderTask2()
        {
            throw new ApplicationException("Task2");
        }
    }

    class Builder2 : IBuilder
    {
        public string RunBuilderTask1()
        {
            return "Task3";
        }

        public string RunBuilderTask2()
        {
            return "Task4";
        }
    }

    public class Director
    {
        public IBuilder CreateBuilder(int type)
        {
            IBuilder builder = null;
            switch (type)
            {
                case 1:
                    builder = new Builder1();
                    break;
                case 2:
                    builder = new Builder2();
                    break;
                default:
                    break;
            }
            builder.RunBuilderTask1();
            builder.RunBuilderTask2();
            return builder;
        }
    }
}
