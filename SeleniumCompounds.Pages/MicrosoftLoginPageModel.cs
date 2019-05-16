using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumCompounds.Extensions;

namespace SeleniumCompounds.Pages
{
    /// <summary>
    /// Page Model that represents the Microsoft login page.
    /// </summary>
    public class MicrosoftLoginPageModel : PageModel
    {
        public MicrosoftLoginPageModel(IWebDriver driver) : base(driver, new Uri("https://login.microsoftonline.com"))
        {
        }

        public IWebElement UsernameBox 
            => driver.FindElementByAttributeValue(elementName: "input", attributeName: "name", value: "loginfmt");

        public IWebElement NextButton 
            => driver.FindElementByAttributeValue(elementName: "input", attributeName: "id", value: "idSIButton9");
   
        public IWebElement PasswordBox
            => driver.FindElementByAttributeValue(elementName: "input", attributeName: "id", value: "passwordInput");

        public IWebElement SignInButton
            => driver.FindElementByAttributeValue(elementName: "span", attributeName: "id", value: "submitButton");

        public override void Go()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void Login(string username, string password)
        {
            if (driver.Url != baseUrl.ToString())
            {
                Go();
            }

            UsernameBox
                .SendKeys(username);

            NextButton
                .Click();

            PasswordBox
                .SendKeys(password);

            SignInButton
                .Click();

            NextButton
                .Click();
        }
    }
}
