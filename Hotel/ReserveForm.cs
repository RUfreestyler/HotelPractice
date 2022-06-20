using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.Models;
using Hotel.Services;

namespace Hotel
{
    public partial class ReserveForm : Form
    {
        HotelContext db;
        Form parent;

        public ReserveForm(HotelContext context, Form parent)
        {
            InitializeComponent();
            db = context;
            StartPosition = FormStartPosition.CenterScreen;
            this.parent = parent;
        }

        private void ReserveForm_Load(object sender, EventArgs e)
        {
            capacityComboBox.Items.AddRange(new object[] { "Одноместный", "Двуместный", "Трехместный" });
            nameBox.Focus();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameBox.Text) || 
                string.IsNullOrWhiteSpace(surnameBox.Text) || 
                string.IsNullOrWhiteSpace(phoneBox.Text))
            {
                MessageBox.Show("Поля имя, фамилия и номер телефона обязательны для заполнения", "Введены не все данные");
                return;
            }
            else if(checkinDatePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Дата заезда не может предшествовать текущей дате", "Неправильная дата заезда");
                return;
            }
            else if(checkoutDatePicker.Value.Date < checkinDatePicker.Value.Date)
            {
                MessageBox.Show("Дата выезда не может быть раньше даты заезда", "Неправильная дата выезда");
                return;
            }
            else if(capacityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали тип номера", "Не выбран тип номера");
                return;
            }
            else if(numberComboBox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали номер", "Не выбран номер");
                return;
            }
            var apNumber = int.Parse(numberComboBox.SelectedItem.ToString());
            var ap = db.Apartments
                .Where(x => x.Number == apNumber)
                .FirstOrDefault();
            ap.CheckInDate = checkinDatePicker.Value.Date;
            ap.CheckOutDate = checkoutDatePicker.Value.Date;
            ap.IsEmpty = false;
            var newGuest = new Guest()
            {
                Name = nameBox.Text,
                Surname = surnameBox.Text,
                Phone = phoneBox.Text,
                CheckInDate = checkinDatePicker.Value.Date,
                CheckOutDate = checkoutDatePicker.Value.Date,
                LiveApartment = ap
            };
            db.Guests.Add(newGuest);
            db.SaveChanges();
            if(MessageBox.Show("Номер включен в список брони", "Уведомление", MessageBoxButtons.OK) == DialogResult.OK)
            {
                Close();
            }
        }

        private void capacityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            numberComboBox.Items.Clear();
            switch (capacityComboBox.SelectedItem.ToString())
            {
                case "Одноместный":
                    var singles = db.Apartments
                        .AsEnumerable()
                        .Where(x => x.Capacity == 1)
                        .Select(x => (object)x.Number)
                        .ToArray();
                    numberComboBox.Items.AddRange(singles);
                    break;
                case "Двуместный":
                    var doubles = db.Apartments
                        .AsEnumerable()
                        .Where(x => x.Capacity == 2)
                        .Select(x => (object)x.Number)
                        .ToArray();
                    numberComboBox.Items.AddRange(doubles);
                    break;
                case "Трехместный":
                    var triples = db.Apartments
                        .AsEnumerable()
                        .Where(x => x.Capacity == 3)
                        .Select(x => (object)x.Number)
                        .ToArray();
                    numberComboBox.Items.AddRange(triples);
                    break;
                default:
                    break;
            }
        }
    }
}
