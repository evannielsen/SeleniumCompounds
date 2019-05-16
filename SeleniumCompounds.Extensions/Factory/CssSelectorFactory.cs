using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Extensions.Factory
{
    /// <summary>
    /// Class for creating CSS selectors.
    /// </summary>
    public static class CssSelectorFactory
    {
        /// <summary>
        /// CSS selector for selecting by an attributes value
        /// starting with the given string.
        /// </summary>
        /// <param name="elementName">The tag name.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns></returns>
        public static string AttributeValuePrefixSelector(string elementName, string attributeName, string value)
            => $"{elementName}[{attributeName}^='{value}']";

        /// <summary>
        /// CSS selector for selecting by an attributes value
        /// being equal to a given string.
        /// </summary>
        /// <param name="elementName">The tage name.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns></returns>
        public static string AttributeValueSelector(string elementName, string attributeName, string value)
            => $"{elementName}[{attributeName}='{value}']";

        /// <summary>
        /// CSS Selector for selecting by an attributes value
        /// containing the given string.
        /// </summary>
        /// <param name="elementName">The tag name.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns></returns>
        public static string AttributeValueContainsSelector(string elementName, string attributeName, string value)
            => $"{elementName}[{attributeName}*='{value}']";
    }
}
