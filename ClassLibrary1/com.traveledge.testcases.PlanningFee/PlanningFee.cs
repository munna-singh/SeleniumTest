using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using ClassLibrary1.com.traveledge.keywords;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.testcases.PlanningFee
{
    [TestFixture]
    class PlanningFee : ExtentReport
    {

        IWebDriver driver;
        WebDriverCommonLib wLib;
        Login loginPage;
        InvoiceTool invoiceTool;
        AddTravelers addTravelers;
        PlanningFeeFillDetails planningFeeFillDetails;
        TSP tsp;
        Payment payment;
        Logout logout;
        ExcelLib eLib = new ExcelLib();


        [SetUp]
        public void configureBeforeClass()
        {
            driver = Browser.getBrowser("Chrome");
            loginPage = new Login();
            invoiceTool = new InvoiceTool();
            addTravelers = new AddTravelers();
            planningFeeFillDetails = new PlanningFeeFillDetails();
            tsp = new TSP();
            payment = new Payment();
            logout = new Logout();
        }

        public void navigateToApplication(String url, ExtentTest test)
        {

            loginPage.navigateToApp(url);
            test.Log(Status.Info, "Navigate to application");

        }

        public void login(String userName, String password, ExtentTest test)
        {

            Thread.Sleep(10000);
            loginPage.loginToAPP(userName, password);
            Thread.Sleep(10000);
            test.Log(Status.Info, "logined toApplication");

        }

        /// <summary>
        /// Book Oneway trip with DJ
        /// </summary>
        [Test]
        public void bookPlanningFee()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);
            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");
            login(userName, passWord, test);
            Actions act = new Actions(driver);
            invoiceTool.searchPlanningFee("1313", test);
            addTravelers.addTravellerPlanningFee("Rob",test);
            planningFeeFillDetails.specifyFeeAmount("USD", "500", test);
            planningFeeFillDetails.specifyTripInformation("Happy journey","07/27/2017","07/28/2017",test);
            planningFeeFillDetails.describeTheService("Happy journey", test);
            tsp.saveTraveler(test);


            //
            String firstNameForPayment = eLib.getExcelData("Payment", "B1");
            String lastNameForPayment = eLib.getExcelData("Payment", "B2");
            String cardNumber = eLib.getExcelData("Payment", "B3");
            String expMonth = eLib.getExcelData("Payment", "B4");
            String expYear = eLib.getExcelData("Payment", "B5");
            String vcc = eLib.getExcelData("Payment", "B6");
            String address = eLib.getExcelData("Payment", "B7");
            String city = eLib.getExcelData("Payment", "B8");
            String country = eLib.getExcelData("Payment", "B9");
            String state = eLib.getExcelData("Payment", "B10");
            String zip = eLib.getExcelData("Payment", "B11");

            payment.makePayment(firstNameForPayment, lastNameForPayment, cardNumber, expMonth, expYear, vcc, address, city, country, state, zip, test);
            tsp.checkPaidStatusPlanningFee(test);

            Thread.Sleep(5000);
            logout.logout(test);

        }
        [TearDown]
        public void flushReport()
        {
           getResult();
        }
    }
}
