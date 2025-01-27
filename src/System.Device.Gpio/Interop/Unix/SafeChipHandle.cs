﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace System.Device.Gpio;

/// <summary>
/// Pointer to a general-purpose I/O (GPIO) chip.
/// </summary>
internal class SafeChipHandle : SafeHandle
{
    public SafeChipHandle()
        : base(IntPtr.Zero, true)
    {
    }

    protected override bool ReleaseHandle()
    {
        Interop.Libgpiod.gpiod_chip_close(handle);
        return true;
    }

    public override bool IsInvalid => handle == IntPtr.Zero || handle == Interop.Libgpiod.InvalidHandleValue;
}
