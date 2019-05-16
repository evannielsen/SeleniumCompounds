using OpenQA.Selenium;
using SeleniumCompounds.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.SharePoint.Controls
{
    /// <summary>
    /// Control that represents a contextual menu in SharePoint Modern.
    /// </summary>
    public class ContextualMenu
    {
        private readonly IWebDriver driver;

        private IWebElement UnorderedList => driver.FindElementByAttributeValue("ul", "class", "ms-ContextualMenu-list");

        public ContextualMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetListItem(string displayText)
        {
            return this.UnorderedList.FindElement(By.LinkText(displayText));
        }
    }
}
