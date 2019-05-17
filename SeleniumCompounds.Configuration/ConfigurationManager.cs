using Microsoft.Extensions.Configuration;
using SeleniumCompounds.Configuration.Models;

namespace SeleniumCompounds.Configuration
{
    /// <summary>
    /// Class to manage getting environment configuration.
    /// </summary>
    public class ConfigurationManager
    {
        /// <summary>
        /// The current configuration.
        /// </summary>
        public static TestSuiteConfiguration Current { get; set; }

        private static IConfigurationRoot GetConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("secrets.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        /// <summary>
        /// Initialized the configuration for the environment and populates
        /// the current configuration.
        /// </summary>
        /// <param name="outputPath"></param>
        public static void InitializeConfiguration(string outputPath)
        {
            Current = new TestSuiteConfiguration();

            var configRoot = GetConfigurationRoot(outputPath);

            configRoot.GetSection("TestSuiteConfiguration").Bind(Current);
        }
    }
}
