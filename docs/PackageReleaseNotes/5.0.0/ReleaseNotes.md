- .NET 7 support added.
- Dependency update.
- After updating the dependency System.Text.Encoding.CodePages to version 7.0.0 the behavior of the methods `TextEncodingConverter.GetEncoding(int)` and `TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback)` became inconsistent and not testable between the different supported platforms when passing `0` as argument. To overcome this issue  the argument `0` in this methods is from now on treated as an invalid value.
- The methods `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` accept encoding names that contain `SPACE` characters now.
- The `TextEncodingConverter.GetEncoding(...)` methods got an optional parameter that allows to choose whether in case of a failed conversion the fallback value is returned or an exception is thrown.
- The parameter `name` in `TextEncodingConverter.GetEncoding(string?)` and `TextEncodingConverter.GetEncoding(string?, EncoderFallback, DecoderFallback)` has been renamed to `encodingWebName`.
- The parameter `codepage` in `TextEncodingConverter.GetEncoding(int)` and `TextEncodingConverter.GetEncoding(int, EncoderFallback, DecoderFallback)` has been renamed to `codePage`.

> Project reference: On some systems, the content of the CHM file in the Assets is blocked. Before opening the file
>  right click on the file icon, select Properties, and check the "Allow" checkbox - if it 
> is present - in the lower right corner of the General tab in the Properties dialog.