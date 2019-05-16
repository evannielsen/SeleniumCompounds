using NUnit.Framework;
using SeleniumCompounds.Driver;
using SeleniumCompounds.NUnitTest.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.NUnitTest.Attributes
{
    public class SeleniumDriverTestCaseSourceAttribute : TestCaseSourceAttribute
    {
        /// <summary>
        /// Provides the test with a set of browser to run against.
        /// </summary>
        /// <param name="browserTypes"></param>
        public SeleniumDriverTestCaseSourceAttribute(params BrowserType[] browserTypes) : base(typeof(SeleniumDriverTestCaseFactory), nameof(SeleniumDriverTestCaseFactory.BuildDrivers), new object[] { browserTypes })
        {
        }
    }
}
