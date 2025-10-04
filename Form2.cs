using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Banking_app
{
    public partial class Form2 : Form
    {
        bool clientIsEdit = false;

        public Form2(object ouser, object omanager)
        {
            InitializeComponent();

            if (ouser is Client client)
            {
                selectedClient = client;
            }
            if (omanager is Manager manager)
            {
                this.manager = manager;
            }
        }

        Client selectedClient = new(1);
        Manager manager;

        private void Form2_Load(object sender, EventArgs e)
        {
            // Используем данные при загрузке формы
            TextUpdate();
        }

        private void TextUpdate()
        {
            if (selectedClient != null)
            {
                textBoxFirstName.Text = selectedClient.getFirstName();
                textBoxLastName.Text = selectedClient.getLastName();
                textBoxPatronymic.Text = selectedClient.getPatronymic();

                textBoxPhoneNumber.Text = selectedClient.getPhoneNumber();
                textBoxPassport.Text = selectedClient.getPassport();
                textBoxBankCard.Text = selectedClient.getBankCardNumber();
                labelTextUserId.Text = selectedClient.getBankAccountNumber().ToString();
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner is MainForm mainForm)
            {
                mainForm.setClientData(
                selectedClient.getBankAccountNumber(),
                selectedClient.getFirstName(),
                selectedClient.getLastName(),
                selectedClient.getPatronymic(),
                selectedClient.getPhoneNumber(),
                selectedClient.getBankCardNumber(),
                selectedClient.getPassport()
                );

                if (clientIsEdit)
                {
                    Logger.WriteLog($"Менеджер номер: {manager.getId()} ФИО: {manager.ToString()}" +
                        $" изменил данные о клиенте номер: {selectedClient.getBankAccountNumber()}\n");
                }
                else
                {
                    Logger.WriteLog($"Менеджер номер: {manager.getId()} ФИО: {manager.ToString()}" +
                        $" просматривал данные о клиенте номер: {selectedClient.getBankAccountNumber()}\n");
                }
                mainForm.UpdateClientsDataInFile();
                mainForm.UpdateClientsDataFromFile();
                mainForm.RedactMenuClose();
            }
        }

        // Обработка textBox

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setPhoneNumber(textBoxPhoneNumber.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setLastName(textBoxLastName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setFirstName(textBoxFirstName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxPatronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setPatronymic(textBoxPatronymic.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setPassport(textBoxPassport.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxBankCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Предотвращаем стандартное поведение

                try
                {
                    selectedClient.setBankCardNumber(textBoxBankCard.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                    TextUpdate();
                    return;
                }

                TextUpdate();
                clientIsEdit = true;
                // Переводим фокус на следующий элемент
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            selectedClient.setFirstName(textBoxFirstName.Text);
            selectedClient.setLastName(textBoxLastName.Text);
            selectedClient.setPatronymic(textBoxPatronymic.Text);

            try
            {
                selectedClient.setPhoneNumber(textBoxPhoneNumber.Text);
                selectedClient.setPassport(textBoxPassport.Text);
                selectedClient.setBankCardNumber(textBoxBankCard.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(text: $"{ex.Message}", "Ошибка!");
                TextUpdate();
                return;
            }
            this.Close();
        }
    }
}
