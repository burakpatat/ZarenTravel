using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenBO2.Models.Zaren;

namespace ZarenBO2.Data
{
    public partial class ZarenContext : DbContext
    {
        public ZarenContext()
        {
        }

        public ZarenContext(DbContextOptions<ZarenContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenBO2.Models.Zaren.PaymentOption>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentProvider>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentReservationStatus>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentStatus>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentTransactionResponseType>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentTransactionStatus>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.PaymentTransactionType>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserToken>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.InsertToTestTable>().HasNoKey();

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserLogin>().HasKey(table => new {
                table.LoginProvider, table.ProviderKey
            });

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserRole>().HasKey(table => new {
                table.UserId, table.RoleId
            });

            builder.Entity<ZarenBO2.Models.Zaren.AutoComplete>()
              .HasOne(i => i.AutoCompleteType)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.Type)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.BookingReservation>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.BookingReservations)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.PaymentConfiguration>()
              .HasOne(i => i.Language1)
              .WithMany(i => i.PaymentConfigurations)
              .HasForeignKey(i => i.Language)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.PaymentLog>()
              .HasOne(i => i.Transaction)
              .WithMany(i => i.PaymentLogs)
              .HasForeignKey(i => i.TransactionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.TestCard>()
              .HasOne(i => i.PaymentConfiguration)
              .WithMany(i => i.TestCards)
              .HasForeignKey(i => i.PaymentConfigurationId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.TransactionDetail>()
              .HasOne(i => i.Transaction)
              .WithMany(i => i.TransactionDetails)
              .HasForeignKey(i => i.TransactionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.Transaction>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.Currency)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.Transaction>()
              .HasOne(i => i.Language1)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.Language)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.Transaction>()
              .HasOne(i => i.PaymentConfiguration)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.PaymentConfigurationId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.AspNetRoleClaim>()
              .HasOne(i => i.AspNetRole)
              .WithMany(i => i.AspNetRoleClaims)
              .HasForeignKey(i => i.RoleId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserClaim>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserClaims)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserLogin>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserLogins)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserRole>()
              .HasOne(i => i.AspNetRole)
              .WithMany(i => i.AspNetUserRoles)
              .HasForeignKey(i => i.RoleId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.AspNetUserRole>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserRoles)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenBO2.Models.Zaren.Transaction>()
              .Property(p => p.IdGuid)
              .HasDefaultValueSql(@"(newid())");

            builder.Entity<ZarenBO2.Models.Zaren.Transaction>()
              .Property(p => p.CreatedDate)
              .HasDefaultValueSql(@"(getdate())");
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenBO2.Models.Zaren.AccountLike> AccountLikes { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AutoComplete> AutoCompletes { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AutoCompleteType> AutoCompleteTypes { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.BookingReservation> BookingReservations { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.BookingTraveller> BookingTravellers { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.CommissionsForDomain> CommissionsForDomains { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.Country> Countries { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.Currency> Currencies { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.Language> Languages { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentConfiguration> PaymentConfigurations { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentLog> PaymentLogs { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PossibleQuery> PossibleQueries { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.Resource> Resources { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.TestCard> TestCards { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.TransactionDetail> TransactionDetails { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.Transaction> Transactions { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentOption> PaymentOptions { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentProvider> PaymentProviders { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentReservationStatus> PaymentReservationStatuses { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentTransactionResponseType> PaymentTransactionResponseTypes { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentTransactionStatus> PaymentTransactionStatuses { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.PaymentTransactionType> PaymentTransactionTypes { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetRoleClaim> AspNetRoleClaims { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetRole> AspNetRoles { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetUserClaim> AspNetUserClaims { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetUserLogin> AspNetUserLogins { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetUserRole> AspNetUserRoles { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetUser> AspNetUsers { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.AspNetUserToken> AspNetUserTokens { get; set; }

        public DbSet<ZarenBO2.Models.Zaren.InsertToTestTable> InsertToTestTables { get; set; }
    }
}