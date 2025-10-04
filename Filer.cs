using Banking_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    class Filer
    {
        static public void CreateDir(string dir)
        {
            DirectoryInfo directInfo = new DirectoryInfo(dir);

            string fileName = @$"{dir}\Clients.txt";

            if (!directInfo.Exists)
            {
                directInfo.Create();
                //MessageBox.Show($"Создана директория: {directInfo.FullName}", "Оповещение");
                StreamWriter streamwriter = new StreamWriter(fileName, true, System.Text.Encoding.GetEncoding("utf-8"));

                streamwriter.Close();
                //MessageBox.Show($"Создан файл: {fileName}", "Оповещение");
            }
        }
    }
    class ClientsSaver
    {
        
        static public void AddClientToTXT(Client client, string dirInfo)
        {
            DirectoryInfo directInfo = new DirectoryInfo(dirInfo);

            if (!directInfo.Exists)
            {
                directInfo.Create();
                //Console.WriteLine($"Создана директория: {directInfo.FullName}");
            }

            // true – в файл можно дописывать
            try
            {
                StreamWriter streamwriter = new StreamWriter(@$"{dirInfo}\Clients.txt", true, System.Text.Encoding.GetEncoding("utf-8"));
                streamwriter.WriteLine(client.Info());
                streamwriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Доступность файла");
                return;
            }
            //Console.WriteLine($"Создан файл: {dirInfo}\\Clients.txt");
        }

        static public void SaveClientsToTXT(List<Client> clients, string dirInfo, string fileName, bool rewriteFile = false)
        {
            clients.Sort();
            DirectoryInfo directInfo = new DirectoryInfo(dirInfo);

            string fullFileName = @$"{dirInfo}\{fileName}";

            if (!directInfo.Exists)
            {
                directInfo.Create();
            }

            // true – в файл можно дописывать
            try
            {
                // Удаляем существующий файл
                if (rewriteFile)
                {
                    File.WriteAllText(fullFileName, "");
                }
                //streamwriter.Close();

                StreamWriter file = new StreamWriter(fullFileName, true, System.Text.Encoding.GetEncoding("utf-8"));

                foreach (var c in clients)
                {
                    file.WriteLine(c.Info());
                    //Console.WriteLine(c.Info());
                }
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
            //MessageBox.Show($"Создан файл: {dirInfo}\\Clients.txt", "Оповещение");
        }
    }
    class ClientFileReader
    {
        public static List<Client> ReadClientsFile(string fileName)
        {
            var clients = new List<Client>();
            //MessageBox.Show("ищем файл: " + fileName);
            if (File.Exists(fileName))
            {
                //Console.WriteLine("файл открыт: " + fileName);

                //Crypter.DecryptFile(fileName, "decryptData.txt", );

                StreamReader file = new StreamReader(fileName);
                string[] values; //
                string newline; // считанная строка из файла

                string firstName;
                string lastName;
                string patronymic;

                string phoneNumber;
                string passport;
                string bankCardNumber;
                int bankAccountNumber;

                Client c;


                // считываем до конца файла
                while ((newline = file.ReadLine()) != null)
                {
                    values = newline.Split(';'); // строку разбиваем на части(lastname, firstname и т.д.), используя разделить пробел Split(' ')

                    bankAccountNumber = Convert.ToInt32(values[0]); // присваиваем ячейкам строки
                    firstName = values[1]; // присваиваем ячейкам строки
                    lastName = values[2]; // присваиваем ячейкам строки
                    patronymic = values[3];
                    phoneNumber = Formatter.clearString(values[4]);
                    passport = Formatter.clearString(values[5]);
                    bankCardNumber = Formatter.clearString(values[6]);

                    if (firstName == "" || lastName == "" || patronymic == "")
                        continue;
                    c = new Client(bankAccountNumber, firstName, lastName, patronymic, phoneNumber, passport, bankCardNumber);

                    bool isClientExist = false;

                    foreach (var cl in clients)
                    {
                        if (c.IsEqual(cl))
                            isClientExist = true;
                    }

                    if (!isClientExist)
                        clients.Add(c);
                }
                file.Close();

                clients.Sort();
            }
            else { MessageBox.Show("Файл не существует: " + fileName, "Ошибка!"); }

            return clients;
        }
    }
}