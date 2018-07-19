using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioAdmin.API.Data.Entities
{
    public class Customer    //: AuditableEntity
    {
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }

        [Column("associated_employee_id", TypeName = "int(10)")]
        public int? AssociatedEmployeeId { get; set; }

        [Column("associated_location", TypeName = "int(10)")]
        public int? AssociatedLocation { get; set; }

        [Column("associated_customer_id", TypeName = "int(10)")]
        public int? AssociatedCustomerId { get; set; }

        [Column("company_name", TypeName = "varchar(256)")]
        public string CompanyName { get; set; }

        [Column("username", TypeName = "varchar(75)")]
        public string Username { get; set; }

        [Column("password", TypeName = "blob")]
        public byte[] Password { get; set; }

        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column("address", TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Column("address_2", TypeName = "varchar(50)")]
        public string Address2 { get; set; }

        [Column("city", TypeName = "varchar(75)")]
        public string City { get; set; }

        [Column("state", TypeName = "char(2)")]
        public string State { get; set; }

        [Column("zip_code", TypeName = "varchar(5)")]
        public string ZipCode { get; set; }

        [Column("latitude", TypeName = "varchar(12)")]
        public string Latitude { get; set; }

        [Column("longitude", TypeName = "varchar(12)")]
        public string Longitude { get; set; }

        [Column("gate_code", TypeName = "varchar(25)")]
        public string GateCode { get; set; }

        [Column("bill_address_different", TypeName = "tinyint(4)")]
        public sbyte BillAddressDifferent { get; set; }

        [Column("bill_address", TypeName = "varchar(100)")]
        public string BillAddress { get; set; }

        [Column("bill_address_2", TypeName = "varchar(50)")]
        public string BillAddress2 { get; set; }

        [Column("bill_city", TypeName = "varchar(75)")]
        public string BillCity { get; set; }

        [Column("bill_state", TypeName = "char(2)")]
        public string BillState { get; set; }

        [Column("bill_zip_code", TypeName = "varchar(5)")]
        public string BillZipCode { get; set; }

        [Column("phone_1_description", TypeName = "varchar(25)")]
        public string Phone1Description { get; set; }

        [Column("phone_2_description", TypeName = "varchar(25)")]
        public string Phone2Description { get; set; }

        [Column("phone_3_description", TypeName = "varchar(25)")]
        public string Phone3Description { get; set; }

        [Column("phone_1_value", TypeName = "varchar(14)")]
        public string Phone1Value { get; set; }

        [Column("phone_2_value", TypeName = "varchar(14)")]
        public string Phone2Value { get; set; }

        [Column("phone_3_value", TypeName = "varchar(14)")]
        public string Phone3Value { get; set; }

        [Column("phone_1_extension", TypeName = "varchar(5)")]
        public string Phone1Extension { get; set; }

        [Column("phone_2_extension", TypeName = "varchar(5)")]
        public string Phone2Extension { get; set; }

        [Column("phone_3_extension", TypeName = "varchar(5)")]
        public string Phone3Extension { get; set; }

        [Column("email_1", TypeName = "varchar(75)")]
        public string Email1 { get; set; }

        [Column("email_2", TypeName = "varchar(75)")]
        public string Email2 { get; set; }

        [Column("email_3", TypeName = "varchar(75)")]
        public string Email3 { get; set; }

        [Column("tax_id", TypeName = "varchar(20)")]
        public string TaxId { get; set; }

        [Column("is_not_export_contact", TypeName = "tinyint(1)")]
        public bool IsNotExportedContact { get; set; }

        [Column("is_registered_to_c4", TypeName = "tinyint(1)")]
        public bool IsRegisteredToC4 { get; set; }

        //TODO add default value = null OR make DateTime? (better)
        [Column("date_added", TypeName = "date")]
        public DateTime DateAdded { get; set; }

        [Column("small_note", TypeName = "varchar(255)")]
        public string SmallNote { get; set; }

        [Column("notes", TypeName = "text")]
        public string Notes { get; set; }

        [Column("tax_id_image", TypeName = "mediumblob")]
        public byte[] TaxIdImage { get; set; }

        //CURENT_TIMESTAMP()
        [Column("created_at", TypeName = "timestamp")] 
        public DateTimeOffset? CreatedAt { get; set; }

        //CURENT_TIMESTAMP ON UPDATE CURENT_TIMESTAMP()
        [Column("updated_at", TypeName = "timestamp")]
        public DateTimeOffset? UpdatedAt { get; set; }
     }
}
