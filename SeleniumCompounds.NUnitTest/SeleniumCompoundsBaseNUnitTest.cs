using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumCompounds.Extensions;
using SeleniumCompounds.NUnitTest.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.NUnitTest
{
    /// <summary>
    /// Base class for an NUnit Selenium test.
    /// </summary>
    [TestFixture]
    public abstract class SeleniumCompoundsBaseNUnitTest
    {
        /// <summary>
        /// Standard cleanup when running selenium tests.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            TestContext context = TestContext.CurrentContext;

            foreach (var item in context.Test.Arguments)
            {
                if (item is IWebDriver driver)
                {
                    if (context.Result.Outcome != ResultState.Success)
                    {
                        driver.TakeAndSaveScreenshot(context);
                    }

                    driver.Exit();
                }
            }
        }
    }
}
