﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SeleniumCompounds.Extensions;

namespace SeleniumCompounds.NUnitTest.Extensions
{
    public static class NUnitWebDriverExtensions
    {
        /// <summary>
        /// Taks a snapshot of the current broswer and saves the image
        /// to the current test directory.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="testContext"></param>
        /// <returns></returns>
        public static IWebDriver TakeAndSaveScreenshot(this IWebDriver webDriver, TestContext testContext)
        {
            string filePath = Path.Combine(testContext.TestDirectory, testContext.Test.ClassName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fileName = $"{DateTime.Now.ToString("d18")}_{testContext.Test.MethodName}.png";

            FileInfo fileInfo = new FileInfo(Path.Combine(filePath, fileName));

            return webDriver.TakeAndSaveScreenshot(fileInfo);
        }
    }
}
