using SeleniumCompounds.Configuration;
using SeleniumCompounds.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeleniumCompounds.MsTest.Attributes
{
    public class WebDriverWithScopeDataSourceAttribute : WebDriverDataSourceAttribute
    {
        private readonly ConfigurationManager configurationManager;

        public WebDriverWithScopeDataSourceAttribute(params BrowserType[] browserTypes)
            :base(browserTypes)
        {
            this.configurationManager = new ConfigurationManager();
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            IEnumerable<object[]> baseData = base.GetData(methodInfo);

            var configuration = configurationManager.GetTestScope(methodInfo.Name);

            foreach (var data in baseData)
            {
                var dataList = data.ToList();
                dataList.Add(configuration);

                yield return dataList.ToArray();
            }
        }
    }
}
