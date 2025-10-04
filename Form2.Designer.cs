namespace Banking_app
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUserFirstName = new Label();
            labelUserLastName = new Label();
            labelUserPatronymic = new Label();
            labelUserPhoneNumber = new Label();
            labelUserPassport = new Label();
            labelUserBankCardNumber = new Label();
            labelUserId = new Label();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxPassport = new TextBox();
            textBoxBankCard = new TextBox();
            labelTextUserId = new Label();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // labelUserFirstName
            // 
            labelUserFirstName.AutoSize = true;
            labelUserFirstName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserFirstName.Location = new Point(35, 80);
            labelUserFirstName.Name = "labelUserFirstName";
            labelUserFirstName.Size = new Size(70, 30);
            labelUserFirstName.TabIndex = 1;
            labelUserFirstName.Text = "Имя: ";
            // 
            // labelUserLastName
            // 
            labelUserLastName.AutoSize = true;
            labelUserLastName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserLastName.Location = new Point(35, 35);
            labelUserLastName.Name = "labelUserLastName";
            labelUserLastName.Size = new Size(121, 30);
            labelUserLastName.TabIndex = 0;
            labelUserLastName.Text = "Фамилия: ";
            // 
            // labelUserPatronymic
            // 
            labelUserPatronymic.AutoSize = true;
            labelUserPatronymic.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserPatronymic.Location = new Point(35, 125);
            labelUserPatronymic.Name = "labelUserPatronymic";
            labelUserPatronymic.Size = new Size(114, 30);
            labelUserPatronymic.TabIndex = 2;
            labelUserPatronymic.Text = "Отчество:";
            // 
            // labelUserPhoneNumber
            // 
            labelUserPhoneNumber.AutoSize = true;
            labelUserPhoneNumber.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserPhoneNumber.Location = new Point(35, 170);
            labelUserPhoneNumber.Name = "labelUserPhoneNumber";
            labelUserPhoneNumber.Size = new Size(192, 30);
            labelUserPhoneNumber.TabIndex = 3;
            labelUserPhoneNumber.Text = "Номер телефона:";
            // 
            // labelUserPassport
            // 
            labelUserPassport.AutoSize = true;
            labelUserPassport.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserPassport.Location = new Point(35, 215);
            labelUserPassport.Name = "labelUserPassport";
            labelUserPassport.Size = new Size(105, 30);
            labelUserPassport.TabIndex = 4;
            labelUserPassport.Text = "Паспорт:";
            // 
            // labelUserBankCardNumber
            // 
            labelUserBankCardNumber.AutoSize = true;
            labelUserBankCardNumber.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserBankCardNumber.Location = new Point(35, 260);
            labelUserBankCardNumber.Name = "labelUserBankCardNumber";
            labelUserBankCardNumber.Size = new Size(207, 30);
            labelUserBankCardNumber.TabIndex = 5;
            labelUserBankCardNumber.Text = "Банковская карта: ";
            // 
            // labelUserId
            // 
            labelUserId.AutoSize = true;
            labelUserId.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUserId.Location = new Point(35, 305);
            labelUserId.Name = "labelUserId";
            labelUserId.Size = new Size(39, 30);
            labelUserId.TabIndex = 6;
            labelUserId.Text = "Id:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxFirstName.Location = new Point(111, 85);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(300, 25);
            textBoxFirstName.TabIndex = 8;
            textBoxFirstName.KeyPress += textBoxFirstName_KeyPress;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxLastName.Location = new Point(162, 42);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(300, 25);
            textBoxLastName.TabIndex = 7;
            textBoxLastName.KeyPress += textBoxLastName_KeyPress;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPatronymic.Location = new Point(155, 130);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(300, 25);
            textBoxPatronymic.TabIndex = 9;
            textBoxPatronymic.KeyPress += textBoxPatronymic_KeyPress;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPhoneNumber.Location = new Point(233, 175);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(300, 25);
            textBoxPhoneNumber.TabIndex = 10;
            textBoxPhoneNumber.KeyPress += textBoxPhoneNumber_KeyPress;
            // 
            // textBoxPassport
            // 
            textBoxPassport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassport.Location = new Point(146, 220);
            textBoxPassport.Name = "textBoxPassport";
            textBoxPassport.Size = new Size(300, 25);
            textBoxPassport.TabIndex = 11;
            textBoxPassport.KeyPress += textBoxPassport_KeyPress;
            // 
            // textBoxBankCard
            // 
            textBoxBankCard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBankCard.Location = new Point(248, 265);
            textBoxBankCard.Name = "textBoxBankCard";
            textBoxBankCard.Size = new Size(300, 25);
            textBoxBankCard.TabIndex = 12;
            textBoxBankCard.KeyPress += textBoxBankCard_KeyPress;
            // 
            // labelTextUserId
            // 
            labelTextUserId.AutoSize = true;
            labelTextUserId.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTextUserId.Location = new Point(80, 309);
            labelTextUserId.Name = "labelTextUserId";
            labelTextUserId.Size = new Size(28, 25);
            labelTextUserId.TabIndex = 14;
            labelTextUserId.Text = "id";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = SystemColors.ActiveCaption;
            buttonSave.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSave.Location = new Point(180, 349);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(184, 67);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 441);
            Controls.Add(buttonSave);
            Controls.Add(labelTextUserId);
            Controls.Add(textBoxBankCard);
            Controls.Add(textBoxPassport);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxPatronymic);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelUserId);
            Controls.Add(labelUserBankCardNumber);
            Controls.Add(labelUserPassport);
            Controls.Add(labelUserPhoneNumber);
            Controls.Add(labelUserPatronymic);
            Controls.Add(labelUserLastName);
            Controls.Add(labelUserFirstName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form2";
            Text = "Информация о клиенте";
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUserFirstName;
        private Label labelUserLastName;
        private Label labelUserPatronymic;
        private Label labelUserPhoneNumber;
        private Label labelUserPassport;
        private Label labelUserBankCardNumber;
        private Label labelUserId;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxPatronymic;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxPassport;
        private TextBox textBoxBankCard;
        private Label labelTextUserId;
        private Button buttonSave;
    }
}