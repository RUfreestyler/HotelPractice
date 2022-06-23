using Hotel.Models;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace Hotel
{
    public partial class ReservationsForm : Form
    {
        HotelContext db;

        public ReservationsForm(HotelContext context)
        {
            InitializeComponent();
            db = context;
        }

        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            var props = typeof(Reservation).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.GetCustomAttributes().OfType<DisplayAttribute>().Any());
            foreach (var p in props)
            {
                var attribute = p.GetCustomAttributes().OfType<DisplayAttribute>().FirstOrDefault();
                reservationsGrid.Columns.Add(p.Name, attribute.Name);
            }
            var reservations = db.Reservations.ToList();
            foreach (var res in reservations)
            {
                reservationsGrid.Rows.Add(new object[]
                {
                    res.Id,
                    res.Name,
                    res.Surname,
                    res.Phone,
                    res.CheckInDate,
                    res.CheckOutDate,
                    db.Apartments.Where(x => x.ID == res.LiveApartment.ID).FirstOrDefault().Number,
                    res.DateOfRequest
                });
            }
        }
    }
}