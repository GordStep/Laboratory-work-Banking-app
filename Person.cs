using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    abstract class Person
    {
        protected string first_name = "";
        protected string last_name = "";
        protected string patronymic = "";

        public string getFirstName() { return first_name; }
        public string getLastName() { return last_name; }
        public string getPatronymic() { return patronymic; }

        public override string ToString()
        {
            return $"{last_name} {first_name} {patronymic}";
        }
    }
}
