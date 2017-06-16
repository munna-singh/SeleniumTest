﻿using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
  public class AddTravelers : WebDriverCommonLib
    {

        public AddTravelers()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.Id, Using = "clientSearch")]
        private IWebElement addTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-select-client']")]
        private IWebElement selectTraveler { get; set; }

        [FindsBy(How = How.Id, Using = "view21_traveling")]
        private IWebElement isTravelling { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Close']")]
        private IWebElement closeExp { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='Title']")]
        private IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='FirstName']")]
        private IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='LastName']")]
        private IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='day form-control de-form-control'])[1]")]
        private IWebElement date { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='month form-control de-form-control'])[1]")]
        private IWebElement month { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='year form-control de-form-control'])[1]")]
        private IWebElement year { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class='de-label']/input[@value='M']")]
        private IWebElement male { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='Nationality']")]
        private IWebElement nationality { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book Only']")]
        private IWebElement bookOnly { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/div")]
        private IWebElement clientSearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/button")]
        private IWebElement cancelAddTravelerPopUp { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='mainContent']/div[2]/div/div/div[2]/div[1]/div/div/div/div/div/form/div[3]/button")]
        private IWebElement searchClient { get; set; }
        

        public void addTravelers(Actions act,String travellerName, String Title, String firstname, String lastname, String dT, String mN, String yR, String nationaliTy,ExtentTest test)
        {

            Thread.Sleep(5000);
            addTraveler.SendKeys(travellerName);
            Thread.Sleep(5000);
            searchClient.Click();
           // act.SendKeys(Keys.Enter).Perform();
            selectTraveler.Click();
           

            //cancelAddTravelerPopUp.Click();

            //while (clientSearchResult.Displayed==true)
            //    {
            //        if (clientSearchResult.Displayed || clientSearchResult.Enabled)
            //        {
            //        cancelAddTravelerPopUp.Click();
            //        }
            //        else
            //        {
            //        break;
            //        }
            //    }
            
          
            Thread.Sleep(5000);
            selectFromDropdown(title, Title);
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            selectFromDropdown(date, dT);
            selectFromDropdown(month, mN);
            selectFromDropdown(year, yR);
            selectFromDropdown(nationality, nationaliTy);
            act.MoveToElement(bookOnly).Click().Build().Perform();

            Thread.Sleep(5000);
            test.Log(Status.Info, "Traveler Name is added ,Going for Verification");
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='traveler-verified']")]
        private IWebElement verified { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        private IWebElement Continue { get; set; }

        public void verifyTravelersLegalNames(ExtentTest test)
        {

            Thread.Sleep(10000);
		    verified.Click();
		    Continue.Click();
            test.Log(Status.Info, "traveler name verified");
            test.Log(Status.Info, "Booking is done");

        }
}
}