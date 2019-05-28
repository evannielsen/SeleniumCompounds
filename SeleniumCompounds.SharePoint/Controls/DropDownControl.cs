using OpenQA.Selenium;
using SeleniumCompounds.Extensions;
using SeleniumCompounds.SharePoint.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.SharePoint.Controls
{
    public class DropDownControl
    {
        private readonly IWebDriver driver;
        private readonly string placeholderText;

        public DropDownControl(IWebDriver driver, string placeholderText)
        {
            this.driver = driver;
            this.placeholderText = placeholderText;
        }

        public void SelectItem(string itemText)
        {
            IWebElement listSelector = driver.FindElementByText(placeholderText);
            listSelector.Click();

            driver.ClickListBoxItem(itemText);
        }
    }
}
