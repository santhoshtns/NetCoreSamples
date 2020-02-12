using System;
using System.Configuration;
using System.Globalization;

namespace SimpleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataPointValueAsString(null);

            int currentAge = CalculateCurrentAge(new DateTime(1984, 06, 02));

            string benefitXml = "abc";
            string benefitXml2 = benefitXml.Replace("c", "DEF");

            DateFormats();
            var flag = true;
            if (!bool.TryParse(ConfigurationManager.AppSettings["Setting21"],
                out flag))
            {
                flag = true;
            }

            Console.WriteLine(flag);
        }

        private static string GetDataPointValueAsString(object dpValue)
        {
            if(dpValue is DateTime dtValue)
            {
                return dtValue.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (dpValue is decimal dValue)
            {
                return dValue.ToString(CultureInfo.InvariantCulture);
            }

            return dpValue?.ToString();
        }

        private static void DateFormats()
        {
            DateTime dt = new DateTime(1987, 12, 31);
            Console.WriteLine(dt.ToString("d MMM yyyy"));
        }

        private static int CalculateCurrentAge(DateTime birthDate)
        {
            int age = 0;
            age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
