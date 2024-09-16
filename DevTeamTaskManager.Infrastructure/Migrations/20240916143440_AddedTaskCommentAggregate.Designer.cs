﻿// <auto-generated />
using System;
using DevTeamTaskManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevTeamTaskManager.Infrastructure.Migrations
{
    [DbContext(typeof(DevTeamTaskManagerContext))]
    [Migration("20240916143440_AddedTaskCommentAggregate")]
    partial class AddedTaskCommentAggregate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.PTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReporterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.TaskComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskComments");
                });

            modelBuilder.Entity("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.PTask", b =>
                {
                    b.OwnsOne("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("PTaskId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("PTaskId");

                            b1.ToTable("Tasks");

                            b1.WithOwner()
                                .HasForeignKey("PTaskId");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.TaskComment", b =>
                {
                    b.HasOne("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.PTask", "Task")
                        .WithMany("TaskComments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.PTask", b =>
                {
                    b.Navigation("TaskComments");
                });
#pragma warning restore 612, 618
        }
    }
}
