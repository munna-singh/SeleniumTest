
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        public IWebDriver driver;

        [Test]
        public void tc01()
        {
            // System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",@"/path/to/where/you/ve/put/chromedriver.exe")
            driver = new ChromeDriver();

            driver.Url = "http://adx.ci.te.tld/";
        }
        [Test]
        public void tc02()
        {
            driver.FindElement(By.Id("username")).SendKeys("system@kensingtontours.com");
            driver.FindElement(By.Id("password")).SendKeys("Pass1234");
        }
        [Test]
        public void tc03()
        {
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-login']")).Click();

        }
        static void Main()
        {
            // Write to console
            Console.WriteLine("Welcome to the C# Station Tutorial!");
        }

    }
}
