﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEvents.Persistence;

namespace ProEvents.Persistence.Migrations
{
    [DbContext(typeof(ProEventsContext))]
    [Migration("20220901101805_dbConfiguration")]
    partial class dbConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProEventos.Domain.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ProEventos.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeopleAmount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Theme")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ProEventos.Domain.Panelist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Panelists");
                });

            modelBuilder.Entity("ProEventos.Domain.PanelistEvent", b =>
                {
                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PanelistId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId", "PanelistId");

                    b.HasIndex("PanelistId");

                    b.ToTable("PanelistEvents");
                });

            modelBuilder.Entity("ProEventos.Domain.SocialMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PanelistId")
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PanelistId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("ProEventos.Domain.Event", b =>
                {
                    b.HasOne("ProEventos.Domain.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("ProEventos.Domain.Panelist", b =>
                {
                    b.HasOne("ProEventos.Domain.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("ProEventos.Domain.PanelistEvent", b =>
                {
                    b.HasOne("ProEventos.Domain.Event", "Event")
                        .WithMany("PanelistEvent")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Panelist", "Panelist")
                        .WithMany("PanelistEvent")
                        .HasForeignKey("PanelistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Panelist");
                });

            modelBuilder.Entity("ProEventos.Domain.SocialMedia", b =>
                {
                    b.HasOne("ProEventos.Domain.Event", "Event")
                        .WithMany("SocialMedia")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Panelist", "Panelist")
                        .WithMany("SocialMedial")
                        .HasForeignKey("PanelistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Panelist");
                });

            modelBuilder.Entity("ProEventos.Domain.Event", b =>
                {
                    b.Navigation("PanelistEvent");

                    b.Navigation("SocialMedia");
                });

            modelBuilder.Entity("ProEventos.Domain.Panelist", b =>
                {
                    b.Navigation("PanelistEvent");

                    b.Navigation("SocialMedial");
                });
#pragma warning restore 612, 618
        }
    }
}
