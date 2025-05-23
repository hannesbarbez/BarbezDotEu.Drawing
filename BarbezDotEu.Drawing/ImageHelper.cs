// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            using (var filestream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(filestream);
            }
        }

        /// <summary>
        /// Converts an image to a byte array.
        /// </summary>
        /// <param name="img">The image.</param>
        /// <param name="format">The image format.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ImageToByte(Image img, ImageFormat format)
        {
            using (var memoryStrem = new MemoryStream())
            {
                img.Save(memoryStrem, format);
                img.Dispose();
                return memoryStrem.ToArray();
            }
        }

        /// <summary>
        /// Converts an image from the specified file path to a byte array in the specified image format.
        /// </summary>
        /// <param name="imagePath">The file path of the source image.</param>
        /// <param name="format">The desired image format.</param>
        /// <returns>A byte array representing the converted image.</returns>
        public static byte[] ConvertToImageFormat(string imagePath, ImageFormat format)
        {
            using (var image = CreateImage(imagePath))
            {
                return ImageToByte(image, format);
            }
        }

        /// <summary>
        /// Renders an object's visual representation to an image with a specified background color.
        /// </summary>
        /// <param name="object">The object to render (must implement IViewObject).</param>
        /// <param name="destination">The destination image.</param>
        /// <param name="backgroundColor">The background color to use.</param>
        public static void GetImage(object @object, Image destination, Color backgroundColor)
        {
            using (var graphics = Graphics.FromImage(destination))
            {
                var deviceContextHandle = IntPtr.Zero;
                var rectangle = new RECT
                {
                    Right = destination.Width,
                    Bottom = destination.Height
                };

                graphics.Clear(backgroundColor);
                try
                {
                    deviceContextHandle = graphics.GetHdc();

                    IViewObject viewObject = @object as IViewObject;
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
        /// Converts a image to a byte array with a watermark.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="watermarkFilePath">The watermark file path.</param>
        /// <param name="format">The image format.</param>
        /// <returns>The byte array.</returns>
        public static byte[] Watermark(Image image, string watermarkFilePath, ImageFormat format)
        {
            using (var watermark = CreateImage(watermarkFilePath))
            {
                return Watermark(image, format, watermark);
            }
        }

        /// <summary>
        /// Converts an image at the specified file path to a byte array with a watermark.
        /// </summary>
        /// <param name="imageFilePath">The file path of the image to watermark.</param>
        /// <param name="watermarkFilePath">The file path of the watermark image.</param>
        /// <param name="format">The image format for conversion.</param>
        /// <returns>A byte array representing the watermarked image.</returns>
        public static byte[] Watermark(string imageFilePath, string watermarkFilePath, ImageFormat format)
        {
            using (var image = CreateImage(imageFilePath))
            {
                using (var watermark = CreateImage(watermarkFilePath))
                {
                    return Watermark(image, format, watermark);
                }
            }
        }

        /// <summary>
        /// Converts the given image to a byte array with a watermark applied.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="format">The image format for conversion.</param>
        /// <param name="watermark">The watermark image to apply.</param>
        /// <returns>A byte array representing the watermarked image.</returns>
        public static byte[] Watermark(Image image, ImageFormat format, Image watermark)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                int repeatX = 1;
                int repeatY = 1;

                if (watermark.Width > 0) repeatX = 2 + image.Width / watermark.Width;
                if (watermark.Height > 0) repeatY = 2 + image.Height / watermark.Height;
                for (int x = 0; x < repeatX; x++)
                {
                    for (int y = 0; y < repeatY; y++)
                    {
                        graphics.DrawImage(watermark, new Point(image.Width - x * watermark.Width, image.Height - y * watermark.Height));
                    }
                }

                return SaveImage(image, format, graphics);
            }
        }

        private static byte[] SaveImage(Image image, ImageFormat format, Graphics graphics)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, format);
                image.Dispose();
                graphics.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}
