using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Client: Person
    {
        private string phone_number;
        private string passport_number;
        private string passport_series;
        private int bank_account_number;
        private string bank_card_number;

        public Client(int bank_account_number)
        {
            first_name = "";
            last_name =  "";
            patronymic = "";

            phone_number =      "";
            passport_number =   "";
            passport_series =   "";
            bank_card_number =  "";
            this.bank_account_number = bank_account_number; 
        }
        public Client(
            int    bank_account_number, 
            string first_name, 
            string last_name, 
            string patronymic,
            string phone_number,
            string passport_number,
            string passport_series,
            string bank_card_number
            )
        {
            this.first_name = first_name;
            this.last_name =  last_name;
            this.patronymic = patronymic;

            this.phone_number =     phone_number;
            this.passport_number =  passport_number;
            this.passport_series =  passport_series;
            this.bank_card_number = bank_card_number.Trim('-');

            this.bank_account_number = bank_account_number;
        }

        // Получение общей информации передаётся по наследству
        public override string ToString()
        {
            return $"{last_name} {first_name[0]}. {patronymic[0]}.";
        }

        public string getPhoneNumber() { return phone_number; }
        public string getPassportNumber() { return passport_number; }
        public string getPassportSeries() { return passport_series; }
        public int getBankAccountNumber() {  return bank_account_number; }
        public string getBankCardNumber() {  return bank_card_number; }

        // Изменение данных клиента
        public void setFirstName(string new_first_name) { first_name = new_first_name; }
        public void setLastName(string new_last_name) { last_name = new_last_name; }
        public void setPatronymic(string new_patronymic) { patronymic = new_patronymic; }
        public bool setPhoneNumber(string new_phone_number)
        {
            if (Checking.IsValidPhoneNumber(new_phone_number))
            {
                phone_number = new_phone_number;
                return true;
            }
            else return false;
        }
        public void setPassportNumber(string new_passport_number) { passport_number = new_passport_number; }
        public void setPassportSeries(string new_passport_series) { passport_series = new_passport_series; }
        public void setBankAccountNumber(int new_bank_account_number) { bank_account_number = new_bank_account_number; }
        public void setBankCardNumber(string new_bank_card_number) { bank_card_number = new_bank_card_number; }
    }
}
