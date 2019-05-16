using OpenQA.Selenium;
using SeleniumCompounds.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.SharePoint.Controls
{
    /// <summary>
    /// Control that represents the New Item dropdown in SharePoint Modern.
    /// </summary>
    public class NewItemControl
    {
        private readonly IWebDriver driver;

        public ContextualMenu contextMenu { get; }

        private IWebElement NewButton => driver.FindElementByAttributeValue("button", "data-automation-id", "pageCommandBarNewButton");

        public NewItemControl(IWebDriver driver)
        {
            this.driver = driver;
            this.contextMenu = new ContextualMenu(driver);
        }

        /// <summary>
        /// Clicks the option in the context menu represented by the display text passed in.
        /// </summary>
        /// <param name="listItem">The display name of the item in the "New" dropdown</param>
        public void ClickListItem(string listItem)
        {
            NewButton.Click();
            IWebElement listItemElement = driver.FindElementByText(listItem);
            listItemElement.Click();
        }
       
    }
}
