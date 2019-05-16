using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Configuration.Models
{
    /// <summary>
    /// Class used to represent a user
    /// </summary>
    public class TestSuiteIdentity
    {
        /// <summary>
        /// A unique key for the user.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
