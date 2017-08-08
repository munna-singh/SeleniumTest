using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.common
{
    public class WebDriverCommonLib
    {
        public void presenceOfElement(IWebDriver driver, String locator)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            Thread.Sleep(2000);
        }
        public void presenceOfElementUsingId(IWebDriver driver, String locator)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            Thread.Sleep(2000);
        }
        public void waitForPageToLoad()
        {
            //

           

            Browser.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));
            Thread.Sleep(3000);
        }
        public void waitForPageLoadTimeOut()
        {
            Browser.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(300));
            Thread.Sleep(3000);
        }
        public void waitForScriptTimeOut()
        {
            Browser.driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(300));
            Thread.Sleep(3000);
        }

        //ExplicitlyWait
        public void waitForXpathPresent(string wbXpath)
        {
            WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromMinutes(1));

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Console.WriteLine(Web.FindElement(By.XPath(wbXpath)));
                return true;
            });
            wait.Until(waitForElement);
            Thread.Sleep(3000);
        }
        //Text assertion
        public Boolean verifyTest(IWebElement wb, String expectedMsg)
        {
            Boolean flag = false;
            String actMsg = wb.Text;
            if (expectedMsg.Equals(actMsg))
            {
                flag = true;
                Console.WriteLine("msg is verfied==PASS");
            }
            else
            {
                Console.WriteLine("msg is not verfied==FAIL");
            }
            return flag;
        }
        //Handling Alert
        public void acceptAlert()
        {
            IAlert alt = Browser.driver.SwitchTo().Alert();
            alt.Accept();
        }


        public void cancelAlert()
        {
            IAlert alt = Browser.driver.SwitchTo().Alert();
            alt.Dismiss();
        }

        //Select value from dropdown

        public void selectFromDropdown(IWebElement wb, String elementTobeClicked)
        {
            SelectElement s = new SelectElement(wb);
            s.SelectByValue(elementTobeClicked);
        }
        //working with calander
        public void calanderPopup(String date, IWebElement wb)
        {

            wb.Click();
            Thread.Sleep(1000);
            wb.SendKeys(date);
            Thread.Sleep(1000);
            wb.SendKeys(Keys.Enter);
            Thread.Sleep(1000);


        }

    }
}
