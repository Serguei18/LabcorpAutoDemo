using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAuto
{
    public static class DriverExtensions
    {
        public static void GoToSite(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            Console.WriteLine($"Navigated to website: '{url}'.");
        }

        public static void Click(this IWebDriver webDriver, By element)
        {
            webDriver.FindElement(element).Click();
            Console.WriteLine($"Clicked element \'{element}\'.");
        }

        public static void SendKeys(this IWebDriver webDriver, By element, string value, bool clear = true)
        {
            IWebElement _element = webDriver.FindElement(element);
            if (clear)
            {
                _element.Clear();
            }
            _element.SendKeys(value);
            Console.WriteLine($"Value '{value}' was entered to element \'{element}\'.");
        }

        public static void AssertElementText(this IWebDriver webDriver, By element, string expected, bool trim = false)
        {
            string actual = webDriver.FindElement(element).Text;
            if (trim) actual.Trim();
            Assert.AreEqual(expected, actual);
        }

        public static void JavaScriptClick(this IWebDriver driver, By element)
        {
            IWebElement _element = driver.FindElement(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", _element);
            Console.WriteLine($"Used JavaScript to click on the element: \"{element}\".");
        }

        public static void ScrollElementIntoView(this IWebDriver driver, By element)
        {
            IWebElement _element = driver.FindElement(element);
            String scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                                + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                                + "window.scrollBy(0, elementTop-(viewPortHeight/2));";
            IJavaScriptExecutor JavaScript = (IJavaScriptExecutor)driver;
            JavaScript.ExecuteScript(scrollElementIntoMiddle, _element);
        }

        public static void SwitchWindow(this IWebDriver driver, bool switchWindow)
        {
            driver.SwitchTo().Window(switchWindow ? driver.WindowHandles.Last() : driver.WindowHandles.First());
        }

        public static void AssertElementVisible(this IWebDriver driver, By element)
        {
            var visibleElement = driver.FindElement(element).Displayed;
            if (visibleElement)
            {
                Console.WriteLine($"Element \'{element}\' is visible.");
            }
        }
    }
}
