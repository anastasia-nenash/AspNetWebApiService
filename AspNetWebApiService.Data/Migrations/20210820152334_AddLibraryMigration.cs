using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetWebApiService.Data.Migrations
{
    public partial class AddLibraryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfInsertionRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChangeRecord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfInsertionRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChangeRecord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfInsertionRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChangeRecord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfInsertionRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChangeRecord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Genre_lnk",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Genre_lnk", x => new { x.GenreId, x.BookId });
                    table.ForeignKey(
                        name: "FK_Book_Genre_lnk_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Genre_lnk_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfReturnBook = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfInsertionRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChangeRecord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryCards_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryCards_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfChangeRecord", "DateOfInsertionRecord", "FirstName", "LastName", "MiddleName", "RecordingVersion" },
                values: new object[,]
                {
                    { new Guid("63fd1e1a-1c7c-4aa7-94ec-a766ad202033"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Агата", "Кристи", null, null },
                    { new Guid("4000e467-00c2-48b9-a6f7-3d62e47085e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Джером", "Сэлинджер", null, null },
                    { new Guid("320749ed-9cad-4db8-ab2c-717a7ceecff2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Евгений", "Замятин", "Иванович", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "DateOfChangeRecord", "DateOfInsertionRecord", "GenreName", "RecordingVersion" },
                values: new object[,]
                {
                    { new Guid("a19e15da-5bcb-4e82-a7c9-751328371400"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Детектив", null },
                    { new Guid("97f16109-2c66-4874-9ea1-aaba400901aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роман", null },
                    { new Guid("cc3e1d21-ab13-476c-b05f-4680404dda6a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антиутопия", null }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DateOfBirth", "DateOfChangeRecord", "DateOfInsertionRecord", "FirstName", "LastName", "MiddleName", "RecordingVersion" },
                values: new object[,]
                {
                    { new Guid("1d65bcca-722a-4d1b-9792-c6843579208c"), new DateTime(1990, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванов", "Иванович", null },
                    { new Guid("980791e2-4183-485b-8a4b-d23830e60856"), new DateTime(1995, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сергей", "Сергеев", "Сергеевич", null },
                    { new Guid("4e626b6f-93ba-4c5f-ad53-c23b7f4f1a04"), new DateTime(1999, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петр", "Петров", "Петрович", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateOfChangeRecord", "DateOfInsertionRecord", "Name", "RecordingVersion" },
                values: new object[] { new Guid("af175e50-dcf6-41c2-8980-91dbf41b2a8a"), new Guid("63fd1e1a-1c7c-4aa7-94ec-a766ad202033"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Убийство в Восточном экспрессе", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateOfChangeRecord", "DateOfInsertionRecord", "Name", "RecordingVersion" },
                values: new object[] { new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1"), new Guid("4000e467-00c2-48b9-a6f7-3d62e47085e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Над пропастью во ржи", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateOfChangeRecord", "DateOfInsertionRecord", "Name", "RecordingVersion" },
                values: new object[] { new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9"), new Guid("320749ed-9cad-4db8-ab2c-717a7ceecff2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мы", null });

            migrationBuilder.InsertData(
                table: "Book_Genre_lnk",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("af175e50-dcf6-41c2-8980-91dbf41b2a8a"), new Guid("a19e15da-5bcb-4e82-a7c9-751328371400") },
                    { new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1"), new Guid("97f16109-2c66-4874-9ea1-aaba400901aa") },
                    { new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9"), new Guid("cc3e1d21-ab13-476c-b05f-4680404dda6a") }
                });

            migrationBuilder.InsertData(
                table: "LibraryCards",
                columns: new[] { "Id", "BookId", "DateOfChangeRecord", "DateOfInsertionRecord", "DateOfReturnBook", "PersonId", "RecordingVersion" },
                values: new object[,]
                {
                    { new Guid("048a5961-9ff9-4634-8b03-e1463255c489"), new Guid("9695eb24-052f-41d7-8d30-67af02f8faa1"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 16, 18, 23, 33, 146, DateTimeKind.Local).AddTicks(5694), new Guid("4e626b6f-93ba-4c5f-ad53-c23b7f4f1a04"), null },
                    { new Guid("b7562dfb-8749-4866-a35e-89a572d5b644"), new Guid("a45fba51-a7f6-4fc5-a586-ff0ea24cc7c9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 27, 18, 23, 33, 149, DateTimeKind.Local).AddTicks(3217), new Guid("1d65bcca-722a-4d1b-9792-c6843579208c"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Genre_lnk_BookId",
                table: "Book_Genre_lnk",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_BookId",
                table: "LibraryCards",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_PersonId",
                table: "LibraryCards",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Genre_lnk");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
