using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Client: Person, IComparable<Client>
    {
        private string phone_number;
        private string passport;
        private int bank_account_number;
        private string bank_card_number;

        public Client(int bank_account_number)
        {
            first_name = "";
            last_name =  "";
            patronymic = "";

            phone_number =      "";
            passport =          "";
            bank_card_number =  "";
            this.bank_account_number = bank_account_number; 
        }
        public Client(
            int    bank_account_number, 
            string first_name, 
            string last_name, 
            string patronymic,
            string phone_number,
            string passport,
            string bank_card_number
            )
        {
            this.first_name = first_name;
            this.last_name =  last_name;
            this.patronymic = patronymic;

            this.phone_number =     Formatter.clearString(phone_number);
            this.passport = Formatter.clearString(passport);
            this.bank_card_number = Formatter.clearString(bank_card_number);

            this.bank_account_number = bank_account_number;
        }

        // Получение общей информации передаётся по наследству

        public override string ToString()
        {
            return $"{last_name} {first_name[0]}. {patronymic[0]}.";
        }
        public string Info()
        {
            var ph = phone_number;
            var ps = passport;
            var bc = bank_card_number;

            if (ph.Length == 0)
                ph = "-";
            if (ps.Length == 0) 
                ps = "-";
            if (bc.Length == 0) 
                bc = "-";

            return bank_account_number + ";"
                + first_name + ";"
                + last_name + ";"
                + patronymic + ";"
                + ph + ";"
                + ps + ";"
                + bc + ";";
        }

        public string getPhoneNumber() { return Formatter.formattingPhoneNumber(phone_number); }
        public string getPassport() { return Formatter.formattingPassport(passport); }
        public string getBankCardNumber() { return Formatter.formattingBankCardNumber(bank_card_number); }
        public int getBankAccountNumber() {  return bank_account_number; }
        

        // Изменение данных клиента
        public void setFirstName(string new_first_name) { first_name = new_first_name; }
        public void setLastName(string new_last_name) { last_name = new_last_name; }
        public void setPatronymic(string new_patronymic) { patronymic = new_patronymic; }

        public void setPhoneNumber(string new_phone_number)
        {
            if (Checking.IsValidPhoneNumber(new_phone_number))
            {
                phone_number = Formatter.clearString(new_phone_number);
            }
            else throw new Exception("Неверный номер телефона!");
        }
        public void setPassport(string new_passport)
        {
            if (Checking.isValidPassport(new_passport))
            {
                passport = Formatter.clearString(new_passport);
            }
            else throw new Exception("Неверный паспорт.");
        }
        public void setBankCardNumber(string new_bank_card_number) 
        {
            if (Checking.IsValidCard(new_bank_card_number))
            {
                bank_card_number = Formatter.clearString(new_bank_card_number);
            }
            else throw new Exception("Неверный номер банковской карты!");
        }

        public void setBankAccountNumber(int new_bank_account_number) { bank_account_number = new_bank_account_number; }

        public int CompareTo(Client obj)
        {
            int result = this.getBankAccountNumber().CompareTo(obj.getBankAccountNumber());
            if (result == 0)
                result = this.getBankAccountNumber().CompareTo(obj.getBankAccountNumber());
            return result;
        }

        public bool IsEqual(Client client)
        {
            if (bank_account_number == client.bank_account_number)
                return true; 
            if (bank_card_number != "" && bank_card_number == client.bank_card_number)
                return true;
            if (passport != "" && passport  == client.passport)
                return true;
            if (phone_number != "" && phone_number == client.phone_number)
                return true;

            return false;
        }
    }
}
