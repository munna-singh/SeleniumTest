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
    class RepriceBook : WebDriverCommonLib
    {

        public RepriceBook()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and @title='Book']")]
        private IWebElement repriceBook { get; set; }

        public void rePriceBook(ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//button[text()='Book' and @title='Book']");
            repriceBook.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Reprice is done , navigating to add travelers");

        }
    }
}
