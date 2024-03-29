﻿// <auto-generated />
using System;
using Client.DBO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Customer.DBO.Migrations
{
    [DbContext(typeof(PrjContext))]
    partial class PrjContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Client.DBO.Models.CustomerAdresses", b =>
                {
                    b.Property<int>("IdClientAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientAddress"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("TypeAddress")
                        .HasColumnType("int");

                    b.HasKey("IdClientAddress");

                    b.HasIndex("IdClient");

                    b.ToTable("ClientAddress");
                });

            modelBuilder.Entity("Client.DBO.Models.CustomerEmails", b =>
                {
                    b.Property<int>("IdClientEmail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientEmail"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("TypeEmail")
                        .HasColumnType("int");

                    b.HasKey("IdClientEmail");

                    b.HasIndex("IdClient");

                    b.ToTable("ClientsEmail");
                });

            modelBuilder.Entity("Client.DBO.Models.CustomerPhoneNumbers", b =>
                {
                    b.Property<int>("IdPhoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPhoneNumber"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("TypePhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IdPhoneNumber");

                    b.HasIndex("IdClient");

                    b.ToTable("ClientsPhoneNumber");
                });

            modelBuilder.Entity("Client.DBO.Models.RegisteredCustomer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomer"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdCustomer");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Client.DBO.Models.CustomerAdresses", b =>
                {
                    b.HasOne("Client.DBO.Models.RegisteredCustomer", "Clients")
                        .WithMany("CustomerAdresses")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Client.DBO.Models.CustomerEmails", b =>
                {
                    b.HasOne("Client.DBO.Models.RegisteredCustomer", "Clients")
                        .WithMany("CustomerEmails")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Client.DBO.Models.CustomerPhoneNumbers", b =>
                {
                    b.HasOne("Client.DBO.Models.RegisteredCustomer", "Clients")
                        .WithMany("CustomerPhoneNumbers")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Client.DBO.Models.RegisteredCustomer", b =>
                {
                    b.Navigation("CustomerAdresses");

                    b.Navigation("CustomerEmails");

                    b.Navigation("CustomerPhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
