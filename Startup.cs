using System.Threading;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace sel
{
    public class Startup
    {
        IWebDriver _driver;

        public Startup() =>
            _driver = new FirefoxDriver();

        public Startup LaunchWebsite() 
        {
            _driver.Navigate().GoToUrl("https://www.x-kom.pl/");
            return this;
        }

        public Startup SearchProducts()
        {
            _driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div[1]/div[3]/div[1]/div/div/div/div[1]/input"))
                .SendKeys("Radeon RX 6700 XT");
            _driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div[1]/div[3]/div[1]/div/div/div/button[3]"))
                .Click();
            return this;
        }

        public Startup Delay(int time)
        {
            Thread.Sleep(time);
            return this;
        }

        public void QuitDriver() =>
            _driver.Close();

        
        private void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void OkMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}