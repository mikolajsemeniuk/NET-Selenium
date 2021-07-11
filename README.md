# NET-Selenium
* Create project
* Add packages
* Initial run
* Getting elements
* Operation on elements
* Execute js

### Create project
in `terminal`
```sh
# create
dotnet new console -o selenium
# run
dotnet run
```
### Add packages
in `terminal`
```sh
dotnet add package Selenium.WebDriver -v 3.141.0 &&
dotnet add package Selenium.Support -v 3.141.0 &&
dotnet add package Selenium.WebDriver.GeckoDriver -v 0.29.1
```
### Initial run
in `Program.cs`
```cs
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace sel
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            IWebElement loginInput = driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));

            if (loginInput.Displayed && passwordInput.Displayed)
                OkMessage("I could see it");
            else 
                ErrorMessage("I could not find it");

            Thread.Sleep(3000);

            driver.Quit();
        }
        private static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.White;
        }
        private static void OkMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
```
### Getting elements
in `Program.cs`
```cs
static void Main(string[] args)
{
    // ...
    IWebElement byId = driver.FindElement(By.Id("By-Id"));
    IWebElement byName = driver.FindElement(By.Name("By-Name"));
    IWebElement byXPath = driver.FindElement(By.XPath("By-XPath"));
    IWebElement byCss = driver.FindElement(By.CssSelector("By-CssSelector"));
    IWebElement byClassName = driver.FindElement(By.ClassName("By-ClassName"));
}
// ...
```
### Operation on elements
in `Program.cs`
```cs
static void Main(string[] args)
{
    // ...
    
    // Inputs
    var input = driver.FindElement(By.Id("some-id"));
    element.SendKeys("example text"); // put text
    var text = element.Text; // get value from input
    var isCheckedBoxChecked = element.GetAttribute("checked") == true; // get attribute
    var value = element.GetAttribute("value"); // get value
    element.Clear(); // clear input
    
    // Alerts
    IAlert alert = driver.SwitchTo().Alert();
    var text = alert.text
    alert.Accept();
    
    // ...
}
```
### Execute js
in `Program.cs`
```cs
static void Main(string[] args)
{
    // ...
    IWebElement content = driver.FindElement(By.Id("some-id"));
    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
    string script = "arguments[0].style[\"color\"]=\"red\"";
    executor.ExecuteScript(script, content);
    // ... 
```
