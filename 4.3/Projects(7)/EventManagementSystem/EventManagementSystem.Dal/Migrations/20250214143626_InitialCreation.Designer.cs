﻿// <auto-generated />
using System;
using EventManagementSystem.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManagementSystem.Dal.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20250214143626_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EventId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OrganizerId")
                        .HasColumnType("bigint");

                    b.HasKey("EventId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Feedback", b =>
                {
                    b.Property<long>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FeedbackId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("FeedbackId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Payment", b =>
                {
                    b.Property<long>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.HasKey("PaymentId");

                    b.HasIndex("TicketId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TicketId"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TicketId");

                    b.HasIndex("EventId");

                    b.HasIndex("SeatNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Event", b =>
                {
                    b.HasOne("EventManagementSystem.Dal.Entities.User", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Feedback", b =>
                {
                    b.HasOne("EventManagementSystem.Dal.Entities.Event", "Event")
                        .WithMany("Feedbacks")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventManagementSystem.Dal.Entities.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Payment", b =>
                {
                    b.HasOne("EventManagementSystem.Dal.Entities.Ticket", "Ticket")
                        .WithMany("Payments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Ticket", b =>
                {
                    b.HasOne("EventManagementSystem.Dal.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventManagementSystem.Dal.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Event", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.Ticket", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("EventManagementSystem.Dal.Entities.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Feedbacks");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
