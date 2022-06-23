using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hotel.Services;
using Hotel.Models;
using System.Data.Entity.Validation;

namespace Hotel
{
    public partial class MainForm : Form
    {
        HotelContext db; 

        public MainForm(HotelContext context)
        {
            db = context;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateGuestsList();
            UpdateApartsStatus();
            ShowAparts();
        }

        public void UpdateGuestsList()
        {
            var guests = db.Guests.ToList();
            foreach (var guest in guests)
            {
                if (DateTime.Now.Date > guest.CheckOutDate)
                    db.Guests.Remove(guest);
            }
            db.SaveChanges();
        }

        public void UpdateApartsStatus()
        {
            var orderDates = db.OrderDates.ToList();
            var apartments = db.Apartments.ToList();
            foreach (var apart in apartments)
            {
                var orders = orderDates.Where(x => x.Apartment.ID == apart.ID);
                bool isChanged = false;
                foreach (var order in orders)
                {
                    if(DateTime.Now.Date > order.CheckOut.Date)
                    {
                        db.OrderDates.Remove(db.OrderDates.Where(x => x.Id == order.Id).FirstOrDefault());
                    }
                    else if (DateTime.Now.Date >= order.CheckIn.Date && 
                        DateTime.Now.Date <= order.CheckOut.Date)
                    {
                        db.Apartments
                            .Where(x => x.ID == apart.ID)
                            .FirstOrDefault()
                            .IsEmpty = false;
                        isChanged = true;
                        break;
                    }
                }
                if(!isChanged)
                {
                    db.Apartments
                        .Where(x => x.ID == apart.ID)
                        .FirstOrDefault()
                        .IsEmpty = true;
                }
            }
            db.SaveChanges();
        }

        public void ShowAparts()
        {
            singleApartsPanel.Controls.Clear();
            doubleApartsPanel.Controls.Clear();
            tripleApartsPanel.Controls.Clear();
            vipApartsPanel.Controls.Clear();
            foreach (var ap in db.Apartments)
            {
                var btn = new Button
                {
                    Text = $"{ap.Number} номер",
                    BackColor = ap.IsEmpty ? Color.Green : Color.Tomato,
                    Name = $"buttonRoom-{ap.Number}"
                };
                btn.Click += RoomButton_Click;
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
                    case 4:
                        vipApartsPanel.Controls.Add(btn);
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

        private void reservedApartsMenuItem_Click(object sender, EventArgs e)
        {
            var reservationsForm = new ReservationsForm(db);
            reservationsForm.ShowDialog();
        }

        private void finishDayMenuItem_Click(object sender, EventArgs e)
        {
            var reservations = db.Reservations.ToList();
            var aparts = db.Apartments.ToList();
            while(reservations.Any())
            {
                var currentReservation = reservations.First();
                var currentApart = aparts.FirstOrDefault(x => x.Number == currentReservation.LiveApartment.Number);
                var reservationsOnCurrentApart = reservations
                    .Where(x => x.LiveApartment.Number == currentApart.Number).ToList();
                var resGroups = reservationsOnCurrentApart
                    .GroupBy(x => x.CheckInDate)
                    .OrderBy(x => x.Key).ToList();
                Reservation lastAddedOrderToCurrentApart = null;
                foreach (var group in resGroups)
                {
                    var maxPeriod = group
                        .Select(r => r.CheckOutDate - r.CheckInDate)
                        .Max();
                    var reservationsWithMaxPeriod = group
                        .Where(r => r.CheckOutDate - r.CheckInDate == maxPeriod).ToList();
                    if(reservationsWithMaxPeriod.Count() > 1)
                    {
                        var earlestRequestDate = reservationsWithMaxPeriod
                            .Select(r => r.DateOfRequest)
                            .Min();
                        var reservationWithEarlestRequestDate = reservationsWithMaxPeriod
                            .Where(r => r.DateOfRequest == earlestRequestDate)
                            .FirstOrDefault();
                        if(lastAddedOrderToCurrentApart != null && 
                            reservationWithEarlestRequestDate.CheckInDate <= lastAddedOrderToCurrentApart.CheckOutDate)
                        {
                            continue;
                        }
                        lastAddedOrderToCurrentApart = reservationWithEarlestRequestDate;
                        int number = reservationWithEarlestRequestDate.LiveApartment.Number;
                        reservations
                            .RemoveAll(r => r.LiveApartment.Number == reservationWithEarlestRequestDate.LiveApartment.Number);
                        ReserveApart(reservationWithEarlestRequestDate); ///после этого reservationWithEarlestRequestDate.LiveApartment становится null
                        db.Reservations.RemoveRange(db.Reservations.Where(x => x.LiveApartment.Number == number).AsEnumerable());
                        db.SaveChanges();
                    }
                    else
                    {
                        var reservation = reservationsWithMaxPeriod.FirstOrDefault();
                        if (lastAddedOrderToCurrentApart != null &&
                            reservation.CheckInDate <= lastAddedOrderToCurrentApart.CheckOutDate)
                        {
                            continue;
                        }
                        lastAddedOrderToCurrentApart = reservation;
                        int number = reservation.LiveApartment.Number;
                        reservations
                            .RemoveAll(r => r.LiveApartment.Number == reservation.LiveApartment.Number);
                        ReserveApart(reservation); ///после этого reservation.LiveApartment становится null
                        db.Reservations.RemoveRange(db.Reservations.Where(x => x.LiveApartment.Number == number).AsEnumerable());
                        db.SaveChanges();
                    }
                }
            }
            UpdateApartsStatus();
            ShowAparts();
        }

        private void ReserveApart(Reservation res)
        {
            var apartment = db.Apartments.Where(x => x.Number == res.LiveApartment.Number)
                .FirstOrDefault();
            var newGuest = new Guest()
            {
                Name = res.Name,
                Surname = res.Surname,
                Phone = res.Phone,
                CheckInDate = res.CheckInDate,
                CheckOutDate = res.CheckOutDate,
                LiveApartment = apartment
            };
            db.Guests.Add(newGuest);          
            db.Reservations.Remove(db.Reservations.Where(x => x.Id == res.Id).FirstOrDefault());
            var newOrder = new OrderDate()
            {
                CheckIn = res.CheckInDate.Date,
                CheckOut = res.CheckOutDate.Date,
                Apartment = apartment
            };
            db.OrderDates.Add(newOrder);
            //try
            //{
            db.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    var fileWriter = new StreamWriter("mylog.txt");
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        fileWriter.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            fileWriter.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //}
            UpdateApartsStatus();
        }

        private void RoomButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var number = int.Parse(btn.Name.Split('-')[1]);
            var numberInfoForm = new NumberInfoForm(db, number);
            numberInfoForm.ShowDialog();
        }
    }
}
