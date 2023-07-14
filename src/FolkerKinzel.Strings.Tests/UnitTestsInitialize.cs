using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class UnitTestsInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitializeMethod(TestContext testContext)
        {
            if (!VcfPaths.VerifyPaths(out string error))
            {
                testContext.WriteLine(error);
                throw new System.IO.FileNotFoundException(error);
            }
        }

    
    }
}
