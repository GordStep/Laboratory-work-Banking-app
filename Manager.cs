using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Manager: Consultant
    {
        // Данные менеджера
        public Manager(int id, string first_name, string last_name, string patronymic) : base(id, first_name, last_name, patronymic) { }

        // получение id по наследству

        new public bool isManager() { return true; }
        new public bool isConsultant() { return false; }

        // Функции изменения информации о менеджере наследуются от консультанта

        // У менеджера есть права на изменение данных клиента

        // Функции изменения данных клиента 
        public void editClientFirstName(Client client, string new_first_name)
        {
            client.setFirstName(new_first_name);
        }
        public void editClientLastName(Client client, string new_last_name) 
        { 
            client.setLastName(new_last_name); 
        }
        public void editClientPatronymic(Client client, string new_patronymic)
        {
            client.setPatronymic(new_patronymic);
        }

        public void editClientPhoneNumber(Client client, string new_phone_number)
        {
            client.setPhoneNumber(Formatter.formattingPhoneNumber(new_phone_number));
        }

        public void editClientPassportNumber(Client client, string new_passport_number)
        {
            client.setPassportNumber(new_passport_number);
        }
        public void editClientPassportSeries(Client client, string new_passport_series)
        {
            client.setPassportNumber(new_passport_series);
        }

        public void editClientBankAccountNumber(Client client, int new_bank_account_number)
        {
            client.setBankAccountNumber(new_bank_account_number);
        }
        public void editClientBankCardNumber(Client client, string new_bank_card_number)
        {
            if (Checking.IsValidCard(new_bank_card_number))
                client.setBankCardNumber(Formatter.formattingBankCardNumber(new_bank_card_number));
        }

        // Функции полученя информации о клиенте
        // Функции получения основной информации о клинете наследуются 
        new public string getClientPhoneNumber(Client client)
        {
            if (client.getPhoneNumber().Length == 0)
                return "-";
            else return client.getPhoneNumber();
        }
        new public string getClientPassportNumber(Client client)
        {
            if (client.getPassportNumber().Length == 0)
                return "-";
            else return client.getPassportNumber();
        }
        new public string getClientPassportSeries(Client client)
        {
            if (client.getPassportSeries().Length == 0)
                return "-";
            else return client.getPassportSeries();
        }
        new public string getClientBankAccountNumber(Client client)
        {
            if (client.getBankAccountNumber().ToString().Length == 0)
                return "-";
            else return client.getBankAccountNumber().ToString();
        }
        new public string getClientBankCardNumber(Client client)
        {
            if (client.getBankCardNumber().ToString().Length == 0)
                return "-";
            else return client.getBankCardNumber().ToString();
        }
    }
}
