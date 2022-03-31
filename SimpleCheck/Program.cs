using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SimpleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = ChangeCase("PointId");
            var data = DateTime.Now.ToString("O");
            var data2 = DateTime.Now.ToString("o");


            List<string> emaiList = new List<string>();
            emaiList.Add("Santhosh <santhosh@gmail.com>");
            emaiList.Add("Santhosh<#santhosh@gmail.com>");
            emaiList.Add("<santhosh@gmail.com>");
            emaiList.Add("@gmail");

            List<string> whiteList = new List<string>();
            whiteList.Add("*");

            MailHelper mailHelper = new MailHelper();

            foreach (var email in emaiList)
            {
                //var emailAddress = ConvertToMailAddress(email);
                Console.WriteLine($"{email} IsValid:{mailHelper.WhiteListContainsExactOrWildcardedEmail(email, whiteList)}");
            }


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

        public static string ChangeCase(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                //Todo need to change
                str = Regex.Replace(str, @"[^A-Za-z0-9 ]+", "");

                var tInfo = new CultureInfo("en-US", false).TextInfo;
                //this line applying title case to string.
                str = tInfo.ToTitleCase(str);

                return str?.Replace(" ", "");
            }

            return str;
        }

        public static MailAddress ConvertToMailAddress(string email)
        {
            MailAddress mailAddress = null;
            try
            {
                mailAddress = new MailAddress(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return mailAddress;
        }

        private static string GetDataPointValueAsString(object dpValue)
        {
            if (dpValue is DateTime dtValue)
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
