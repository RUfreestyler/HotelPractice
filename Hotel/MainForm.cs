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
                var orders = orderDates.Where(x => x.Number == apart.Number);
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
                var currentApart = aparts.FirstOrDefault(x => x.Number == currentReservation.Number);
                var reservationsOnCurrentApart = reservations
                    .Where(x => x.Number == currentApart.Number).ToList();
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
                        var ordersToCurrentApart = db.OrderDates.Where(x => x.Number == currentApart.Number).ToList();
                        bool isSuitable = true;
                        foreach (var order in ordersToCurrentApart)
                        {
                            if(reservationWithEarlestRequestDate.CheckInDate >= order.CheckIn && 
                                reservationWithEarlestRequestDate.CheckInDate <= order.CheckOut ||
                                reservationWithEarlestRequestDate.CheckOutDate >= order.CheckIn &&
                                reservationWithEarlestRequestDate.CheckOutDate <= order.CheckOut)
                            {
                                isSuitable = false;
                                break;
                            }
                        }
                        if(lastAddedOrderToCurrentApart != null && 
                            reservationWithEarlestRequestDate.CheckInDate <= lastAddedOrderToCurrentApart.CheckOutDate || 
                            !isSuitable)
                        {
                            foreach (var res in group)
                            {
                                reservations.RemoveAll(x => x.Id == res.Id);
                            }
                            continue;
                        }
                        ReserveApart(reservationWithEarlestRequestDate);
                        lastAddedOrderToCurrentApart = reservationWithEarlestRequestDate;
                        foreach (var res in group)
                        {
                            reservations.RemoveAll(x => x.Id == res.Id);
                        }
                    }
                    else
                    {
                        var reservation = reservationsWithMaxPeriod.FirstOrDefault();
                        var ordersToCurrentApart = db.OrderDates.Where(x => x.Number == currentApart.Number).ToList();
                        bool isSuitable = true;
                        foreach (var order in ordersToCurrentApart)
                        {
                            if (reservation.CheckInDate >= order.CheckIn &&
                                reservation.CheckInDate <= order.CheckOut ||
                                reservation.CheckOutDate >= order.CheckIn &&
                                reservation.CheckOutDate <= order.CheckOut)
                            {
                                isSuitable = false;
                                break;
                            }
                        }
                        if (lastAddedOrderToCurrentApart != null &&
                            reservation.CheckInDate <= lastAddedOrderToCurrentApart.CheckOutDate ||
                            !isSuitable)
                        {
                            foreach (var res in group)
                            {
                                reservations.RemoveAll(x => x.Id == res.Id);
                            }
                            continue;
                        }
                        ReserveApart(reservation);
                        lastAddedOrderToCurrentApart = reservation;
                        foreach (var res in group)
                        {
                            reservations.RemoveAll(x => x.Id == res.Id);
                        }
                    }
                }
            }
            db.Reservations.RemoveRange(db.Reservations.AsEnumerable());
            db.SaveChanges();
            UpdateApartsStatus();
            ShowAparts();
        }

        private void ReserveApart(Reservation res)
        {
            var apartment = db.Apartments.Where(x => x.Number == res.Number)
                .FirstOrDefault();
            var newGuest = new Guest()
            {
                Name = res.Name,
                Surname = res.Surname,
                Phone = res.Phone,
                CheckInDate = res.CheckInDate,
                CheckOutDate = res.CheckOutDate,
                Number = apartment.Number
            };
            db.Guests.Add(newGuest);          
            var newOrder = new OrderDate()
            {
                CheckIn = res.CheckInDate.Date,
                CheckOut = res.CheckOutDate.Date,
                Number = apartment.Number
            };
            db.OrderDates.Add(newOrder);
            db.SaveChanges();
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
