using Microsoft.EntityFrameworkCore;
using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Data.ModelClassesMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        #region TABLES
        public DbSet<UserDetail> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<EstimateDetail> EstimateDetails { get; set; }
        public DbSet<SummaryOfReceivedOrderDetail> SummaryOfReceivedOrderDetails  { get; set; }
        public DbSet<SummaryOfReceivedMaster> SummaryOfReceivedMasters  { get; set; }

        #endregion
        #region ON MODEL CREATION 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<UserDetail>());
            new OrderDetailsMap(modelBuilder.Entity<OrderDetail>());
            new EstimateDetailsMap(modelBuilder.Entity<EstimateDetail>());
            new SummaryOfReceivedMasterMap(modelBuilder.Entity<SummaryOfReceivedMaster>());
            new SummaryOfReceivedOrderDetailMap(modelBuilder.Entity<SummaryOfReceivedOrderDetail>());

            #region COLUMN CONFIGURATION
            //modelBuilder.Entity<UserDetails>().Property(f => f.Id).ValueGeneratedOnAdd();
            #endregion

            modelBuilder.Entity<UserDetail>().HasData(
                new UserDetail
            {
                Id = 1,
                Age = 100,
                Gender = string.Empty,
                City = string.Empty,
                Name = "SuperAdmin1",
                MailId = "SuperAdmin1@POS.com",
                UserName = "SuperAdmin1",
                Password = "SuperAdmin1",
                ContactNumber = string.Empty,
                CreatedDate = DateTime.UtcNow,
            },
                new UserDetail
            {
                Id = 2,
                Age = 100,
                Gender = string.Empty,
                City = string.Empty,
                Name = "SuperAdmin2",
                MailId = "SuperAdmin2@POS.com",
                UserName = "SuperAdmin2",
                Password = "SuperAdmin2",
                CreatedDate = DateTime.UtcNow,
                ContactNumber = string.Empty,
            }
            );
        }
        
        #endregion
    }
}
