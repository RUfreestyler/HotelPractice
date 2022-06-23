using Hotel.Services;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class NumberInfoForm : Form
    {
        HotelContext db;
        int number;

        public NumberInfoForm(HotelContext context, int number)
        {
            InitializeComponent();
            db = context;
            this.number = number;
        }

        private void NumberInfoForm_Load(object sender, EventArgs e)
        {
            Text = $"{number} номер";
            var guests = db.Guests.Where(x => x.Number == number).ToList();
            foreach (var guest in guests)
            {
                infoPanel.Controls.Add(new RichTextBox() 
                { 
                    Text = $"{guest.Name} {guest.Surname} проживает\nс {guest.CheckInDate.ToString("d")} по {guest.CheckOutDate.ToString("d")}", 
                    ReadOnly = true
                });
            }          
        }
    }
}
