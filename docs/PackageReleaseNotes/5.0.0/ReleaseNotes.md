- .NET 7 support added.
- Dependency update.
- After updating the dependency System.Memory to version 4.5.5 there is now a **compiler error, if you try to use the .NET Standard 2.0 part of the package to compile a .NET Core 2.x/3.0 application**. (You can use the .NET Standard 2.0 part of the package for all other platforms, e.g., Xamarin or UWP apps.) This seems to be intended by Microsoft. (Read Andrew Locks interesting blog post [Please stop lying about .NET Standard 2.0 support!](https://andrewlock.net/stop-lying-about-netstandard-2-support/)) The article describes also a solution, which you can use at own risk: Copy `<SuppressTfmSupportBuildWarnings>true</SuppressTfmSupportBuildWarnings>` to a `<PropertyGroup>` of your Visual Studio project file and you get your .NET Core 2.x/3.0 application compiled.
- After updating the dependency System.Text.Encoding.CodePages to version 7.0.0 the behavior of the `TextEncodingConverter` methods that create Encoding objects became inconsistent and not testable between the different supported platforms when passing `0` as argument. To overcome this issue, **the argument `0` in this methods is treated as an invalid value, starting with this version.**
- The methods `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` now accept encoding names that contain `SPACE` characters.
- The `TextEncodingConverter.GetEncoding(...)` methods got an optional parameter that allows to choose whether in case of a failed conversion the fallback value is returned or an exception is thrown.
- The parameter `name` in `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` has been renamed to `encodingWebName`.
- The parameter `codepage` in `TextEncodingConverter.GetEncoding(int)` and `TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback)` has been renamed to `codePage`.
- New methods:
```csharp
static bool TextEncodingConverter.TryGetEncoding(string?, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(string?, EncoderFallback, DecoderFallback, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(int, out Encoding?);
static bool TextEncodingConverter.TryGetEncoding(int, EncoderFallback, DecoderFallback, out Encoding?);
```
.
> Project reference: On some systems, the content of the CHM file in the Assets is blocked. Before opening the file right click on the file icon, select Properties, and check the "Allow" checkbox - if it is present - in the lower right corner of the General tab in the Properties dialog.