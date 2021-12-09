using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAuto
{
    public class CareersPage
    {
        public IWebDriver webDriver;

        public CareersPage(IWebDriver _webdriver)
        {
            webDriver = _webdriver;
        }

        private string careersSearchField = "//input[contains(@id, 'search-keyword')]";
        private string careesrSearchButton = "//button[contains(@id, 'search-submit')]";
        private string positionLink = "//h2[text()='positionName']/following-sibling::span[@class='job-location'][text()='positionLocation']/following-sibling::span[@class='job-date-posted'][text()='positionPosted']";
        private string titleNameText = "//h1[@class='job-description__heading']";
        private string jobLocationText = "//span[contains(@class, 'job-location')][contains(text(), 'jobLocation')]";
        private string jobIdText = "//span[contains(@class, 'job-id ')][contains(text(), 'jobId')]";

        public void SwitchToCareersWindow()
        {
            webDriver.SwitchWindow(true);
        }

        public void EnterPositionName(string position)
        {
            webDriver.ScrollElementIntoView(By.XPath(careersSearchField));
            webDriver.SendKeys(By.XPath(careersSearchField), position, false);
        }

        public void ClickSearchPosition()
        {
            webDriver.Click(By.XPath(careesrSearchButton));
        }

        public void SelectPosition(string positionName, string positionLocation, string positionPosted)
        {
            string positionFormated = positionLink
                .Replace("positionName", positionName)
                .Replace("positionLocation", positionLocation)
                .Replace("positionPosted", positionPosted);

            webDriver.Click(By.XPath(positionFormated));
        }

        public void AssertTitleName(string titleName)
        {
            webDriver.ScrollElementIntoView(By.XPath(titleNameText));
            webDriver.AssertElementText(By.XPath(titleNameText), titleName);
        }

        public void AssertJobLocation(string jobLocation)
        {
            webDriver.AssertElementVisible(By.XPath(jobLocationText.Replace("jobLocation", jobLocation)));
        }

        public void AssertJobId(string jobId)
        {
            webDriver.AssertElementVisible(By.XPath(jobIdText.Replace("jobId", jobId)));
        }

    }
}
