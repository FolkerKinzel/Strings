//File: Common\Interop\Windows\BCrypt\Interop.BCryptGenRandom.GetRandomBytes.cs
//Project: System.Private.CoreLib.csproj(System.Private.CoreLib)	



// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
 
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

internal static partial class Interop
{
   

    internal static partial class BCrypt
    {
        internal enum NTSTATUS : uint
        {
            STATUS_SUCCESS = 0x0,
            //STATUS_NOT_FOUND = 0xc0000225,
            //STATUS_INVALID_PARAMETER = 0xc000000d,
            STATUS_NO_MEMORY = 0xc0000017,
            //STATUS_AUTH_TAG_MISMATCH = 0xc000a002,
        }

        internal const int BCRYPT_USE_SYSTEM_PREFERRED_RNG = 0x00000002;

        [DllImport("BCrypt.dll", CharSet = CharSet.Unicode)]
        internal static extern unsafe NTSTATUS BCryptGenRandom(IntPtr hAlgorithm, byte* pbBuffer, int cbBuffer, int dwFlags);
    }


    internal static unsafe void GetRandomBytes(byte* buffer, int length)
    {
        Debug.Assert(buffer != null);
        Debug.Assert(length >= 0);

        BCrypt.NTSTATUS status = BCrypt.BCryptGenRandom(IntPtr.Zero, buffer, length, BCrypt.BCRYPT_USE_SYSTEM_PREFERRED_RNG);
        if (status != BCrypt.NTSTATUS.STATUS_SUCCESS)
        {
            if (status == BCrypt.NTSTATUS.STATUS_NO_MEMORY)
            {
                throw new OutOfMemoryException();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
