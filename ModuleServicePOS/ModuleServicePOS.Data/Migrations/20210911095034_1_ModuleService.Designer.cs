﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModuleServicePOS.Data;

namespace ModuleServicePOS.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210911095034_1_ModuleService")]
    partial class _1_ModuleService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.EstimateDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ItemAddDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderDetailId")
                        .HasColumnType("bigint");

                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("EstimateDetails");
                });

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.OrderDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePrepared")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PreparedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TechnicianNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.SummaryOfReceived", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderDetailId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderDetailsId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailsId");

                    b.ToTable("SummaryOfReceiveds");
                });

            modelBuilder.Entity("ModuleServicePOS.Data.UserDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 100,
                            City = "",
                            ContactNumber = "",
                            CreatedDate = new DateTime(2021, 9, 11, 9, 50, 33, 626, DateTimeKind.Utc).AddTicks(5498),
                            Gender = "",
                            MailId = "SuperAdmin1@POS.com",
                            Name = "SuperAdmin1",
                            Password = "SuperAdmin1",
                            UserName = "SuperAdmin1"
                        },
                        new
                        {
                            Id = 2L,
                            Age = 100,
                            City = "",
                            ContactNumber = "",
                            CreatedDate = new DateTime(2021, 9, 11, 9, 50, 33, 626, DateTimeKind.Utc).AddTicks(6212),
                            Gender = "",
                            MailId = "SuperAdmin2@POS.com",
                            Name = "SuperAdmin2",
                            Password = "SuperAdmin2",
                            UserName = "SuperAdmin2"
                        });
                });

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.EstimateDetails", b =>
                {
                    b.HasOne("ModuleServicePOS.Data.ModelClasses.OrderDetails", "OrderDetail")
                        .WithMany("EstimateDetail")
                        .HasForeignKey("OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.SummaryOfReceived", b =>
                {
                    b.HasOne("ModuleServicePOS.Data.ModelClasses.OrderDetails", "OrderDetails")
                        .WithMany("SummaryOfReceived")
                        .HasForeignKey("OrderDetailsId");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ModuleServicePOS.Data.ModelClasses.OrderDetails", b =>
                {
                    b.Navigation("EstimateDetail");

                    b.Navigation("SummaryOfReceived");
                });
#pragma warning restore 612, 618
        }
    }
}
