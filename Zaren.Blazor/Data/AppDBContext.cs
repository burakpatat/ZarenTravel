using Microsoft.EntityFrameworkCore;
using ZarenBlazorAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaren.Blazor.Model;

namespace Zaren.Blazor.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Agencies> Agencies { get; set; }
public DbSet<Boardtypelanguages> Boardtypelanguages { get; set; }
public DbSet<Boardtypes> Boardtypes { get; set; }
public DbSet<Bookingdeals> Bookingdeals { get; set; }
public DbSet<Bookingrooms> Bookingrooms { get; set; }
public DbSet<Bookings> Bookings { get; set; }
public DbSet<Buyrooms> Buyrooms { get; set; }
public DbSet<Cancelationlanguages> Cancelationlanguages { get; set; }
public DbSet<Cancellationrules> Cancellationrules { get; set; }
public DbSet<Cancellationseasons> Cancellationseasons { get; set; }
public DbSet<Cities> Cities { get; set; }
public DbSet<Contacts> Contacts { get; set; }
public DbSet<Countries> Countries { get; set; }
public DbSet<Deals> Deals { get; set; }
public DbSet<Dealtypelanguages> Dealtypelanguages { get; set; }
public DbSet<Dealtypes> Dealtypes { get; set; }
public DbSet<Facilities> Facilities { get; set; }
public DbSet<Facilitieshotels> Facilitieshotels { get; set; }
public DbSet<Facilitylanguages> Facilitylanguages { get; set; }
public DbSet<Hotelagencymarkups> Hotelagencymarkups { get; set; }
public DbSet<Hotelbuyroomallotment> Hotelbuyroomallotment { get; set; }
public DbSet<Hotelbuyrooms> Hotelbuyrooms { get; set; }
public DbSet<Hotelchains> Hotelchains { get; set; }
public DbSet<Zonescities> Zonescities { get; set; }
public DbSet<Hoteldescriptions> Hoteldescriptions { get; set; }
public DbSet<Hotelphotolanguages> Hotelphotolanguages { get; set; }
public DbSet<Hotelphotos> Hotelphotos { get; set; }
public DbSet<Hotelroomdailyprices> Hotelroomdailyprices { get; set; }
public DbSet<Hotelroomlanguages> Hotelroomlanguages { get; set; }
public DbSet<Hotelrooms> Hotelrooms { get; set; }
public DbSet<Hotels> Hotels { get; set; }
public DbSet<Hoteltypelanguages> Hoteltypelanguages { get; set; }
public DbSet<Hoteltypes> Hoteltypes { get; set; }
public DbSet<Languages> Languages { get; set; }
public DbSet<Providers> Providers { get; set; }
public DbSet<Regions> Regions { get; set; }
public DbSet<Rooms> Rooms { get; set; }
public DbSet<Zones> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Agencies>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Boardtypelanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Boardtypes>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Bookingdeals>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Bookingrooms>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Bookings>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Buyrooms>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Cancelationlanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Cancellationrules>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Cancellationseasons>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Cities>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Contacts>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Countries>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Deals>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Dealtypelanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Dealtypes>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Facilities>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Facilitieshotels>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Facilitylanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelagencymarkups>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelbuyroomallotment>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelbuyrooms>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelchains>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Zonescities>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hoteldescriptions>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelphotolanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelphotos>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelroomdailyprices>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelroomlanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotelrooms>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hotels>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hoteltypelanguages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Hoteltypes>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Languages>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Providers>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Regions>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Rooms>().HasKey(u => new {
u.Id});
modelBuilder.Entity<Zones>().HasKey(u => new {
u.Id});
            }
    }
}

