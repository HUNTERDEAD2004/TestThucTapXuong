using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestDauVaoXuong.Migrations
{
    /// <inheritdoc />
    public partial class testdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountFe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountFpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentFacilities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentFacilities_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MajorFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentFacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorFacilities_DepartmentFacilities_DepartmentFacilityId",
                        column: x => x.DepartmentFacilityId,
                        principalTable: "DepartmentFacilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MajorFacilities_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffMajorFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MajorFacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMajorFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMajorFacilities_MajorFacilities_MajorFacilityId",
                        column: x => x.MajorFacilityId,
                        principalTable: "MajorFacilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffMajorFacilities_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "CreatedDate", "LastModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440020"), "DEP001", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Department One", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440021"), "DEP002", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Department Two", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440022"), "DEP003", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Department Three", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Code", "CreatedDate", "LastModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440010"), "FAC001", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "HN", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440011"), "FAC002", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "HCM", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "Code", "CreatedDate", "LastModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440040"), "MAJ001", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Major One", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440041"), "MAJ002", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Major Two", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440042"), "MAJ003", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Major Three", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "AccountFe", "AccountFpt", "CreatedDate", "LastModifiedDate", "Name", "StaffCode", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440000"), "fe_account1@fe.edu.vn", "fpt_account1@fpt.edu.vn", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "John Wick", "ST001", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440001"), "fe_account2@fe.edu.vn", "fpt_account2@fpt.edu.vn", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Top1 Flo", "ST002", (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440002"), "fe_account3@fe.edu.vn", "fpt_account3@fpt.edu.vn", new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), "Lục Luật", "ST003", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DepartmentFacilities",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "FacilityId", "LastModifiedDate", "StaffId", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440030"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440020"), new Guid("550e8400-e29b-41d4-a716-446655440010"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440000"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440031"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440021"), new Guid("550e8400-e29b-41d4-a716-446655440011"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440001"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440032"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440022"), new Guid("550e8400-e29b-41d4-a716-446655440011"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440002"), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "MajorFacilities",
                columns: new[] { "Id", "CreatedDate", "DepartmentFacilityId", "LastModifiedDate", "MajorId", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440050"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440030"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440040"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440051"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440031"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440041"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440052"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440032"), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440042"), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "StaffMajorFacilities",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "MajorFacilityId", "StaffId", "Status" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440060"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440050"), new Guid("550e8400-e29b-41d4-a716-446655440000"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440061"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440051"), new Guid("550e8400-e29b-41d4-a716-446655440001"), (byte)1 },
                    { new Guid("550e8400-e29b-41d4-a716-446655440062"), new DateTime(2021, 8, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("550e8400-e29b-41d4-a716-446655440052"), new Guid("550e8400-e29b-41d4-a716-446655440002"), (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFacilities_DepartmentId",
                table: "DepartmentFacilities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFacilities_FacilityId",
                table: "DepartmentFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFacilities_StaffId",
                table: "DepartmentFacilities",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorFacilities_DepartmentFacilityId",
                table: "MajorFacilities",
                column: "DepartmentFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorFacilities_MajorId",
                table: "MajorFacilities",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMajorFacilities_MajorFacilityId",
                table: "StaffMajorFacilities",
                column: "MajorFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMajorFacilities_StaffId",
                table: "StaffMajorFacilities",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffMajorFacilities");

            migrationBuilder.DropTable(
                name: "MajorFacilities");

            migrationBuilder.DropTable(
                name: "DepartmentFacilities");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
