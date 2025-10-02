using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Banking_app
{
    class Checking
    {
        static public bool IsValidPhoneNumber(string phone_number)
        {
            phone_number = Formatter.clearString(phone_number);

            if (phone_number.Length == 0) return true;

            foreach (char c in phone_number)
                if (c < '0' || c > '9') return false;

            return true;
        }

        static public bool isValidPassport(string passport)
        {        
            passport = Formatter.clearString(passport);


            if (passport.Length == 0) return true;

            if (passport.Length != 10) return false;


            foreach (char c in passport)
            {
                if (!char.IsDigit(c) && c != ' ') return false;
            }
            return true;
        }

        static public bool IsValidCard(string card)
        {
            card = Formatter.clearString(card);

            if (card.Length == 0) return true;

            if (card.Length < 13)
                return false;

            foreach (char c in card)
            {
                if (c < '0' || c > '9') return false;
            }

            int control_sum = 0;
            //Console.WriteLine("i  sum");

            for (int i = 0; i < card.Length; i++)
            {
                var el = int.Parse(card[i].ToString());

                if (i % 2 == 0)
                {
                    if (el * 2 > 9)
                        control_sum += el * 2 - 9;
                    else
                        control_sum += el * 2;
                }
                else control_sum += el;

                //Console.WriteLine(el.ToString() + ", " + control_sum.ToString());
            }

            //Console.WriteLine(control_sum);
            if (control_sum % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
