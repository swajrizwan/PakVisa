using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PakVisa.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Catalog",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "VisaType",
                schema: "Catalog",
                columns: table => new
                {
                    VisaTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaType", x => x.VisaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Userlogin",
                schema: "Users",
                columns: table => new
                {
                    UserloginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    IsUserAdmin = table.Column<bool>(nullable: false),
                    IsUserClient = table.Column<bool>(nullable: false),
                    IsUserVisitor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userlogin", x => x.UserloginId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Catalog",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 40, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                schema: "Catalog",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    IATALicense = table.Column<byte[]>(nullable: true),
                    DTSLicense = table.Column<byte[]>(nullable: true),
                    NTNCertificate = table.Column<byte[]>(nullable: true),
                    CNICPassport = table.Column<byte[]>(nullable: true),
                    Phone = table.Column<double>(nullable: false),
                    Phone2 = table.Column<double>(nullable: false),
                    Landline = table.Column<double>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Agreement = table.Column<byte[]>(nullable: true),
                    Fax = table.Column<double>(nullable: false),
                    IsRestrict = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserloginId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.FranchiseId);
                    table.ForeignKey(
                        name: "FK_Franchise_Userlogin_UserloginId",
                        column: x => x.UserloginId,
                        principalSchema: "Users",
                        principalTable: "Userlogin",
                        principalColumn: "UserloginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                schema: "Catalog",
                columns: table => new
                {
                    AdvertismentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainImage = table.Column<byte[]>(nullable: false),
                    Image2 = table.Column<byte[]>(nullable: true),
                    Image3 = table.Column<byte[]>(nullable: true),
                    Image4 = table.Column<byte[]>(nullable: true),
                    Image5 = table.Column<byte[]>(nullable: true),
                    VisaTitle = table.Column<string>(nullable: false),
                    VisaTypeId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    VisaPrice = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    FranchiseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.AdvertismentId);
                    table.ForeignKey(
                        name: "FK_Advertisement_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Catalog",
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisement_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisement_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalSchema: "Catalog",
                        principalTable: "Franchise",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_VisaType_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalSchema: "Catalog",
                        principalTable: "VisaType",
                        principalColumn: "VisaTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_CityId",
                schema: "Catalog",
                table: "Advertisement",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_CountryId",
                schema: "Catalog",
                table: "Advertisement",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_FranchiseId",
                schema: "Catalog",
                table: "Advertisement",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_VisaTypeId",
                schema: "Catalog",
                table: "Advertisement",
                column: "VisaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                schema: "Catalog",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Franchise_UserloginId",
                schema: "Catalog",
                table: "Franchise",
                column: "UserloginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisement",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Franchise",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "VisaType",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Userlogin",
                schema: "Users");
        }
    }
}
