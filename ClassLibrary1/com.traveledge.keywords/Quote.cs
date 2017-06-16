using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
   public class Quote : WebDriverCommonLib
    {

        public Quote()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@title='Quote' and text()='Quote']")]
        private IWebElement quote { get; set; }

        public void quoteIt(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//button[@title='Quote' and text()='Quote']");
            quote.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Quote is done");
        }
    }
}
