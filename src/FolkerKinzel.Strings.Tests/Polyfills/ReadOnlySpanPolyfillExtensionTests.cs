using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class ReadOnlySpanPolyfillExtensionTests : IDisposable
    {
        private readonly CultureInfo _culture;

        public ReadOnlySpanPolyfillExtensionTests()
        {
            _culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            GC.SuppressFinalize(this);
        }
    }
}