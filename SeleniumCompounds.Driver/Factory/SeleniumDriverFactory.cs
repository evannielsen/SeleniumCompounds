using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumCompounds.Configuration;
using SeleniumCompounds.Extensions;
using SeleniumCompounds.Configuration.Models;

namespace SeleniumCompounds.Driver.Factory
{
    /// <summary>
    /// Factory class to build a web driver
    /// </summary>
    public class SeleniumDriverFactory
    {
        /// <summary>
        /// Builds a web driver of the specified type.
        /// </summary>
        /// <param name="driverType">The type of browser the driver represents.</param>
        /// <returns></returns>
        public IWebDriver Build(BrowserType driverType, TestSuiteConfiguration testSuiteConfiguration)
        {
            DriverManager driverManager = new DriverManager();

            IWebDriver driver = null;

            switch (driverType)
            {
                case BrowserType.Chrome:
                    driverManager.SetUpDriver(new ChromeConfig());
                    driver =  new ChromeDriver(new ChromeOptions());
                    break;
                case BrowserType.IE:
                    driverManager.SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver(new InternetExplorerOptions());
                    break;
                case BrowserType.Firefox:
                    driverManager.SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(new FirefoxOptions());
                    break;
                case BrowserType.Opera:
                    driverManager.SetUpDriver(new OperaConfig());
                    driver = new OperaDriver(new OperaOptions());
                    break;
                default:
                    break;
            }

            if (driver != null)
            {
                //This waits for the page to load.
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(testSuiteConfiguration.ElementLoadWaitTimeInSeconds);
                if (ConfigurationManager.Current.RunBrowserInFullScreenMode)
                {
                    driver.MakeFullScreen();
                }
            }

            return driver;
        }
    }
}
