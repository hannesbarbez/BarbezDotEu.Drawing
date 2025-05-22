// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace BarbezDotEu.Drawing
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
