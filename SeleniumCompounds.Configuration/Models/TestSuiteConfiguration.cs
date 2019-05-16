using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumCompounds.Configuration.Models
{
    /// <summary>
    /// Root class for configuring a test suite
    /// </summary>
    public class TestSuiteConfiguration
    {
        /// <summary>
        /// The implied amount of time that a browser will wait for activities i.e. page load.
        /// </summary>
        public int DriverImplicitWaitTimeInSeconds { get; set; }

        /// <summary>
        /// The maximum amount of time to wait when searching for a visible element.
        /// </summary>
        public int ElementLoadWaitTimeInSeconds { get; set; }

        /// <summary>
        /// Instruct the browser to be in full screen mode.
        /// </summary>
        public bool RunBrowserInFullScreenMode { get; set; }

        /// <summary>
        /// List of identities to be used for any authentication purpose
        /// </summary>
        public IEnumerable<TestSuiteIdentity> Identities { get; set; }

        /// <summary>
        /// Gets an identity based on its key.
        /// </summary>
        /// <param name="key">The key of the identity.</param>
        /// <returns></returns>
        public TestSuiteIdentity GetIdentityByKey(string key)
        {
            return Identities.FirstOrDefault(i => i.Key == key);
        }
    }
}
