using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCompounds.Driver;
using SeleniumCompounds.Driver.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SeleniumCompounds.MsTest.Attributes
{
    public class WebDriverDataSourceAttribute : Attribute, ITestDataSource
    {
        protected readonly BrowserType[] browserTypes;
        protected readonly SeleniumDriverFactory driverfactory;

        public WebDriverDataSourceAttribute(params BrowserType[] browserTypes)
        {
            this.browserTypes = browserTypes;
            this.driverfactory = new SeleniumDriverFactory();
        }

        public virtual IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (BrowserType browserType in browserTypes)
            {
                yield return new object[] { browserType, driverfactory.BuildDriver(browserType) };
            }
        }

        public virtual string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return $"{methodInfo.Name}_{data[0].ToString()}";
        }
    }
}
