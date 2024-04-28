# Compatibility
## String.IndexOfAny(Char[])

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | .NET Standard 2.0 | .NET 461 |
|:---						|:---:     |:---:          |:---:              |:---:              |:---:     |
|Needles empty              |   -1     |       -1      |         -1        |        -1         |          |
|String empty               |   -1     |       -1      |         -1        |        -1         |          |
|Needles + String<br/>empty |   -1     |       -1      |         -1        |        -1         |          |

&nbsp;
## String.LastIndexOfAny(Char[])

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | .NET Standard 2.0 | .NET 461 |
|:---						|:---:     |:---:          |:---:              |:---:              |:---:     |
|Needles empty              |   -1     |       -1      |          -1       |        -1         |          |
|String empty               |   -1     |       -1      |          -1       |        -1         |          |
|Needles + String<br/>empty |   -1     |       -1      |          -1       |        -1         |          |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.IndexOfAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | System.Memory 4.5.5 |
|:---						|:---:     |:---:          |:---:              |:---:                |
|Needles empty              |    -1    |       -1      |          -1       |          0          |
|String empty               |    -1    |       -1      |          -1       |         -1          |
|Needles + String<br/>empty |    -1    |       -1      |          -1       |          0          |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.ContainsAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | FolkerKinzel.Strings|
|:---						|:---:     |:---:                |
|Needles empty              |  false   |     false           |
|String empty               |  false   |     false           |
|Needles + String<br/>empty |  false   |     false           |

&nbsp;
## ReadOnlySpan&lt;Char&gt;.LastIndexOfAny(ReadOnlySpan&lt;Char&gt;)

|                           | .NET 8.0 | .NET CORE 3.1 | .NET STandard 2.1 | System.Memory 4.5.5 |
|:---						|:---:     |:---:          |:---:              |:---:                |
|Needles empty              |   -1     |      -1       |        -1         |          0          |
|String empty               |   -1     |      -1       |        -1         |         -1          |
|Needles + String<br/>empty |   -1     |      -1       |        -1         |          0          |