using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class TSP: WebDriverCommonLib
    {

        public TSP()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[text()='Book' and contains(@class,'update-price') ]")]
        private IWebElement itenaryBook { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-primary air-payment']")]
        private IWebElement ticketFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Back to Trip Services']")]
        private IWebElement tsp { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='label-status label-ticketed' and text()='ticketed']")]
        private IWebElement ticketed { get; set; }



        public void ClickOnItenaryBook(ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//a[text()='Book' and contains(@class,'update-price') ]");
            itenaryBook.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Navigating to reprice flow");
        }

        public void ClickOnTicketFlight(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//a[@class='btn btn-primary air-payment']");

            ticketFlight.Click();
            waitForPageToLoad();
            Thread.Sleep(10000);
            test.Log(Status.Info, "Going for ticketing");

        }

        public void backToTsp()
        {
            presenceOfElement(Browser.driver, "//a[text()='Back to Trip Services']");

            tsp.Click();
            waitForPageToLoad();

        }

        public void checkTicketed(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//span[@class='label-status label-ticketed' and text()='ticketed']");
            
            Assert.IsTrue(ticketed.Displayed, "staus is not ticketed");
            if (ticketed.Displayed)
            {
                test.Pass("Flight is ticketed");
                test.Log(Status.Info, "Payment is done / Status is ticketed");
            }
            else
            {
                test.Fail("ticketed failed");
                test.Log(Status.Info, "ticketed failed");

            }

        }
    }
}
