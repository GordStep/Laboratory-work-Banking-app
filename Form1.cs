using Microsoft.VisualBasic.Logging;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Windows.Forms;

namespace Banking_app
{
    public partial class MainForm : Form
    {
        Consultant consultant = new(1, "Иван", "Иванов", "Иванович");
        Manager manager = new(2, "Константин", "Константинов", "Константинович");

        bool managerNow = true;

        int nowMaxId = 0;

        static string dirClientInfo = @$"{Directory.GetCurrentDirectory().ToString()}\BankData";
        static string clientInfoFileName = "\\Clients.txt";
        static string fullFileName = dirClientInfo + clientInfoFileName;
        static string fullDecryptFileName = dirClientInfo + "\\decryptInfo.txt";

        int sh = 5;

        List<Client> clients = new List<Client>();

        public MainForm()
        {
            InitializeComponent();
            SetupListView();
            AttachClickEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //UpdateClientsData();
            Filer.CreateDir(dirClientInfo);
            //DebuggingInfo();
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                if (radioButton.Text.Equals("Менеджер"))
                {
                    MessageBox.Show(text: $"Выбран менеджер \n {manager.ToString()}", caption: "Изменение роли");
                    managerNow = true;
                    listView1.Clear();
                    SetupListView();
                }
                if (radioButton.Text.Equals("Консультант"))
                {
                    MessageBox.Show(text: $"Выбран консультант \n {consultant.ToString()}", caption: "Изменение роли");
                    managerNow = false;
                    listView1.Clear();
                    SetupListView();
                }
            }

        }

        private void SetupListView()
        {
            UpdateClientsDataFromFile();

            listView1.View = View.Tile;
            listView1.TileSize = new Size(300, 60);

            // Добавление колонок для отображения данных
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Description", 300);

            // Добавление элементов
            for (int i = 0; i < clients.Count(); i++)
            {
                //var item = new ListViewItem($"Плитка {i}");


                var item = new ListViewItem(clients[i].ToString());
                string user_info = "Номер банковского счёта(id): " + clients[i].getBankAccountNumber().ToString();
                item.SubItems.Add(user_info);


                // настройка шрифта
                item.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Шрифт для заголовка
                item.UseItemStyleForSubItems = false; // разное оформление для элементов item
                item.SubItems[1].Font = new Font("Segoe UI", 9, FontStyle.Regular); // Шрифт для описания

                listView1.Items.Add(item);
            }
        }

        private void AttachClickEvents()
        {
            // Обработка двойного клика
            listView1.DoubleClick += ListView1_DoubleClick;
            //listView1.MouseClick += listView1_MouseClick;
        }
        // работа 
        private void ListView1_DoubleClick(object? sender, EventArgs e)
        {
            var selectedItem = listView1.SelectedItems[0];
            if (managerNow)
            {
                //MessageBox.Show("клик");
                //var selectedItem = listView1.SelectedItems[0];

                //MessageBox.Show($"{clients[selectedItem.Index].getPassport()}");
                RedactMenuOpen();

                Form2 form = new Form2(clients[selectedItem.Index], manager);
                form.Owner = this;
                form.Show();
            }
            else
            {
                //var selectedItem = listView1.SelectedItems[0];

                var cl = clients[selectedItem.Index];


                MessageBox.Show(text: $"Фамилия: {cl.getLastName()} \n" +
                    $"Имя: {cl.getFirstName()} \n" +
                    $"Отчество: {cl.getPatronymic()} \n" +
                    $"Номер телефона: {Formatter.infoForConsultant(cl.getPhoneNumber())} \n" +
                    $"Паспорт: {Formatter.infoForConsultant(cl.getPassport())} \n" +
                    $"Номер банковской карты: {Formatter.infoForConsultant(cl.getBankCardNumber())} \n" +
                    $"Номер аккаунта: {cl.getBankAccountNumber()} \n",

                    "Просмотр данных о пользователе"
                    );

                Logger.WriteLog($"Консультант [номер: {consultant.getId()} ФИО: {consultant.ToString()}] изменил данные о клиенте номер: {cl.getBankAccountNumber()}\n");
            }
        }

        public void setClientData(
            int bank_account_number,
            string first_name,
            string last_name,
            string patronymic,
            string phone_number,
            string bank_card_number,
            string passport
            )
        {
            foreach (Client client in clients)
            {
                if (client.getBankAccountNumber() == bank_account_number)
                {
                    client.setFirstName(first_name);
                    client.setLastName(last_name);
                    client.setPatronymic(patronymic);
                    client.setPhoneNumber(phone_number);
                    client.setBankCardNumber(bank_card_number);
                    client.setPassport(passport);
                }
            }

            listView1.Clear();
            UpdateClientsDataInFile();
            SetupListView();
        }


        public void UpdateClientsDataFromFile()
        {
            //UpdateClientsDataInFile();

            try
            {
                clients = ClientFileReader.ReadClientsFile(fullFileName, fullDecryptFileName, sh);
                //MessageBox.Show($"{dirClientInfo + clientInfoFileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        public void UpdateClientsDataInFile()
        {
            ClientsSaver.SaveClientsToTXT(clients, dirClientInfo, clientInfoFileName, sh, true);
        }

        public void UpdateMaxClientId()
        {
            int _maxClientId = 0;
            foreach (var c in clients)
            {
                _maxClientId = int.Max(_maxClientId, c.getBankAccountNumber());
            }

            nowMaxId = int.Max(_maxClientId, nowMaxId);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedItem = listView1.SelectedItems[0];

                DialogResult deleteIs = MessageBox.Show($"Удалить клиента: {selectedItem.Text}", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (deleteIs == DialogResult.Yes)
                {

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        var num = selectedItem.SubItems[1].Text.Split(' ');
                        int selectedId = Convert.ToInt32(num[num.Length - 1]);
                        //MessageBox.Show(selectedId.ToString());
                        if (clients[i].getBankAccountNumber() == selectedId) // Удаление клиента из массива по Id
                        {
                            clients.RemoveAt(i);
                            UpdateClientsDataInFile();
                            break;
                        }
                    }
                    listView1.Items.Remove(selectedItem);
                    
                }
            }
        }

        private void buttonCreateNewClient_Click(object sender, EventArgs e)
        {
            UpdateMaxClientId();

            RedactMenuOpen();
            //buttonCreateNewClient.Enabled = false;

            Client newClient = new(nowMaxId + 1);
            nowMaxId++;

            clients.Add(newClient);

            Form2 form = new Form2(clients[clients.Count - 1], manager);
            form.Owner = this;
            form.Show();
        }
        public void RedactMenuClose()
        {
            buttonCreateNewClient.Enabled = true;
        }
        public void RedactMenuOpen()
        {
            buttonCreateNewClient.Enabled = false;
        }

        public void DebuggingInfo()
        {
            MessageBox.Show($"dirClientsInfo: {dirClientInfo}\n" +
                $"clientInfoFileName: {clientInfoFileName}" +
                $"Текущая директория: {Directory.GetCurrentDirectory().ToString()}"
                );
        }
    }
}
