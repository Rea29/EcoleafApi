using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Common.DTO.AccountingManagementSystem;
using Common.DTO.HumanResourceManagement;
using Common.DTO.Location;
using Common.DTO.MaterialRequisitionSlip;
using Common.DTO.MaterialsInventory;
using Common.DTO.PersonalProtectiveEquipmentInventory;
using Common.DTO.ProgressReport;
using Common.DTO.ProjectMonitoringManagement;
using Common.DTO.PurchaseOrder;
using Common.DTO.SummaryExpenses;
using Common.DTO.Users;
using Common.DTO.WareHouseInventory;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using DTO.PowerToolsInventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Common.Constants.DataAnnotations.RequiredFields;

namespace EcoleafAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { } // This one
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeesDTO> Employees { get; set; }
        public DbSet<AccountingManagementSystemDTO> AccountingManagementSystem { get; set; }
        public DbSet<MaterialRequisitionSlipDTO> MaterialRequisitionSlip { get; set; }
        public DbSet<MaterialRequestItemsDTO> MaterialRequestItems { get; set; }
        public DbSet<PowerToolsInventoryDTO> PowerToolsInventory { get; set; }
        public DbSet<PersonalProtectiveEquipmentInventoryDTO> PersonalProtectiveEquipmentInventory { get; set; }
        public DbSet<MaterialsInventoryDTO> MaterialsInventory { get; set; }
        public DbSet<ProjectMonitoringManagementDTO> ProjectMonitoringManagement { get; set; }
        public DbSet<ProjectSummaryExpenseDTO> ProjectSummaryExpense { get; set; }
        public DbSet<PurchaseOrderDTO> PurchaseOrder { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<ProvincesDTO> Provinces { get; set; }
        public DbSet<CityDTO> Cities { get; set; }
        public DbSet<BarangaysDTO> Barangays { get; set; }
        public DbSet<CountryDTO> Countries { get; set; }
        public DbSet<ProjectsDTO> Projects { get; set; }
        public DbSet<ProgressReportDTO> ProgressReport { get; set; }
        public DbSet<WareHouseInventoryDTO> WareHouseInventory { get; set; }
        public DbSet<UserTokenDTO> UserToken { get; set; }
        public DbSet<UserRoleDTO> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>()
                .Ignore(a => a.NotHashPassword);   // don't want to have this in the database
            modelBuilder.Entity<EmployeesDTO>()
              .Ignore(a => a.RoleName);   // don't want to have this in the database
            modelBuilder.Entity<PersonalProtectiveEquipmentInventoryDTO>()
    .Property(p => p.LineId)
    .IsRequired(false);
            modelBuilder.Entity<MaterialRequisitionSlipDTO>().Ignore(p => p.Items);
            modelBuilder.Entity<EmployeesDTO>().Ignore(p => p.EmployeesChildren);
            modelBuilder.Entity<EmployeesDTO>().Ignore(p => p.EmployeesSiblings);
            modelBuilder.Entity<UserDTO>().Ignore(p => p.RoleName);
            modelBuilder.Entity<UserDTO>().Ignore(p => p.LineId);
            modelBuilder.Entity<UserTokenDTO>().Ignore(p => p.LineId);
            modelBuilder.Entity<UserDTO>().Ignore(p => p.UserModules);
            modelBuilder.Entity<UserDTO>()
           .HasKey(u => u.UserUID);
            modelBuilder.Entity<UserRoleDTO>()
           .HasKey(r => r.UserRoleUID); // Assuming RoleId is the key
           // modelBuilder.Entity<UserDTO>()
           //.HasMany(u => u)
           //.WithOne(r => r.User) // Assuming UserRole has a navigation property back to User
           //.HasForeignKey(r => r.UserUID); // Specify the foreign key if necessary
        }

    }

    
}
