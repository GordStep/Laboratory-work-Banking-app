using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal interface IEmployee
    {
        // Функции получения информации о сотруднике
        public int getId();
        public bool isManager();
        public bool isConsultant();


        //// Функции изменения данных клиента 
        //public void setClientFirstName(Client client, string new_first_name);
        //public void setClientLastName(Client client, string new_last_name);
        //public void setClientPatronymic(Client client, string new_patronymic);
        //public void setClientPhoneNumber(Client client, string new_phone_number);
        //public void setClientPassportNumber(Client client, string new_passport_number);
        //public void setClientBankAccountNumber(Client client, string new_bank_account_number);


        // Функции полученя информации о клиенте
        //public string getClientFirstName(Client client);
        //public string getClientLastName(Client client);
        //public string getClientPatronymic(Client client);
        ////public string getClientPhoneNumber(Client client);

        ////public string getClientPassportNumber(Client client);
        //public string getClientPassport(Client client);
        //public string getClientBankAccountNumber(Client client);
    }
}
