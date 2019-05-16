using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Pages.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IWebDriver"/>
    /// </summary>
    public static class WebDriverPageExtensions
    {
        /// <summary>
        /// Logs in the provided user with their MS account.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IWebDriver LoginWithMicrosoftAccount(this IWebDriver webDriver, string userName, string password)
        {
            MicrosoftLoginPageModel model = new MicrosoftLoginPageModel(webDriver);

            model.Login(userName, password);

            return webDriver;
        }
    }
}
