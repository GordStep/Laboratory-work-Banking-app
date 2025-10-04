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

        // Функции изменения информации о менеджере наследуются от 
    }
}