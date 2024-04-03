using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Domain.Core.Extensions
{
    public static class AjustarTextos
    {
        public static String RemoverEspacosEntrePalavras(String str)
        {

            str = str.Trim();

            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }


        public static string RemoverAcentuacao(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

        public static string TextoPadrao(string texto)
        {
            if (String.IsNullOrEmpty(texto))
                return "";

            string textoPadrao = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new();

            UnicodeCategory uc;

            foreach (char c in textoPadrao.ToCharArray())
            {
                uc = CharUnicodeInfo.GetUnicodeCategory(c);

                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);

                //if ((uc == UnicodeCategory.SpaceSeparator) || (uc == UnicodeCategory.DecimalDigitNumber) ||
                //    (uc == UnicodeCategory.LowercaseLetter) || (uc == UnicodeCategory.UppercaseLetter))
                //    sb.Append(c);
            }

            return sb.ToString().ToUpper();
        }

        public static string NomeUsuario(string texto)
        {
            texto = TextoPadrao(texto);

            string[] textoArray = texto.Split(" ");

            int endArray = textoArray.Length;

            string nomeUsuario = textoArray[0].ToString() + "." + textoArray[endArray - 1].ToString();

            return nomeUsuario.ToLower();
        }

        public static string TextoRoleName(string texto)
        {
            texto = TextoPadrao(texto).ToLower();

            string[] textoArray = texto.Split(" ");

            string novoTexto = "";

            for (int i = 0; i < textoArray.Length; i++)
            {
                novoTexto += string.Concat(textoArray[i][0].ToString().ToUpper(), textoArray[i].AsSpan(1));
            }

            novoTexto = novoTexto.Replace(" ", "_");
            novoTexto = novoTexto.Replace("-", "_");
            novoTexto = novoTexto.Replace(".", "_");

            string retorno = novoTexto.Trim();

            if (retorno.Length > 256)
                retorno = retorno.Substring(0, 256);

            return retorno;
        }

        public static string TextoClaimTypeValues(string texto)
        {
            texto = TextoPadrao(texto).ToLower();

            string[] textoArray = texto.Split(" ");

            string novoTexto = "";

            for (int i = 0; i < textoArray.Length; i++)
            {
                novoTexto = novoTexto + string.Concat(textoArray[i][0].ToString().ToUpper(), textoArray[i].AsSpan(1));
            }

            novoTexto = novoTexto.Replace(" ", "_");
            novoTexto = novoTexto.Replace("-", "_");
            novoTexto = novoTexto.Replace(".", "_");

            string retorno = novoTexto.Trim();

            if (retorno.Length > 256)
                retorno = retorno.Substring(0, 256);

            return retorno;
        }

        public static int? ExtrairNumeros(string text)
        {
            int? numero = null;

            string texto2 = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                    texto2 += text[i];
            }

            if (texto2.Length > 0)
                numero = int.Parse(texto2);

            return numero;
        }
    }
}
