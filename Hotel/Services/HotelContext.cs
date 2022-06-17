using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Services
{
    public class HotelContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public HotelContext() : base("DBConnection")
        {

        }
    }
}
