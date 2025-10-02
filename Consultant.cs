using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Consultant: Person, IEmployee
    {
        // Данные консультанта
        protected int id;

        // Конструктор
        public Consultant(int id, string first_name, string last_name, string patronymic)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.patronymic = patronymic;
        }


        // Функции получения информации о сотруднике
        public int getId()
        {
            return id;
        }

        public bool isManager() { return false; }
        public bool isConsultant() { return true; }

        // Функции изменения информации о консультанте

        public void setFirstName(string first_name) { this.first_name = first_name; }
        public void setLastName(string last_name) { this.last_name = last_name; }
        public void setPatronymic(string patronymic) { this.patronymic = patronymic; }

        // У консультанта нет прав на изменение данных клиента

        // Функции полученя информации о клиенте
        public string getClientFirstName(Client client)
        {
            if (client.getFirstName().Length == 0)
                return "-";
            else return client.getFirstName();
        }

        public string getClientLastName(Client client)
        {
            if (client.getLastName().Length == 0)
                return "-";
            else return client.getLastName();
        }
        public string getClientPatronymic(Client client)
        {
            if (client.getPatronymic().Length == 0)
                return "-";
            else return client.getPatronymic();
        }

        // Закрытая для консультанта информация

        //
        //public string getClientPassportNumber(Client client)
        //{
        //    if (client.getPassportNumber().Length == 0)
        //        return "-";
        //    else return string.Concat(Enumerable.Repeat("*", client.getPassportNumber().Length));
        //}
        //public string getClientPassportSeries(Client client)
        //{
        //    if (client.getPassportNumber().Length == 0)
        //        return "-";
        //    else return string.Concat(Enumerable.Repeat("*", client.getPassportSeries().Length));
        //}
        //
        //public string getClientPassport(Client client)
        //{
        //    if (Formatter.clearString(client.getPassport()).Length == 0)
        //        return "-";
        //    else return string.Concat(Enumerable.Repeat("*", client.getPassport().Length));
        //}
        //public string getClientBankAccountNumber(Client client)
        //{
        //    if (client.getBankAccountNumber().ToString().Length == 0)
        //        return "-";
        //    else return client.getBankAccountNumber().ToString();
        //}
        //public string getClientBankCardNumber(Client client)
        //{
        //    if (Formatter.clearString(client.getBankCardNumber()).Length == 0)
        //        return "-";
        //    else return string.Concat(Enumerable.Repeat("*", client.getBankCardNumber().Length));
        //}
    }
}
