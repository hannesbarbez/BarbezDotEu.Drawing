// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace BarbezDotEu.Drawing
{
    /// <summary>
    /// Exposes methods that allow an object to display itself to a specified device context.
    /// </summary>
    [ComImport]
    [Guid("0000010D-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IViewObject
    {
        /// <summary>
        /// Renders a representation of an object onto the specified device context.
        /// </summary>
        /// <param name="dwAspect">Indicates how the object should be drawn (for example, content, thumbnail, icon).</param>
        /// <param name="lindex">Part of the object to draw; typically 0.</param>
        /// <param name="pvAspect">Pointer to additional information for drawing; usually null.</param>
        /// <param name="ptd">Pointer to a DVTARGETDEVICE structure defining the target device; can be IntPtr.Zero.</param>
        /// <param name="hdcTargetDev">Device context for which the drawing is optimized; can be IntPtr.Zero.</param>
        /// <param name="hdcDraw">Device context on which to draw.</param>
        /// <param name="lprcBounds">Reference to a RECT structure specifying the rectangle in which to draw.</param>
        /// <param name="lprcWBounds">Pointer to a rectangle specifying the window bounds; can be IntPtr.Zero.</param>
        /// <param name="pfnContinue">Pointer to a function that determines whether the drawing should continue; can be IntPtr.Zero.</param>
        /// <param name="dwContinue">Value passed to the continue function; typically 0.</param>
        void Draw(
            [MarshalAs(UnmanagedType.U4)] uint dwAspect,
            int lindex,
            IntPtr pvAspect,
            [In] IntPtr ptd,
            IntPtr hdcTargetDev,
            IntPtr hdcDraw,
            [MarshalAs(UnmanagedType.Struct)] ref RECT lprcBounds,
            [In] IntPtr lprcWBounds,
            IntPtr pfnContinue,
            [MarshalAs(UnmanagedType.U4)] uint dwContinue);
    }
}
