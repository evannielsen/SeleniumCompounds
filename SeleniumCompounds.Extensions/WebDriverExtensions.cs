using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumCompounds.Configuration;
using SeleniumCompounds.Configuration.Models;
using SeleniumCompounds.Extensions.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumCompounds.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IWebDriver"/>.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Takes a screenshot of the current state of the driver
        /// and saves the image to the provided location
        /// </summary>
        /// <param name="webDriver">The driver to take the snapshot.</param>
        /// <param name="fileInfo">The path to save the file.</param>
        /// <returns></returns>
        public static IWebDriver TakeAndSaveScreenshot(this IWebDriver webDriver, FileInfo fileInfo)
        {
            Screenshot snip = webDriver.TakeScreenshot();
            snip.SaveAsFile(fileInfo.FullName);

            return webDriver;
        }

        /// <summary>
        /// Finds an element whos attribute is prefixed with the provided text.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="elementName"></param>
        /// <param name="attributeName"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static IWebElement FindElementByAttributePrefix(this IWebDriver webDriver, string elementName, string attributeName, string prefix)
        {
            return webDriver.FindElementWithWait((drv) => drv.FindElement(By.CssSelector(CssSelectorFactory.AttributeValuePrefixSelector(elementName, attributeName, prefix))));
        }

        /// <summary>
        /// Finds an element whos attribute contains the provided text.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="elementName"></param>
        /// <param name="attributeName"></param>
        /// <param name="containsText"></param>
        /// <returns></returns>
        public static IWebElement FindElementByAttributeContains(this IWebDriver webDriver, string elementName, string attributeName, string containsText)
        {
            return webDriver.FindElementWithWait((driver) => driver.FindElement(By.CssSelector(CssSelectorFactory.AttributeValueContainsSelector(elementName, attributeName, containsText))));
        }

        /// <summary>
        /// Finds an element based on the provided function.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="findFunction"></param>
        /// <returns></returns>
        public static IWebElement FindElementWithWait(this IWebDriver webDriver, Func<IWebDriver, IWebElement> findFunction)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigurationManager.Current.ElementLoadWaitTimeInSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(findFunction);
        }

        /// <summary>
        /// Finds an element by its text node.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IWebElement FindElementByText(this IWebDriver webDriver, string text)
        {
            return webDriver.FindElementWithWait((driver) => driver.FindElement(By.XPath(XPathSelectorFactory.ContainsText(text))));
        }

        /// <summary>
        /// Finds an input element with the specified placeholder text.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IWebElement FindInputByPlaceholderText(this IWebDriver webDriver, string text)
        {
            return webDriver.FindElementByPlaceholderText("input", text);
        }

        /// <summary>
        /// Finds an element with the specified placeholder text.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="elementName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IWebElement FindElementByPlaceholderText(this IWebDriver webDriver, string elementName, string text)
        {
            return webDriver.FindElementByAttributeValue(elementName, "placeholder", text);
        }

        /// <summary>
        /// Finds an element by css class.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="elementName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static IWebElement FindElementByClass(this IWebDriver webDriver, string elementName, string className)
        {
            return webDriver.FindElementByAttributeContains(elementName, "class", className);
        }

        /// <summary>
        /// Sets the value of an elements attribute.
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="webDriver"></param>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IWebElement SetAttributeValue(this IWebElement webElement, IWebDriver webDriver, string attributeName, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript($"document.getElementById('{webElement.GetAttribute("id")}').setAttribute('{attributeName}','{value}')");

            return webElement;
        }

        /// <summary>
        /// Finds an element based on an attributes value.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="elementName"></param>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IWebElement FindElementByAttributeValue(this IWebDriver webDriver, string elementName, string attributeName, string value)
        {
            return webDriver.FindElementWithWait((drv) => drv.FindElement(By.CssSelector(CssSelectorFactory.AttributeValueSelector(elementName, attributeName, value))));
        }

        /// <summary>
        /// Puts the browser into full screen mode.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <returns></returns>
        public static IWebDriver MakeFullScreen(this IWebDriver webDriver)
        {
            webDriver.Manage().Window.FullScreen();

            return webDriver;
        }

        /// <summary>
        /// Closes the browser window.
        /// </summary>
        /// <param name="webDriver"></param>
        public static void Exit(this IWebDriver webDriver)
        {
            webDriver.Close();
        }
    }
}
