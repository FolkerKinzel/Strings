﻿using System;
using System.Text;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sb1 = new StringBuilder();
            //var sb2 = new StringBuilder("test");
            ////sb2 = null;
            //_ = sb1.Append(sb2, 0, 4711);

            //Console.WriteLine("Hello World!");
            const string test = "test";

            char[] arr = new char[] { 't'  };

            int i = test.IndexOfAny(arr, 1, test.Length-1);

        }
    }
}
