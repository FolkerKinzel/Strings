# Compatibility
## String.IndexOfAny(Char[])

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | .NET Standard 2.0 | .NET 461 |
|:---						|:---:     |:---:          |:---:              |:---:              |:---:     |
|Needles empty              |          |               |                   |                   |          |
|String empty               |          |               |                   |                   |          |
|Needles + String<br/>empty |          |               |                   |                   |          |

&nbsp;
## String.LastIndexOfAny(Char[])

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | .NET Standard 2.0 | .NET 461 |
|:---						|:---:     |:---:          |:---:              |:---:              |:---:     |
|Needles empty              |          |               |                   |                   |          |
|String empty               |          |               |                   |                   |          |
|Needles + String<br/>empty |          |               |                   |                   |          |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.IndexOfAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | System.Memory 4.5.5 |
|:---						|:---:     |:---:          |:---:              |:---:                |
|Needles empty              |          |               |                   |                     |
|String empty               |          |               |                   |                     |
|Needles + String<br/>empty |          |               |                   |                     |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.ContainsAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | System.Memory 4.5.5 |
|:---						|:---:     |:---:          |:---:              |:---:                |
|Needles empty              |          |               |                   |                     |
|String empty               |          |               |                   |                     |
|Needles + String<br/>empty |          |               |                   |                     |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.LastIndexOfAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | System.Memory 4.5.5 |
|:---						|:---:     |:---:          |:---:              |:---:                |
|Needles empty              |          |               |                   |                     |
|String empty               |          |               |                   |                     |
|Needles + String<br/>empty |          |               |                   |                     |