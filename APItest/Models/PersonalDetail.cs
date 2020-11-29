using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APItest.Models
{
    public class PersonalDetail
    {
        [Key]
        public int PId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PersonName { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string Age { get; set; }
    }
}
