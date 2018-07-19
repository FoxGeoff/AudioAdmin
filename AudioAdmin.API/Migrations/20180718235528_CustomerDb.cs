using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AudioAdmin.API.Migrations
{
    public partial class CustomerDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "varchar(100)", nullable: true),
                    address_2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    associated_customer_id = table.Column<int>(type: "int(10)", nullable: true),
                    associated_employee_id = table.Column<int>(type: "int(10)", nullable: true),
                    associated_location = table.Column<int>(type: "int(10)", nullable: true, defaultValueSql: "1"),
                    bill_address = table.Column<string>(type: "varchar(100)", nullable: true),
                    bill_address_2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    bill_address_different = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "0"),
                    bill_city = table.Column<string>(type: "varchar(75)", nullable: true),
                    bill_state = table.Column<string>(type: "char(2)", nullable: true),
                    bill_zip_code = table.Column<string>(type: "varchar(5)", nullable: true),
                    city = table.Column<string>(type: "varchar(75)", nullable: true),
                    company_name = table.Column<string>(type: "varchar(256)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP()"),
                    date_added = table.Column<DateTime>(type: "date", nullable: false),
                    email_1 = table.Column<string>(type: "varchar(75)", nullable: true),
                    email_2 = table.Column<string>(type: "varchar(75)", nullable: true),
                    email_3 = table.Column<string>(type: "varchar(75)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    gate_code = table.Column<string>(type: "varchar(25)", nullable: true),
                    is_not_export_contact = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "0"),
                    is_registered_to_c4 = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "0"),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    latitude = table.Column<string>(type: "varchar(12)", nullable: true),
                    longitude = table.Column<string>(type: "varchar(12)", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<byte[]>(type: "blob", nullable: true),
                    phone_1_description = table.Column<string>(type: "varchar(25)", nullable: true),
                    phone_1_extension = table.Column<string>(type: "varchar(5)", nullable: true),
                    phone_1_value = table.Column<string>(type: "varchar(14)", nullable: true),
                    phone_2_description = table.Column<string>(type: "varchar(25)", nullable: true),
                    phone_2_extension = table.Column<string>(type: "varchar(5)", nullable: true),
                    phone_2_value = table.Column<string>(type: "varchar(14)", nullable: true),
                    phone_3_description = table.Column<string>(type: "varchar(25)", nullable: true),
                    phone_3_extension = table.Column<string>(type: "varchar(5)", nullable: true),
                    phone_3_value = table.Column<string>(type: "varchar(14)", nullable: true),
                    small_note = table.Column<string>(type: "varchar(255)", nullable: true),
                    state = table.Column<string>(type: "char(2)", nullable: true),
                    tax_id = table.Column<string>(type: "varchar(20)", nullable: true),
                    tax_id_image = table.Column<byte[]>(type: "mediumblob", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP()"),
                    username = table.Column<string>(type: "varchar(75)", nullable: true),
                    zip_code = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
