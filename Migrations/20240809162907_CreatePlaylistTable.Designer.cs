﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.Data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240809162907_CreatePlaylistTable")]
    partial class CreatePlaylistTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSong", b =>
                {
                    b.Property<int>("PlaylistSongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongsId"));

                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongsId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.Property<int>("SongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongsId"));

                    b.Property<int>("AlbumsId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongsId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongsId = 1,
                            AlbumsId = 1,
                            ArtistsId = 1,
                            Duration = 90,
                            Genre = 1,
                            Title = "Tunify"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscription", b =>
                {
                    b.Property<string>("SubscriptionsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SubscriptionsPrice")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionsType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionsId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UsersId = 1,
                            Email = "Noorablonne@gmail.com",
                            JoinDate = "2024",
                            SubscriptionId = 1,
                            UserName = "Noor"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}