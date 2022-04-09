using OpenQA.Selenium.Edge;
using System.Threading;

namespace WebDriverTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var chromeDriverService = EdgeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var driver = new EdgeDriver(chromeDriverService);
            
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
