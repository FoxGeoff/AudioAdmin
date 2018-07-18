using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioAdmin.API.Data.Dtos
{
    public class product_image
    {
        public int id { get; set; }

        public DateTime? date_updated { get; set; }
        public string file_name { get; set; }
        public byte[] image_thumb { get; set; }
        public byte[] image_full { get; set; }
    }
}
