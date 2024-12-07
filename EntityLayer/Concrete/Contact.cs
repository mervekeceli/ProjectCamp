using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }


        [StringLength(50)]
        public string UserName { get; set; }


        [StringLength(50)]
        public string UserEmail { get; set; }


        [StringLength(50)]
        public string Subject { get; set; }
        public string Message { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime ContactDate { get; set; }
    }
}
