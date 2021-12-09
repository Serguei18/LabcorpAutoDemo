using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAuto
{
    public class HomePage
    {
        public IWebDriver webDriver;

        public HomePage(IWebDriver _webdriver)
        {
            webDriver = _webdriver;
        }

        private string careersLink = "//li[not(contains(@role, 'treeitem'))]/child::a[@href='http://www.labcorpcareers.com/'][text()='Careers']";

        public void ClickCareersLink()
        {
            webDriver.ScrollElementIntoView(By.XPath(careersLink));
            webDriver.JavaScriptClick(By.XPath(careersLink));
        }
    }
}
