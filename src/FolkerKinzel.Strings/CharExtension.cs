using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="char"/>-Struktur.
    /// </summary>
    public static class CharExtension
    {
        /// <summary>
        /// Ruft den Wert einer Hexadezimalziffer ab.
        /// </summary>
        /// <param name="digit">Die zu konvertierende Hexadezimalziffer (0-9, a-f, A-F).</param>
        /// <returns>Eine Zahl von 0 bis 15, die der angegebenen Hexadezimalziffer entspricht.</returns>
        /// <remarks>Ruft <see cref="Uri.FromHex(char)"/> auf.</remarks>
        /// <exception cref="ArgumentException">
        /// <paramref name="digit"/> ist keine gültige Hexadezimalziffer (0-9, a-f, A-F).
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ParseHexDigit(this char digit)
            => Uri.FromHex(digit);

        /// <summary>
        /// Versucht, ein Zeichen als Hexadezimalziffer zu interpretieren und den Wert, den 
        /// diese Hexadezimalziffer darstellt, zurückzugeben.
        /// </summary>
        /// <param name="digit">Das zu analysierende Zeichen.</param>
        /// <param name="value">Enthält nach der erfolgreichen Beendigung der Methode den Wert,
        /// den <paramref name="digit"/> als Hexadezimalziffer
        /// darstellt, andernfalls <c>null</c>. Der Parameter wird uninitialisiert übergeben.</param>
        /// <returns><c>true</c>, wenn <paramref name="digit"/> eine Hexadezimalziffer darstellt,
        /// andernfalls <c>false</c>.</returns>
        public static bool TryParseHexDigit(this char digit, [NotNullWhen(true)] out int? value)
        {
            if(digit.IsHexDigit())
            {
                value = Uri.FromHex(digit);
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Versucht, ein Zeichen als Dezimalziffer (0-9) zu interpretieren und den Wert, den 
        /// diese Dezimalziffer darstellt, zurückzugeben.
        /// </summary>
        /// <param name="digit">Das zu analysierende Zeichen.</param>
        /// <param name="value">Enthält nach der erfolgreichen Beendigung der Methode den Wert,
        /// den <paramref name="digit"/> als Dezimalziffer
        /// darstellt, andernfalls <c>null</c>. Der Parameter wird uninitialisiert übergeben.</param>
        /// <returns><c>true</c>, wenn <paramref name="digit"/> eine Dezimalziffer darstellt,
        /// andernfalls <c>false</c>.</returns>
        public static bool TryParseDecimalDigit(this char digit, [NotNullWhen(true)] out int? value)
        {
            if(digit.IsDecimalDigit())
            {
                value = (int)digit - 48;
                return true;
            }

            value = null;
            return false;
        }


        /// <summary>
        /// Versucht, ein Zeichen als Binärziffer (0 oder 1) zu interpretieren und den Wert, den 
        /// diese Dezimalziffer darstellt, zurückzugeben.
        /// </summary>
        /// <param name="digit">Das zu analysierende Zeichen.</param>
        /// <param name="value">Enthält nach der erfolgreichen Beendigung der Methode den Wert,
        /// den <paramref name="digit"/> als Binärziffer
        /// darstellt, andernfalls <c>null</c>. Der Parameter wird uninitialisiert übergeben.</param>
        /// <returns><c>true</c>, wenn <paramref name="digit"/> eine Binärziffer darstellt,
        /// andernfalls <c>false</c>.</returns>
        public static bool TryParseBinaryDigit(this char digit, [NotNullWhen(true)] out int? value)
        {
            if(digit.IsBinaryDigit())
            {
                value = digit == '1' ? 1 : 0;
                return true;
            }

            value = null;
            return false;
        }
        
        /// <summary>
        /// Ruft den Wert einer Dezimalziffer ab.
        /// </summary>
        /// <param name="digit">Die zu konvertierende Hexadezimalziffer (0-9, a-f, A-F).</param>
        /// <returns>Eine Zahl von 0 bis 9, die der angegebenen Dezimalziffer entspricht.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="digit"/> ist keine gültige Dezimalziffer (0-9).
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ParseBinaryDigit(this char digit)
            => TryParseBinaryDigit(digit, out int? value) 
                ? value.Value
                : throw new ArgumentException(string.Format(Res.NoBinaryDigit, nameof(digit)), nameof(digit));


        /// <summary>
        /// Ruft den Wert einer Dezimalziffer ab.
        /// </summary>
        /// <param name="digit">Die zu konvertierende Hexadezimalziffer (0-9, a-f, A-F).</param>
        /// <returns>Eine Zahl von 0 bis 9, die der angegebenen Dezimalziffer entspricht.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="digit"/> ist keine gültige Dezimalziffer (0-9).
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ParseDecimalDigit(this char digit)
            => TryParseDecimalDigit(digit, out int? value) 
                ? value.Value
                : throw new ArgumentException(string.Format(Res.NoDecimalDigit, nameof(digit)), nameof(digit));


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen zum ASCII-Zeichensatz gehört.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c> wenn <paramref name="c"/> ein Zeichen des ASCII-Zeichensatzes ist,
        /// anderenfalls <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAscii(this char c) => 128u > c;



        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen eine Dezimalziffer (0-9) darstellt.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> eine Dezimalziffer
        /// darstellt, andernfalls <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0078:Musterabgleich verwenden", Justification = "<Ausstehend>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDecimalDigit(this char c) => 47u < c && 58u > c;


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen eine eine gültige Hexadezimalziffer (0-9, a-f, A-F) ist.
        /// </summary>
        /// <param name="character">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="character"/> eine Hexadezimalziffer
        /// ist, andernfalls <c>false</c>.</returns>
        /// <remarks>Ruft <see cref="Uri.IsHexDigit(char)"/> auf.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHexDigit(this char character) => Uri.IsHexDigit(character);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen eine Binärziffer (0 oder 1) darstellt.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> eine Binärziffer
        /// darstellt, andernfalls <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBinaryDigit(this char c) => c is '0' or '1';

        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Steuerzeichen kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Steuerzeichen
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsControl(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsControl(this char c) => char.IsControl(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Mitglied der Unicode-Kategorie
        /// "Decimal Digit Number" kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als
        /// Mitglied der Unicode-Kategorie
        /// "Decimal Digit Number"
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// <para>
        /// Ruft die Methode <see cref="char.IsDigit(char)"/> auf.
        /// </para>
        /// <note type="important">
        /// Zur Unicode-Kategorie "Decimal Digit Number" gehören sehr viel mehr
        /// Zeichen als die Ziffern 0-9. Verwenden sie die Methode <see cref="CharExtension.IsDecimalDigit(char)"/>,
        /// wenn Sie auf die Zeichen 0-9 prüfen möchten.
        /// </note>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDigit(this char c) => char.IsDigit(c);

        /// <summary>
        /// Gibt an, ob <paramref name="c"/> ein hohes Ersatzzeichen ist.
        /// </summary>
        /// <param name="c">Die auszuwertende <see cref="char"/>-Instanz.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> ein hohes 
        /// Ersatzzeichen ist, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsHighSurrogate(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHighSurrogate(this char c) => char.IsHighSurrogate(c);


        /// <summary>
        /// Gibt an, ob <paramref name="c"/> ein niedriges Ersatzzeichen ist.
        /// </summary>
        /// <param name="c">Die auszuwertende <see cref="char"/>-Instanz.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> ein niedriges 
        /// Ersatzzeichen ist, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsLowSurrogate(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowSurrogate(this char c) => char.IsLowSurrogate(c);


        /// <summary>
        /// Gibt an, ob <paramref name="c"/> über eine Ersatzzeichencodeeinheit verfügt.
        /// </summary>
        /// <param name="c">Die auszuwertende <see cref="char"/>-Instanz.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> über eine Ersatzzeichencodeeinheit 
        /// verfügt, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsSurrogate(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSurrogate(this char c) => char.IsSurrogate(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Unicode-Buchstabe kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Unicode-Buchstabe
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsLetter(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLetter(this char c) => char.IsLetter(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Buchstabe oder Dezimalzahl kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Buchstabe oder Dezimalzahl
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsLetterOrDigit(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLetterOrDigit(this char c) => char.IsLetterOrDigit(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Kleinbuchstabe kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Kleinbuchstabe
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsLower(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLower(this char c) => char.IsLower(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Großbuchstabe kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Großbuchstabe
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsUpper(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUpper(this char c) => char.IsUpper(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Zahl kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Zahl
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsNumber(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumber(this char c) => char.IsNumber(c);

        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Satzzeichen kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Satzzeichen 
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsPunctuation(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPunctuation(this char c) => char.IsPunctuation(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Trennzeichen kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Trennzeichen 
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsSeparator(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSeparator(this char c) => char.IsSeparator(c);

        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Symbolzeichen kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Symbolzeichen 
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsSymbol(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSymbol(this char c) => char.IsSymbol(c);


        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen als Leerzeichen kategorisiert wird.
        /// </summary>
        /// <param name="c">Das auszuwertende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> als Leerzeichen 
        /// kategorisiert wird, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Ruft <see cref="char.IsWhiteSpace(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

        /// <summary>
        /// Konvertiert den Wert eines Unicode-Zeichens in dessen Entsprechung 
        /// in Kleinbuchstaben unter Verwendung der Regeln der invarianten Kultur für Groß- und Kleinschreibung.
        /// </summary>
        /// <param name="c">Das zu konvertierende Unicode-Zeichen.</param>
        /// <returns>Die Entsprechung des <paramref name="c"/>-Parameters in Kleinbuchstaben oder 
        /// der unveränderte Wert von <paramref name="c"/>, wenn <paramref name="c"/> bereits aus Kleinbuchstaben 
        /// besteht oder kein alphabetischer Wert ist.</returns>
        /// <remarks>
        /// Ruft <see cref="char.ToLowerInvariant(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToLowerInvariant(this char c) => char.ToLowerInvariant(c);


        /// <summary>
        /// Konvertiert den Wert eines Unicode-Zeichens in dessen Entsprechung 
        /// in Großbuchstaben unter Verwendung der Regeln der invarianten Kultur für Groß- und Kleinschreibung.
        /// </summary>
        /// <param name="c">Das zu konvertierende Unicode-Zeichen.</param>
        /// <returns>Die Entsprechung des <paramref name="c"/>-Parameters in Großbuchstaben oder 
        /// der unveränderte Wert von <paramref name="c"/>, wenn <paramref name="c"/> bereits aus Großbuchstaben 
        /// besteht oder kein alphabetischer Wert ist.</returns>
        /// <remarks>
        /// Ruft <see cref="char.ToUpperInvariant(char)"/> auf.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char ToUpperInvariant(this char c) => char.ToUpperInvariant(c);

    }
}
