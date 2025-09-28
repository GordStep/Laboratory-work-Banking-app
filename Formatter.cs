using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Formatter
    {
        static public string formattingPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 0) return "";

            phoneNumber = clearString(phoneNumber);

            string country_code;
            string sity_code = phoneNumber.Substring(1, 3); 
            string oper_code = phoneNumber.Substring(4, 3); 
            string dop_code1 = phoneNumber.Substring(7, 2);
            string dop_code2 = phoneNumber.Substring(9, 2);

            if (phoneNumber[0] == '7')
            {
                country_code = "+7";
            }
            else 
            {
                country_code = "8";
            }

            return $"{country_code}({sity_code})-{oper_code}-{dop_code1}-{dop_code2}";
        }

        static public string formattingBankCardNumber(string bankCardNumber)
        {
            bankCardNumber = clearString(bankCardNumber);

            if (bankCardNumber.Length == 0 || bankCardNumber == null) return "";

            return $"{bankCardNumber.Substring(0, 4)}-{bankCardNumber.Substring(4, 4)}-{bankCardNumber.Substring(8, 4)}-{bankCardNumber.Substring(12, 4)}";
        }
        static public string formattingPassport(string passport)
        {
            if (passport.Length == 0) return "";

            passport = clearString(passport);
            return $"{passport.Substring(0, 4)} {passport.Substring(4, 6)}";
        }

        static public string clearString(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("+", "");
            str = str.Replace("-", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            return str;
        }
    }
}
