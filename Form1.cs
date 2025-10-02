using Microsoft.VisualBasic.Logging;
using System.Numerics;

namespace Banking_app
{
    public partial class MainForm : Form
    {
        Consultant consultant = new(1, "Иван", "Иванов", "Иванович");
        Manager manager = new(2, "Константин", "Константинов", "Константинович");

        bool managerNow = true;

        List<Client> clients = new List<Client>
        {
            new Client(
                bank_account_number: 100001,
                first_name: "Иван",
                last_name: "Петров",
                patronymic: "Сергеевич",
                phone_number: "+7(912)345-67-89",
                passport_number: "123456",
                passport_series: "4501",
                bank_card_number: "2200770870352830"
            ),
            new Client(
                bank_account_number: 100002,
                first_name: "Мария",
                last_name: "Иванова",
                patronymic: "Александровна",
                phone_number: "+7(923)456-78-90",
                passport_number: "654321",
                passport_series: "4502",
                bank_card_number: "5276-8800-2345-6789"
            ),
            new Client(
                bank_account_number: 100003,
                first_name: "Алексей",
                last_name: "Сидоров",
                patronymic: "Владимирович",
                phone_number: "+7(934)567-89-01",
                passport_number: "789012",
                passport_series: "4503",
                bank_card_number: "4276-8800-3456-7890"
            ),
            new Client(
                bank_account_number: 100004,
                first_name: "Екатерина",
                last_name: "Смирнова",
                patronymic: "Дмитриевна",
                phone_number: "+7(945)678-90-12",
                passport_number: "890123",
                passport_series: "4504",
                bank_card_number: "5276-8800-4567-8901"
            ),
            new Client(
                bank_account_number: 100005,
                first_name: "Дмитрий",
                last_name: "Козлов",
                patronymic: "Олегович",
                phone_number: "+7(956)789-01-23",
                passport_number: "901234",
                passport_series: "4505",
                bank_card_number: "4276-8800-5678-9012"
            )
        };

        public MainForm()
        {
            InitializeComponent();
            SetupListView();
            AttachClickEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
            listView1.View = View.Tile;
            listView1.TileSize = new Size(600, 60);

            // Добавление колонок для отображения данных
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Description", 300);

            // Добавление элементов
            for (int i = 0; i < 5; i++)
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
        }
        // работа 
        private void ListView1_DoubleClick(object? sender, EventArgs e)
        {
            if (managerNow) 
            {
                //MessageBox.Show("клик");
                var selectedItem = listView1.SelectedItems[0];

                Form2 form = new Form2(clients[selectedItem.Index], manager);
                form.Owner = this;
                form.Show();
            }
            else
            {
                var selectedItem = listView1.SelectedItems[0];
                var passport = "";
                

                var cl = clients[selectedItem.Index];

                passport = $"{consultant.getClientPassport(cl)}";
                

                MessageBox.Show(text: $"Фамилия: {consultant.getClientLastName(cl)} \n" +
                    $"Имя: {consultant.getClientFirstName(cl)} \n" +
                    $"Отчество: {consultant.getClientPatronymic(cl)} \n" +
                    $"Номер телефона: {consultant.getClientPhoneNumber(cl)} \n" +
                    $"Паспорт: {passport} \n" +
                    $"Номер банковской карты: {consultant.getClientBankCardNumber(cl)} \n" + 
                    $"Номер аккаунта: {consultant.getClientBankAccountNumber(cl)} \n",

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
            string passport_number,
            string passport_series,
            string bank_card_number
            ) {
            foreach (Client client in clients)
            {
                if (client.getBankAccountNumber() == bank_account_number)
                {
                    client.setFirstName(first_name);
                    client.setLastName(last_name);
                    client.setPatronymic(patronymic);
                    client.setPhoneNumber(phone_number);
                    client.setPassportNumber(passport_number);
                    client.setPassportSeries(passport_series);
                    client.setBankCardNumber(bank_card_number);
                }
            }

            listView1.Clear();
            SetupListView();
        }
    }
}
