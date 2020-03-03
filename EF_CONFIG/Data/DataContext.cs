using EF_CONFIG.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Data
{
    public class DataContext : DbContext
    {
        public DataContext(string ConnectionString) : base(Server.DefaultConnectionString) { }
        public DataContext() : base("name=DataContext") { }

        public DbSet<ECheckItem> ECheckItem { get; set; }
        public DbSet<ECheckArea> ECheckArea { get; set; }
        public DbSet<EChecking> EChecking { get; set; }
        public DbSet<ECheckingDaily> ECheckingDaily { get; set; }
        public DbSet<CheckingPerson> CheckingPerson { get; set; }
        public DbSet<ECheckNotes> ECheckNotes { get; set; }
        public DbSet<ESubmit> ESubmit { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ECheckItem>()
                .HasMany(i => i.ECheckings)
                .WithOptional(i => i.ECheckItem)
                .HasForeignKey(k => k.ECheckItemId);

            modelBuilder.Entity<ECheckItem>()
                .HasMany(i => i.ECheckingDailys)
                .WithOptional(i => i.ECheckItem)
                .HasForeignKey(k => k.ECheckItemId);

            modelBuilder.Entity<ECheckArea>()
                .HasMany(i => i.ECheckings)
                .WithOptional(i => i.ECheckArea)
                .HasForeignKey(k => k.ECheckAreaId);

            modelBuilder.Entity<ECheckArea>()
                .HasMany(i => i.ECheckingDailys)
                .WithOptional(i => i.ECheckArea)
                .HasForeignKey(k => k.ECheckAreaId);

            modelBuilder.Entity<CheckingPerson>()
                .HasMany(i => i.ECheckingDaily)
                .WithOptional(i => i.CheckingPerson)
                .HasForeignKey(k => k.CheckingPersonId);

            modelBuilder.Entity<ECheckNotes>()
                 .HasMany(i => i.ECheckingDailys)
                 .WithOptional(i => i.ECheckNotes)
                 .HasForeignKey(k => k.ECheckNotesId);

            modelBuilder.Entity<ESubmit>()
                .HasMany(i => i.ECheckingDailys)
                .WithOptional(i => i.ESubmit)
                .HasForeignKey(i => i.ESubmitId)
                .WillCascadeOnDelete(true);
        }
    }
}
