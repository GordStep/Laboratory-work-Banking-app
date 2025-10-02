namespace Banking_app
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code setor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            ConsultantButton = new RadioButton();
            managerButton = new RadioButton();
            listView1 = new ListView();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ConsultantButton);
            groupBox1.Controls.Add(managerButton);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(632, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(160, 94);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сотрудники";
            // 
            // ConsultantButton
            // 
            ConsultantButton.AutoSize = true;
            ConsultantButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConsultantButton.Location = new Point(6, 53);
            ConsultantButton.Name = "ConsultantButton";
            ConsultantButton.Size = new Size(117, 25);
            ConsultantButton.TabIndex = 1;
            ConsultantButton.TabStop = true;
            ConsultantButton.Text = "Консультант";
            ConsultantButton.UseVisualStyleBackColor = true;
            ConsultantButton.CheckedChanged += radioButton_CheckedChanged;
            // 
            // managerButton
            // 
            managerButton.AutoSize = true;
            managerButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            managerButton.Location = new Point(6, 22);
            managerButton.Name = "managerButton";
            managerButton.Size = new Size(105, 25);
            managerButton.TabIndex = 0;
            managerButton.TabStop = true;
            managerButton.Text = "Менеджер";
            managerButton.UseVisualStyleBackColor = true;
            managerButton.CheckedChanged += radioButton_CheckedChanged;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(610, 420);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 441);
            Controls.Add(listView1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "Banking app";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton ConsultantButton;
        private RadioButton managerButton;
        private ListView listView1;
    }
}
