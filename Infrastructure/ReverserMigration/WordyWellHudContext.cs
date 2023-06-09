﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Services;
using WordyWellHero.Application.Models.Chat;
using WordyWellHero.Domain.Contracts;
using WordyWellHero.Domain.Entities.ExtendedAttributes;
using WordyWellHero.Domain.Entities.Misc;
using WordyWellHero.Infrastructure.Models.Identity;
using WordyWellHero.Infrastructure.Contexts;

namespace WordyWellHero.Infrastructure.ReverserMigration
{
    public partial class WordyWellHudContext : AuditableContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;
        public WordyWellHudContext(DbContextOptions<WordyWellHudContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public WordyWellHudContext(DbContextOptions<WordyWellHudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountActions> AccountActions { get; set; }
        public virtual DbSet<AccountBlockedCategories> AccountBlockedCategories { get; set; }
        public virtual DbSet<AccountBlockedPosts> AccountBlockedPosts { get; set; }
        public virtual DbSet<AccountBlockedProfiles> AccountBlockedProfiles { get; set; }
        public virtual DbSet<AccountBlockedTags> AccountBlockedTags { get; set; }
        public virtual DbSet<AccountCategory> AccountCategory { get; set; }
        public virtual DbSet<AccountCoordinates> AccountCoordinates { get; set; }
        public virtual DbSet<AccountDetail> AccountDetail { get; set; }
        public virtual DbSet<AccountDevices> AccountDevices { get; set; }
        public virtual DbSet<AccountErrors> AccountErrors { get; set; }
        public virtual DbSet<AccountFollowedCategories> AccountFollowedCategories { get; set; }
        public virtual DbSet<AccountFollowedPosts> AccountFollowedPosts { get; set; }
        public virtual DbSet<AccountFollowedProfiles> AccountFollowedProfiles { get; set; }
        public virtual DbSet<AccountFollowedTags> AccountFollowedTags { get; set; }
        public virtual DbSet<AccountGoalResults> AccountGoalResults { get; set; }
        public virtual DbSet<AccountGoals> AccountGoals { get; set; }
        public virtual DbSet<AccountLikedPosts> AccountLikedPosts { get; set; }
        public virtual DbSet<AccountLogins> AccountLogins { get; set; }
        public virtual DbSet<AccountNewsletterInfo> AccountNewsletterInfo { get; set; }
        public virtual DbSet<AccountProfileEncrypted> AccountProfileEncrypted { get; set; }
        public virtual DbSet<AccountProfileInfo> AccountProfileInfo { get; set; }
        public virtual DbSet<AccountProfilePaymentInfoEncrypted> AccountProfilePaymentInfoEncrypted { get; set; }
        public virtual DbSet<AccountProfilePinned> AccountProfilePinned { get; set; }
        public virtual DbSet<AccountProfileSavedPosts> AccountProfileSavedPosts { get; set; }
        public virtual DbSet<AccountProfileStatistics> AccountProfileStatistics { get; set; }
        public virtual DbSet<AccountProfileStyle> AccountProfileStyle { get; set; }
        public virtual DbSet<AccountProfileTop10> AccountProfileTop10 { get; set; }
        public virtual DbSet<AccountSearchHistory> AccountSearchHistory { get; set; }
        public virtual DbSet<AccountTokens> AccountTokens { get; set; }
        public virtual DbSet<AccountWalletEvents> AccountWalletEvents { get; set; }
        public virtual DbSet<AccountWalletRequests> AccountWalletRequests { get; set; }
        public virtual DbSet<AccountWallets> AccountWallets { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<ActivisionCodes> ActivisionCodes { get; set; }
        public virtual DbSet<AdminIps> AdminIps { get; set; }
        public virtual DbSet<AdvertorialPositions> AdvertorialPositions { get; set; }
        public virtual DbSet<AdvertorialTypes> AdvertorialTypes { get; set; }
        public virtual DbSet<Advertorials> Advertorials { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BannedWords> BannedWords { get; set; }
        public virtual DbSet<BlockedIps> BlockedIps { get; set; }
        public virtual DbSet<BlockedTypes> BlockedTypes { get; set; }
        public virtual DbSet<ChatHistory<BlazorHeroUser>> ChatHistories { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContentAccordions> ContentAccordions { get; set; }
        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<DistributedServerCache> DistributedServerCache { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<NotificationPlans> NotificationPlans { get; set; }
        public virtual DbSet<NotificationTemplates> NotificationTemplates { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PostCategory> PostCategory { get; set; }
        public virtual DbSet<PostDetail> PostDetail { get; set; }
        public virtual DbSet<PostSelectedCategories> PostSelectedCategories { get; set; }
        public virtual DbSet<PostSelectedTags> PostSelectedTags { get; set; }
        public virtual DbSet<PostSettings> PostSettings { get; set; }
        public virtual DbSet<PostStatistics> PostStatistics { get; set; }
        public virtual DbSet<PostTypes> PostTypes { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ProcedureLog> ProcedureLog { get; set; }
        public virtual DbSet<RecordAttributes> RecordAttributes { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Smshistory> Smshistory { get; set; }
        public virtual DbSet<SocialMediaConnections> SocialMediaConnections { get; set; }
        public virtual DbSet<SqlCatchLogs> SqlCatchLogs { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TagRelations> TagRelations { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            if (_currentUserService.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WordyWellHud;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
          .SelectMany(t => t.GetProperties())
          .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChatHistory<BlazorHeroUser>>(entity =>
            {
                entity.ToTable("ChatHistory");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<BlazorHeroUser>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BlazorHeroRole>(entity =>
            {
                entity.ToTable(name: "Roles", "Identity");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            modelBuilder.Entity<BlazorHeroRoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims", "Identity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });


            modelBuilder.UseCollation("Turkish_CI_AS");

            modelBuilder.Entity<AccountActions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccountId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.EventDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountBlockedCategories>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccountId, e.CategoryId })
                    .HasName("PK_AccountBlockedCategorys");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AccountBlockedPosts>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PostId, e.AccountId })
                    .HasName("PK_AccountBlockedArticleList_13");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsBlockedAllready).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountCoordinates>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccountId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.ToView("AccountDetail");
            });

            modelBuilder.Entity<AccountFollowedCategories>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsFollowedAllReady).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountLikedPosts>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsLikedAllready).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountNewsletterInfo>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountProfileEncrypted>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountProfileEncrypted)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountProfileEncrypted_Accounts");
            });

            modelBuilder.Entity<AccountProfilePinned>(entity =>
            {
                entity.Property(e => e.IsPinnedAllready).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountProfileSavedPosts>(entity =>
            {
                entity.Property(e => e.IsSavedAllready).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AccountProfileStatistics>(entity =>
            {
                entity.Property(e => e.LastScanDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AccountWalletRequests>(entity =>
            {
                entity.Property(e => e.HasCompleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.Language).HasDefaultValueSql("('tr')");
            });

            modelBuilder.Entity<ActivisionCodes>(entity =>
            {
                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AdminIps>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<BannedWords>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BlockedIps>(entity =>
            {
                entity.Property(e => e.IsBlockedAllready).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PostDetail>(entity =>
            {
                entity.ToView("PostDetail");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Posts_primaryKeys")
                    .IsClustered(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProcedureLog>(entity =>
            {
                entity.Property(e => e.LogDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");
            });

            modelBuilder.Entity<SqlCatchLogs>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}