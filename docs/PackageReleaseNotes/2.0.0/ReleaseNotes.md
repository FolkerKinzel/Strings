# FolkerKinzel.Strings 2.0.0
## Package Release Notes

- The .NET Framework 4.0 has been removed.
- The `GetStableHashCode` extension methods have been renamed to `GetPersistentHashCode`
to make their intention more clear.
- Extension methods have been added, which simulate the several overloads of the String.Trim() 
method for the `StringBuilder` class. [(See the list of overloads.)]()
- Extension methods, which act as Polyfills for .NET Framework 4.5,
.NET Standard 2.0 and .NET Standard 2.1 in order to make it easier to support
such older Framework versions in Multi Targeting Projects have been added.
[(See the complete list.)]()