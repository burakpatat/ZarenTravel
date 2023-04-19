using Microsoft.EntityFrameworkCore;
using Zaren.Domain;
using Zaren.Domain.ReservationDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Data
{
    public class SanProjectDBContext : DbContext
    {
        public SanProjectDBContext(DbContextOptions<SanProjectDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<ReservationDBDTO> Reservations { get; set; }
    }
}
