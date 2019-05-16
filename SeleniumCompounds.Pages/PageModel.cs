using OpenQA.Selenium;
using SeleniumCompounds.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Pages
{
    /// <summary>
    /// Base class representing a web page.
    /// </summary>
    public abstract class PageModel
    {
        protected readonly IWebDriver driver;
        protected readonly Uri baseUrl;
        
        public PageModel(IWebDriver driver, Uri baseUrl)
        {
            this.driver = driver;
            this.baseUrl = baseUrl;
        }

        protected Uri RelativeUri { get; set; }
        
        public virtual void Go()
        {
            Uri completeUrl = baseUrl.Combine(RelativeUri);
            driver.Navigate().GoToUrl(completeUrl);
        }
    }
}
