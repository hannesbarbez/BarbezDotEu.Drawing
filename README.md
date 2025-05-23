# BarbezDotEu.Drawing

This project is a .NET library targeting **.NET Standard 2.0**.  
It provides drawing and imaging utilities, and depends on the `System.Drawing.Common` package for cross-platform graphics support.

## Target Framework

- .NET Standard 2.0

## Dependencies

- [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/)

## Classes and Interfaces

### RECT

The `RECT` struct represents a rectangle by defining the coordinates of its edges.

- **Left, Top, Right, Bottom**: The coordinates of the rectangle's edges.

---

### IViewObject

The `IViewObject` interface is a COM interface for drawing objects. It is typically used for advanced scenarios involving COM interop and custom rendering.

- **Draw**: Renders the visual representation of the object to a device context.

---

### ImageHelper

The `ImageHelper` static class provides helper methods for image creation, conversion, and watermarking.

#### Methods

- `Image CreateImage(string filePath)`  
  Loads an image from the specified file path.

- `byte[] ImageToByte(Image img, ImageFormat format)`  
  Converts an image to a byte array in the specified format.

- `byte[] ConvertToImageFormat(string imagePath, ImageFormat format)`  
  Loads an image from the specified file path and converts it to a byte array in the given image format.

- `void GetImage(object obj, Image destination, Color backgroundColor)`  
  Renders an object's visual representation (must implement `IViewObject`) to an image with the provided background color.

- `byte[] Watermark(Image image, string watermarkFilePath, ImageFormat format)`  
  Applies a watermark from the specified file path to the given image and converts the result to a byte array.

- `byte[] Watermark(string imageFilePath, string watermarkFilePath, ImageFormat format)`  
  Loads an image and a watermark from the given file paths, applies the watermark, and converts the result to a byte array.

- `byte[] Watermark(Image image, ImageFormat format, Image watermark)`  
  Applies the provided watermark image to the given image and converts the result to a byte array.

## License

[MIT](LICENSE)

## Third Party Notices

This repository and package incorporates components from the Open Source Software below. The original copyright notices and the licenses under which the author of this repository and package received such components are set forth below for informational purposes.

The article at https://www.codeproject.com/Articles/793687/Configuring-the-emulation-mode-of-an-Internet-Expl, along with any associated source code and files, used by this repository and package, is licensed under The MIT License.

### Terms of the MIT License for third-party:
-------------------------------------------------------------------
Copyright 2014 Richard James Moss

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
