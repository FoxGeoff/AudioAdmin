﻿// <auto-generated />
using AudioAdmin.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace AudioAdmin.API.Migrations
{
    [DbContext(typeof(AudioDbContext))]
    partial class AudioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("AudioAdmin.API.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address2")
                        .HasColumnName("address_2")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("AssociatedCustomerId")
                        .HasColumnName("associated_customer_id")
                        .HasColumnType("int(10)");

                    b.Property<int?>("AssociatedEmployeeId")
                        .HasColumnName("associated_employee_id")
                        .HasColumnType("int(10)");

                    b.Property<int?>("AssociatedLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("associated_location")
                        .HasColumnType("int(10)")
                        .HasDefaultValueSql("1");

                    b.Property<string>("BillAddress")
                        .HasColumnName("bill_address")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BillAddress2")
                        .HasColumnName("bill_address_2")
                        .HasColumnType("varchar(50)");

                    b.Property<sbyte>("BillAddressDifferent")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bill_address_different")
                        .HasColumnType("tinyint(4)")
                        .HasDefaultValueSql("0");

                    b.Property<string>("BillCity")
                        .HasColumnName("bill_city")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("BillState")
                        .HasColumnName("bill_state")
                        .HasColumnType("char(2)");

                    b.Property<string>("BillZipCode")
                        .HasColumnName("bill_zip_code")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("CompanyName")
                        .HasColumnName("company_name")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP()");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnName("date_added")
                        .HasColumnType("date");

                    b.Property<string>("Email1")
                        .HasColumnName("email_1")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Email2")
                        .HasColumnName("email_2")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Email3")
                        .HasColumnName("email_3")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GateCode")
                        .HasColumnName("gate_code")
                        .HasColumnType("varchar(25)");

                    b.Property<bool>("IsNotExportedContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_not_export_contact")
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsRegisteredToC4")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("is_registered_to_c4")
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Longitude")
                        .HasColumnName("longitude")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("text");

                    b.Property<byte[]>("Password")
                        .HasColumnName("password")
                        .HasColumnType("blob");

                    b.Property<string>("Phone1Description")
                        .HasColumnName("phone_1_description")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Phone1Extension")
                        .HasColumnName("phone_1_extension")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Phone1Value")
                        .HasColumnName("phone_1_value")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Phone2Description")
                        .HasColumnName("phone_2_description")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Phone2Extension")
                        .HasColumnName("phone_2_extension")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Phone2Value")
                        .HasColumnName("phone_2_value")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Phone3Description")
                        .HasColumnName("phone_3_description")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Phone3Extension")
                        .HasColumnName("phone_3_extension")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Phone3Value")
                        .HasColumnName("phone_3_value")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("SmallNote")
                        .HasColumnName("small_note")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("char(2)");

                    b.Property<string>("TaxId")
                        .HasColumnName("tax_id")
                        .HasColumnType("varchar(20)");

                    b.Property<byte[]>("TaxIdImage")
                        .HasColumnName("tax_id_image")
                        .HasColumnType("mediumblob");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("updated_at")
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP()");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("varchar(75)");

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AudioAdmin.API.Data.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnName("date_updated")
                        .HasColumnType("DateTime");

                    b.Property<string>("FileName")
                        .HasColumnName("file_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("ImageFull")
                        .HasColumnName("image_full")
                        .HasColumnType("mediumblob")
                        .HasMaxLength(16777215);

                    b.Property<byte[]>("ImageThumb")
                        .HasColumnName("image_thumb")
                        .HasColumnType("blob")
                        .HasMaxLength(65535);

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
