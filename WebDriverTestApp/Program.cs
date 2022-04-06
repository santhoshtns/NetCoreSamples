using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace WebDriverTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new EdgeDriver();

            // Navigate to Bing
            driver.Url = "https://www.bing.com/";
            driver.Navigate();
            // Navigate to Google
            driver.Url = "https://www.google.com/";
            driver.Navigate();

            Thread.Sleep(5000);
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("no-sandbox");
            //WebDriver driver = new ChromeDriver(options);
            //driver.Url = "https://www.google.com/";
            driver.Close();
            driver.Quit();
        }
    }
}
