using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCompounds.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IWebElement"/>
    /// </summary>
    public static class ElementExtensions
    {
        /// <summary>
        /// Waits for an element to become visible.
        /// </summary>
        /// <param name="webElement">The element to look for.</param>
        /// <param name="webDriver">The driver to apply the wait.</param>
        /// <returns></returns>
        public static IWebElement WaitToBeVisible(this IWebElement webElement, IWebDriver webDriver)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigurationManager.Current.ElementLoadWaitTimeInSeconds));

            bool becameVisible = 
                wait.Until((drv) => {
                return webElement.Displayed;
            });

            if (!becameVisible)
            {
                throw new Exception($"{webElement.TagName} never became visible");
            }
            
            return webElement;
        }

       
    }
}
