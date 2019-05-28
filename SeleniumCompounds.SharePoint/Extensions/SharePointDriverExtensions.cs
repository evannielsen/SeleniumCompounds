using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumCompounds.Extensions;

namespace SeleniumCompounds.SharePoint.Extensions
{
    public static class SharePointDriverExtensions
    {
        public static void ClickListBoxItem(this IWebDriver webDriver, string itemText)
        {
            string javascript = $@"document.querySelector('[aria-label=""{itemText}""]').click()";

            webDriver.RunJavascript(javascript);
        }
    }
}
