using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumCompounds.Extensions;

namespace SeleniumCompounds.SharePoint.Controls
{
    /// <summary>
    /// Control that represents the Date Picker control in SharePoint Modern.
    /// </summary>
    public class DateControl
    {
        private readonly IWebDriver driver;
        private readonly string placeholderText;
        private const string dateFormatString = "MMMMMMMMMMMM d, yyyy";
        private const string yearMonthFormatString = "MMMMMMMMMMMM yyyy";

        private IWebElement currentYearLabel => driver.FindElementByClass("div", "ms-DatePicker-currentYear");
        private IWebElement previousYearButton => driver.FindElementByClass("button", "ms-DatePicker-prevYear");
        private IWebElement nextYearButton => driver.FindElementByClass("button", "ms-DatePicker-nextYear");

        

        public DateControl(IWebDriver driver, string placeholderText)
        {
            this.driver = driver;
            this.placeholderText = placeholderText;
        }

        public void SetDate(DateTime date)
        {
            IWebElement inputBox = driver.FindInputByPlaceholderText(placeholderText);
            inputBox.Click();

            int currentYear = int.Parse(currentYearLabel.Text);
            int yearDifference = date.Year - currentYear;

            if (yearDifference > 0)
            {
                for (int i = 0; i < Math.Abs(yearDifference); i++)
                {
                    nextYearButton.Click();
                }
            }

            if (yearDifference < 0)
            {
                for (int i = 0; i < Math.Abs(yearDifference); i++)
                {
                    previousYearButton.Click();
                }
            }

            IWebElement monthButton = driver.FindElementByAttributeValue("button", "aria-label", date.ToString(yearMonthFormatString));

            monthButton.Click();

            IWebElement dayButton = driver.FindElementByAttributeValue("div", "aria-label",date.ToString(dateFormatString));

            dayButton.Click();

        }
    }
}
