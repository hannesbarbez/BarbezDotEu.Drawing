# BarbezDotEu.Drawing

BarbezDotEu.Drawing is a .NET Standard 2.0 library with drawing and image helpers. It uses [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).

## Installation

```shell
dotnet add package BarbezDotEu.Drawing
```

## Platform support

The library targets .NET Standard 2.0, but that does not make its graphics APIs cross-platform. `System.Drawing.Common` is supported only on Windows in .NET 6 and later. Check the platform support of your runtime before using this package.

## API

### `RECT`

A sequentially laid-out struct with `Left`, `Top`, `Right`, and `Bottom` integer fields, intended for interop with APIs that use this rectangle layout.

### `IViewObject`

A COM interface for drawing an object's visual representation to a device context. Its `Draw` method accepts the drawing aspect, target device contexts, and bounds.

### `ImageHelper`

Static helpers for image loading, conversion, rendering, and watermarking:

| Method | Description |
| --- | --- |
| `CreateImage(string filePath)` | Loads and returns an image from a file path. |
| `ImageToByte(Image img, ImageFormat format)` | Encodes an image as a byte array in the specified format. |
| `ConvertToImageFormat(string imagePath, ImageFormat format)` | Loads an image from a path and encodes it in the specified format. |
| `GetImage(object obj, Image destination, Color backgroundColor)` | Clears the destination image to the background color, then renders the object through `IViewObject`. |
| `Watermark(Image image, string watermarkFilePath, ImageFormat format)` | Applies a watermark loaded from a path and encodes the result. |
| `Watermark(string imageFilePath, string watermarkFilePath, ImageFormat format)` | Loads the source and watermark images from paths, applies the watermark, and encodes the result. |
| `Watermark(Image image, ImageFormat format, Image watermark)` | Applies the supplied watermark image repeatedly over the source image and encodes the result. |

`GetImage` requires an object that supports `IViewObject`. `ImageToByte` and the `Watermark` overloads that accept a source `Image` dispose that image; do not reuse it after calling these methods.

## License

This project is licensed under the [MIT License](LICENSE).

## Third-party notices

This project incorporates components based on work by Richard James Moss, copyright 2014, described in CodeProject article 793687. The CodeProject URL previously listed for the article is no longer available. The included work is licensed under the MIT License:

### Terms of the MIT License for third-party

Copyright 2014 Richard James Moss

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
