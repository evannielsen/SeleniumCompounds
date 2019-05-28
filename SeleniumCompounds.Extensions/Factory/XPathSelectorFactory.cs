using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Extensions.Factory
{
    /// <summary>
    /// Class for creating XPath selectors.
    /// </summary>
    public static class XPathSelectorFactory
    {
        /// <summary>
        /// XPath selector for finding an element that contains the given text.
        /// </summary>
        /// <param name="text">The text to search for.</param>
        /// <returns></returns>
        public static string ContainsText(string text) => $"//*[contains(text(),'{text}')]";

        public static string GetAncestorContainsText(string text, string ancestorName) => $"{ContainsText(text)}/ancestor::{ancestorName}";
    }
}
