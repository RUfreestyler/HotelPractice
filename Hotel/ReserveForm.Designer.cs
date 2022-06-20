namespace Hotel
{
    partial class ReserveForm
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
            this.formPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.capacityComboBox = new System.Windows.Forms.ComboBox();
            this.numberComboBox = new System.Windows.Forms.ComboBox();
            this.checkinLabel = new System.Windows.Forms.Label();
            this.checkinDatePicker = new System.Windows.Forms.DateTimePicker();
            this.checkoutLabel = new System.Windows.Forms.Label();
            this.checkoutDatePicker = new System.Windows.Forms.DateTimePicker();
            this.submitButton = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formPanel.Controls.Add(this.nameLabel);
            this.formPanel.Controls.Add(this.nameBox);
            this.formPanel.Controls.Add(this.surnameLabel);
            this.formPanel.Controls.Add(this.surnameBox);
            this.formPanel.Controls.Add(this.phoneLabel);
            this.formPanel.Controls.Add(this.phoneBox);
            this.formPanel.Controls.Add(this.capacityComboBox);
            this.formPanel.Controls.Add(this.numberComboBox);
            this.formPanel.Controls.Add(this.checkinLabel);
            this.formPanel.Controls.Add(this.checkinDatePicker);
            this.formPanel.Controls.Add(this.checkoutLabel);
            this.formPanel.Controls.Add(this.checkoutDatePicker);
            this.formPanel.Controls.Add(this.submitButton);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.formPanel.Location = new System.Drawing.Point(0, 0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);
            this.formPanel.Size = new System.Drawing.Size(258, 354);
            this.formPanel.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 10);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(13, 26);
            this.nameBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(13, 56);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(56, 13);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Фамилия";
            // 
            // surnameBox
            // 
            this.surnameBox.Location = new System.Drawing.Point(13, 72);
            this.surnameBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(100, 20);
            this.surnameBox.TabIndex = 3;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(13, 102);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(93, 13);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "Номер телефона";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(13, 118);
            this.phoneBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(100, 20);
            this.phoneBox.TabIndex = 5;
            // 
            // capacityComboBox
            // 
            this.capacityComboBox.FormattingEnabled = true;
            this.capacityComboBox.Location = new System.Drawing.Point(13, 151);
            this.capacityComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.capacityComboBox.Name = "capacityComboBox";
            this.capacityComboBox.Size = new System.Drawing.Size(121, 21);
            this.capacityComboBox.TabIndex = 11;
            this.capacityComboBox.Text = "Тип номера";
            this.capacityComboBox.SelectionChangeCommitted += new System.EventHandler(this.capacityComboBox_SelectionChangeCommitted);
            // 
            // numberComboBox
            // 
            this.numberComboBox.FormattingEnabled = true;
            this.numberComboBox.Location = new System.Drawing.Point(13, 185);
            this.numberComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numberComboBox.Name = "numberComboBox";
            this.numberComboBox.Size = new System.Drawing.Size(121, 21);
            this.numberComboBox.TabIndex = 12;
            this.numberComboBox.Text = "Номер";
            // 
            // checkinLabel
            // 
            this.checkinLabel.AutoSize = true;
            this.checkinLabel.Location = new System.Drawing.Point(13, 216);
            this.checkinLabel.Name = "checkinLabel";
            this.checkinLabel.Size = new System.Drawing.Size(72, 13);
            this.checkinLabel.TabIndex = 7;
            this.checkinLabel.Text = "Дата заезда";
            // 
            // checkinDatePicker
            // 
            this.checkinDatePicker.Location = new System.Drawing.Point(13, 232);
            this.checkinDatePicker.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.checkinDatePicker.Name = "checkinDatePicker";
            this.checkinDatePicker.Size = new System.Drawing.Size(200, 20);
            this.checkinDatePicker.TabIndex = 6;
            // 
            // checkoutLabel
            // 
            this.checkoutLabel.AutoSize = true;
            this.checkoutLabel.Location = new System.Drawing.Point(13, 262);
            this.checkoutLabel.Name = "checkoutLabel";
            this.checkoutLabel.Size = new System.Drawing.Size(74, 13);
            this.checkoutLabel.TabIndex = 8;
            this.checkoutLabel.Text = "Дата выезда";
            // 
            // checkoutDatePicker
            // 
            this.checkoutDatePicker.Location = new System.Drawing.Point(13, 278);
            this.checkoutDatePicker.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.checkoutDatePicker.Name = "checkoutDatePicker";
            this.checkoutDatePicker.Size = new System.Drawing.Size(200, 20);
            this.checkoutDatePicker.TabIndex = 9;
            // 
            // submitButton
            // 
            this.submitButton.AutoSize = true;
            this.submitButton.Location = new System.Drawing.Point(13, 311);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(95, 23);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Забронировать";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // ReserveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(258, 354);
            this.Controls.Add(this.formPanel);
            this.Name = "ReserveForm";
            this.Text = "ReserveForm";
            this.Load += new System.EventHandler(this.ReserveForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel formPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label checkinLabel;
        private System.Windows.Forms.DateTimePicker checkinDatePicker;
        private System.Windows.Forms.Label checkoutLabel;
        private System.Windows.Forms.DateTimePicker checkoutDatePicker;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ComboBox capacityComboBox;
        private System.Windows.Forms.ComboBox numberComboBox;
    }
}