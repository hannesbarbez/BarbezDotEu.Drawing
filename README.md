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

- `byte[] ImageToByte(Bitmap img, ImageFormat format)`  
  Converts a bitmap image to a byte array in the specified format.

- `void GetImage(object obj, Image destination, Color backgroundColor)`  
  Renders an object's visual representation (must implement `IViewObject`) to an image with a specified background color.

- `byte[] ImageToByte(Bitmap img, string watermarkFilePath, ImageFormat format)`  
  Converts a bitmap image to a byte array with a watermark applied.

## License

[MIT](LICENSE)
