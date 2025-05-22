// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BarbezDotEu.Drawing
{
    /// <summary>
    /// Provides helper methods for image creation, conversion, and watermarking.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Creates an image from the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The loaded image.</returns>
        public static Image CreateImage(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                return Image.FromStream(fs);
        }

        /// <summary>
        /// Converts a bitmap image to a byte array.
        /// </summary>
        /// <param name="img">The bitmap image.</param>
        /// <param name="format">The image format.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ImageToByte(Bitmap img, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                img.Dispose();
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Renders an object's visual representation to an image with a specified background color.
        /// </summary>
        /// <param name="obj">The object to render (must implement IViewObject).</param>
        /// <param name="destination">The destination image.</param>
        /// <param name="backgroundColor">The background color to use.</param>
        public static void GetImage(object obj, Image destination, Color backgroundColor)
        {
            using (Graphics graphics = Graphics.FromImage(destination))
            {
                IntPtr deviceContextHandle = IntPtr.Zero;
                RECT rectangle = new RECT
                {
                    Right = destination.Width,
                    Bottom = destination.Height
                };

                graphics.Clear(backgroundColor);

                try
                {
                    deviceContextHandle = graphics.GetHdc();

                    IViewObject viewObject = obj as IViewObject;
                    viewObject.Draw(1, -1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, deviceContextHandle, ref rectangle, IntPtr.Zero, IntPtr.Zero, 0);
                }
                finally
                {
                    if (deviceContextHandle != IntPtr.Zero)
                    {
                        graphics.ReleaseHdc(deviceContextHandle);
                    }
                }
            }
        }

        /// <summary>
        /// Converts a bitmap image to a byte array with a watermark.
        /// </summary>
        /// <param name="img">The bitmap image.</param>
        /// <param name="watermarkFilePath">The watermark file path.</param>
        /// <param name="format">The image format.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ImageToByte(Bitmap img, string watermarkFilePath, ImageFormat format)
        {
            using (Image watermark = CreateImage(watermarkFilePath))
            using (Graphics g = Graphics.FromImage(img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                int repeatX = 1;
                int repeatY = 1;

                if (watermark.Width > 0) repeatX = 2 + img.Width / watermark.Width;
                if (watermark.Height > 0) repeatY = 2 + img.Height / watermark.Height;

                for (int x = 0; x < repeatX; x++)
                    for (int y = 0; y < repeatY; y++)
                        g.DrawImage(watermark, new Point(img.Width - x * watermark.Width, img.Height - y * watermark.Height));

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, format);
                    img.Dispose();
                    g.Flush();
                    return ms.ToArray();
                }
            }
        }
    }
}
