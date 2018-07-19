using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioAdmin.API.Data.Dtos
{
    public class customer    //: AuditableEntity
    {
        public int id { get; set; }

        public int? associated_employee_id { get; set; }

        public int? associated_location { get; set; }

        public int? associated_customer_id { get; set; }

        public string company_name { get; set; }

        public string username { get; set; }

        public byte[] password { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string address { get; set; }

        public string address_2 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip_code { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string gate_code { get; set; }

        public sbyte bill_address_different { get; set; }

        public string bill_address { get; set; }

        public string bill_address_2 { get; set; }

        public string bill_city { get; set; }

        public string bill_state { get; set; }

        public string bill_zip_code { get; set; }

        public string phone_1_description { get; set; }

        public string phone_2_description { get; set; }

        public string phone_3_description { get; set; }

        public string phone_1_value { get; set; }

        public string phone_2_value { get; set; }

        public string phone_3_value { get; set; }

        public string phone_1_extension { get; set; }

        public string phone_2_extension { get; set; }

        public string phone_3_extension { get; set; }

        public string email_1 { get; set; }

        public string email_2 { get; set; }

        public string email_3 { get; set; }

        public string tax_id { get; set; }

        public bool is_not_export_contact { get; set; }

        public bool is_registered_to_c4 { get; set; }

        //TODO add default value = null OR make DateTime? (better)
        [Column("date_added", TypeName = "date")]
        public DateTime date_added { get; set; }

        [Column("small_note", TypeName = "varchar(255)")]
        public string small_note { get; set; }

        [Column("notes", TypeName = "text")]
        public string notes { get; set; }

        [Column("tax_id_image", TypeName = "mediumblob")]
        public byte[] tax_id_image { get; set; }

        //CURENT_TIMESTAMP()
        [Column("created_at", TypeName = "timestamp")]
        public DateTimeOffset? created_at { get; set; }

        //CURENT_TIMESTAMP ON UPDATE CURENT_TIMESTAMP()
        [Column("updated_at", TypeName = "timestamp")]
        public DateTimeOffset? updated_at { get; set; }
    }

}
