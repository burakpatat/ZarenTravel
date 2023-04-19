using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Payzee.Models.Payment3;

namespace Payzee.Data
{
    public partial class Payment3Context : DbContext
    {
        public Payment3Context()
        {
        }

        public Payment3Context(DbContextOptions<Payment3Context> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Payzee.Models.Payment3.PaymentConfiguration>()
              .HasOne(i => i.Language1)
              .WithMany(i => i.PaymentConfigurations)
              .HasForeignKey(i => i.Language)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.PaymentLog>()
              .HasOne(i => i.Transaction)
              .WithMany(i => i.PaymentLogs)
              .HasForeignKey(i => i.TransactionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.Resource>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Resources)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.TestCard>()
              .HasOne(i => i.PaymentConfiguration)
              .WithMany(i => i.TestCards)
              .HasForeignKey(i => i.PaymentConfigurationId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.TransactionDetail>()
              .HasOne(i => i.Transaction)
              .WithMany(i => i.TransactionDetails)
              .HasForeignKey(i => i.TransactionId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.Transaction>()
              .HasOne(i => i.Currency1)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.Currency)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.Transaction>()
              .HasOne(i => i.Language1)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.Language)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Payzee.Models.Payment3.Transaction>()
              .HasOne(i => i.PaymentConfiguration)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.PaymentConfigurationId)
              .HasPrincipalKey(i => i.Id);
            this.OnModelBuilding(builder);
        }

        public DbSet<Payzee.Models.Payment3.Currency> Currencies { get; set; }

        public DbSet<Payzee.Models.Payment3.Language> Languages { get; set; }

        public DbSet<Payzee.Models.Payment3.PaymentConfiguration> PaymentConfigurations { get; set; }

        public DbSet<Payzee.Models.Payment3.PaymentLog> PaymentLogs { get; set; }

        public DbSet<Payzee.Models.Payment3.Resource> Resources { get; set; }

        public DbSet<Payzee.Models.Payment3.TestCard> TestCards { get; set; }

        public DbSet<Payzee.Models.Payment3.TransactionDetail> TransactionDetails { get; set; }

        public DbSet<Payzee.Models.Payment3.Transaction> Transactions { get; set; }
    }
}