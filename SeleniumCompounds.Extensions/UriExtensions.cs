using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCompounds.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Uri"/>.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Creates a Uri representing the combination of the provided uris.
        /// </summary>
        /// <param name="baseUri">The left hand side of the Uri.</param>
        /// <param name="realtiveUri">The right had side of the Uri.</param>
        /// <returns></returns>
        public static Uri Combine(this Uri baseUri, Uri realtiveUri)
        {
            return new Uri(baseUri, realtiveUri.ToString());
        }
    }
}
