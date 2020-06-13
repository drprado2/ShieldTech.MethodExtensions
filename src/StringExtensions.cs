using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ShieldTech.MethodExtensions
{
    public static class StringExtensions
    {
        public static string NormalizeString(this string @string)
            => @string?.Trim().ToUpper() ?? "";

        public static bool HasOnlyNumbers(this String @string)
        {
            var pattern = @"^\d*$";
            return Regex.Match(@string, pattern, RegexOptions.Multiline).Success;
        }

        public static string GetOnlyNumbers(this String @string)
        {
            return Regex.Replace(@string, "[^0-9]", "", RegexOptions.Multiline);
        }

        public static bool IsExcelExtensionFile(this String @string)
        {
            var pattern = @"xlsx?$";
            return Regex.Match(@string, pattern, RegexOptions.Multiline).Success;
        }

        public static string FormatCNPJ(this string CNPJ)
        {
            if (string.IsNullOrWhiteSpace(CNPJ))
                return String.Empty;
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatCPF(this string CPF)
        {
            if (string.IsNullOrWhiteSpace(CPF))
                return String.Empty;
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static string FormatCellphone(this string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return String.Empty;
            return Convert.ToUInt64(number).ToString(@"\(00\) 00000-0000");
        }

        public static string RemoveDocumentMasks(this string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }

        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }
        
        public static IEnumerable<Type> GetTypesFromClassName(this string className)
        {
            return Assembly.GetExecutingAssembly()
                .GetTypesFromAssemblyAndReferenced()
                .Where(type => type.Name == className);
        }
    }
}