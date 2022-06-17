using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.Services;
using Hotel.Models;

namespace Hotel
{
    public partial class MainForm : Form
    {
        private HotelContext db; 
        public MainForm(HotelContext context)
        {
            db = context;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

                for (int i = 51; i <= 60; i++)
                {
                    var apart = new Apartment()
                    {
                        Number = i,
                        Capacity = 3,
                        IsEmpty = true,
                        PricePerDay = 10000
                    };
                db.Apartments.Add(apart);
                }
                db.SaveChanges();

        }
    }
}
