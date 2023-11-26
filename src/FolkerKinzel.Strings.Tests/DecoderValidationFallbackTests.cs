using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class DecoderValidationFallbackTests
{
    [TestMethod()]
    public void ResetTest()
    {
        var fb = new DecoderValidationFallback();
        Assert.IsFalse(fb.HasError);
        
        var enc = Encoding.GetEncoding("UTF-8", EncoderFallback.ReplacementFallback, fb);
        using var stream = new MemoryStream([129, 142, 210, 184]);
        using var reader = new StreamReader(stream, enc, false);
        string s = reader.ReadToEnd();
        Assert.IsTrue(fb.HasError);
        fb.Reset();
        Assert.IsFalse(fb.HasError);
    }

    [TestMethod()]
    public void CreateFallbackBufferTest()
    {
        var fb = new DecoderValidationFallback();
        DecoderFallbackBuffer buf1 = fb.CreateFallbackBuffer();
        DecoderFallbackBuffer buf2 = fb.CreateFallbackBuffer();
        Assert.AreSame(buf1, buf2);

        buf1.Reset();
        Assert.AreEqual(0, buf1.Remaining);
        Assert.IsFalse(buf1.MovePrevious());
    }
}