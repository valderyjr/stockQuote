using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockQuote.Utils
{
    public static class MailValidator
    {

        private static string _mailValidatorRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public static bool IsValid(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail)) return false;

            try
            {
                return Regex.IsMatch(mail,
                    _mailValidatorRegex,
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
    }
}
