using SeleniumCompounds.Driver;
using SeleniumCompounds.Driver.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.NUnitTest.Factory
{
    public class SeleniumDriverTestCaseFactory
    {
        /// <summary>
        /// Creates a set of browers based on the input types
        /// for use with a test case.
        /// </summary>
        /// <param name="browserTypes"></param>
        /// <returns></returns>
        public static IEnumerable<object[]> BuildDrivers(params BrowserType[] browserTypes)
        {
            SeleniumDriverFactory driverFactory = new SeleniumDriverFactory();
            foreach (var browserType in browserTypes)
            {
                yield return new object[] { driverFactory.Build(browserType) };
            }
        }
    }
}
