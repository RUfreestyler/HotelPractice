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
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowAparts();
        }

        public void ShowAparts()
        {
            singleApartsPanel.Controls.Clear();
            doubleApartsPanel.Controls.Clear();
            tripleApartsPanel.Controls.Clear();
            foreach (var ap in db.Apartments)
            {
                var btn = new Button
                {
                    Text = $"{ap.Number} номер",
                    BackColor = ap.IsEmpty ? Color.Green : Color.Tomato,
                    Name = $"buttonRoom{ap.Number}"
                };
                switch (ap.Capacity)
                {
                    case 1:
                        singleApartsPanel.Controls.Add(btn);
                        break;
                    case 2:
                        doubleApartsPanel.Controls.Add(btn);
                        break;
                    case 3:
                        tripleApartsPanel.Controls.Add(btn);
                        break;
                    default:
                        break;
                }
            }
        }

        private void reserveApartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reserveForm = new ReserveForm(db, this);
            reserveForm.ShowDialog();
        }
    }
}
