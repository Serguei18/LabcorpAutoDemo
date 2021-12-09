using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAuto
{
    public class TestBase
    {
        public IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.GoToSite("https://www.labcorp.com/");
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }

        private HomePage homePage;
        private CareersPage careersPage;

        public HomePage HomePage() { return homePage ?? new HomePage(webDriver); }
        public CareersPage CareersPage() { return careersPage ?? new CareersPage(webDriver); }

    }
}
