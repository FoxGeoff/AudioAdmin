using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudioAdmin.API.Data.Entities
{
    public class ProductImage
    {
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int Id { get; set; }

        [Display(Name = "Date Updated")]
        [Column("date_updated", TypeName = "DateTime")]
        public DateTime? DateUpdated { get; set; }

        [MaxLength(50)]
        [Display(Name = "File Name")]
        [Column("file_name", TypeName = "varchar(50)")]
        public string FileName { get; set; }

        [MaxLength(50000)]
        [Display(Name = "Thumb")]
        [Column("image_thumb", TypeName = "blob")]
        public byte[] ImageThumb { get; set; }

        [MaxLength(150000)]
        [Display(Name = "Image")]
        [Column("image_full", TypeName = "mediumblob")]
        public byte[] ImageFull { get; set; }

        public string GetImageThumb()
        {
            var base64 = Convert.ToBase64String(ImageThumb);

            return String.Format("data:image/gif;base64,{0}", base64);
        }

        public string GetImageFull()
        {
            var base64 = Convert.ToBase64String(ImageFull);

            return String.Format("data:image/gif;base64,{0}", base64);
        }
    }
}
