﻿// <auto-generated />
using System;
using AspNetWebApiService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetWebApiService.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210820152334_AddLibraryMigration")]
    partial class AddLibraryMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfChangeRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfInsertionRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordingVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63fd1e1a-1c7c-4aa7-94ec-a766ad202033"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Агата",
                            LastName = "Кристи"
                        },
                        new
                        {
                            Id = new Guid("4000e467-00c2-48b9-a6f7-3d62e47085e5"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Джером",
                            LastName = "Сэлинджер"
                        },
                        new
                        {
                            Id = new Guid("320749ed-9cad-4db8-ab2c-717a7ceecff2"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Евгений",
                            LastName = "Замятин",
                            MiddleName = "Иванович"
                        });
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfChangeRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfInsertionRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordingVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af175e50-dcf6-41c2-8980-91dbf41b2a8a"),
                            AuthorId = new Guid("63fd1e1a-1c7c-4aa7-94ec-a766ad202033"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Убийство в Восточном экспрессе"
                        },
                        new
                        {
                            Id = new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1"),
                            AuthorId = new Guid("4000e467-00c2-48b9-a6f7-3d62e47085e5"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Над пропастью во ржи"
                        },
                        new
                        {
                            Id = new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9"),
                            AuthorId = new Guid("320749ed-9cad-4db8-ab2c-717a7ceecff2"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Мы"
                        });
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfChangeRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfInsertionRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordingVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a19e15da-5bcb-4e82-a7c9-751328371400"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreName = "Детектив"
                        },
                        new
                        {
                            Id = new Guid("97f16109-2c66-4874-9ea1-aaba400901aa"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreName = "Роман"
                        },
                        new
                        {
                            Id = new Guid("cc3e1d21-ab13-476c-b05f-4680404dda6a"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreName = "Антиутопия"
                        });
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.LibraryCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfChangeRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfInsertionRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturnBook")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecordingVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PersonId");

                    b.ToTable("LibraryCards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("048a5961-9ff9-4634-8b03-e1463255c489"),
                            BookId = new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfReturnBook = new DateTime(2021, 8, 16, 18, 23, 33, 146, DateTimeKind.Local).AddTicks(5694),
                            PersonId = new Guid("4e626b6f-93ba-4c5f-ad53-c23b7f4f1a04")
                        },
                        new
                        {
                            Id = new Guid("b7562dfb-8749-4866-a35e-89a572d5b644"),
                            BookId = new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9"),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfReturnBook = new DateTime(2021, 8, 27, 18, 23, 33, 149, DateTimeKind.Local).AddTicks(3217),
                            PersonId = new Guid("1d65bcca-722a-4d1b-9792-c6843579208c")
                        });
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfChangeRecord")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfInsertionRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordingVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d65bcca-722a-4d1b-9792-c6843579208c"),
                            DateOfBirth = new DateTime(1990, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Иван",
                            LastName = "Иванов",
                            MiddleName = "Иванович"
                        },
                        new
                        {
                            Id = new Guid("980791e2-4183-485b-8a4b-d23830e60856"),
                            DateOfBirth = new DateTime(1995, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Сергей",
                            LastName = "Сергеев",
                            MiddleName = "Сергеевич"
                        },
                        new
                        {
                            Id = new Guid("4e626b6f-93ba-4c5f-ad53-c23b7f4f1a04"),
                            DateOfBirth = new DateTime(1999, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfInsertionRecord = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Петр",
                            LastName = "Петров",
                            MiddleName = "Петрович"
                        });
                });

            modelBuilder.Entity("Book_Genre_lnk", b =>
                {
                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenreId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Book_Genre_lnk");

                    b.HasData(
                        new
                        {
                            GenreId = new Guid("a19e15da-5bcb-4e82-a7c9-751328371400"),
                            BookId = new Guid("af175e50-dcf6-41c2-8980-91dbf41b2a8a")
                        },
                        new
                        {
                            GenreId = new Guid("97f16109-2c66-4874-9ea1-aaba400901aa"),
                            BookId = new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1")
                        },
                        new
                        {
                            GenreId = new Guid("cc3e1d21-ab13-476c-b05f-4680404dda6a"),
                            BookId = new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9")
                        });
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Book", b =>
                {
                    b.HasOne("AspNetWebApiService.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.LibraryCard", b =>
                {
                    b.HasOne("AspNetWebApiService.Data.Models.Book", null)
                        .WithMany("LibraryCards")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetWebApiService.Data.Models.Person", null)
                        .WithMany("LibraryCards")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Book_Genre_lnk", b =>
                {
                    b.HasOne("AspNetWebApiService.Data.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetWebApiService.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Book", b =>
                {
                    b.Navigation("LibraryCards");
                });

            modelBuilder.Entity("AspNetWebApiService.Data.Models.Person", b =>
                {
                    b.Navigation("LibraryCards");
                });
#pragma warning restore 612, 618
        }
    }
}
