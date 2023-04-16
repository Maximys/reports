using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Benchmarking.BenchmarkEnvironments.WithDatabaseData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Int32 = table.Column<int>(type: "integer", nullable: false),
                    Int64 = table.Column<long>(type: "bigint", nullable: false),
                    NullInt = table.Column<int>(type: "integer", nullable: true),
                    Floatn = table.Column<float>(type: "real", nullable: false),
                    Doublen = table.Column<double>(type: "double precision", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Foo1Id = table.Column<long>(type: "bigint", nullable: true),
                    IntArr = table.Column<List<int>>(type: "integer[]", nullable: true),
                    Ints = table.Column<List<int>>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InnerFoo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Int32 = table.Column<int>(type: "integer", nullable: false),
                    Int64 = table.Column<long>(type: "bigint", nullable: false),
                    NullInt = table.Column<int>(type: "integer", nullable: true),
                    FooId = table.Column<long>(type: "bigint", nullable: true),
                    FooId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerFoo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnerFoo_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InnerFoo_Foos_FooId1",
                        column: x => x.FooId1,
                        principalTable: "Foos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foos_Foo1Id",
                table: "Foos",
                column: "Foo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_InnerFoo_FooId",
                table: "InnerFoo",
                column: "FooId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerFoo_FooId1",
                table: "InnerFoo",
                column: "FooId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Foos_InnerFoo_Foo1Id",
                table: "Foos",
                column: "Foo1Id",
                principalTable: "InnerFoo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foos_InnerFoo_Foo1Id",
                table: "Foos");

            migrationBuilder.DropTable(
                name: "InnerFoo");

            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
