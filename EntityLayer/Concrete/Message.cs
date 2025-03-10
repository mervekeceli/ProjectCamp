﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }


        [StringLength(50)]
        public string SenderMail { get; set; } //Gönderen


        [StringLength(50)]
        public string ReceiverMail { get; set; } //Alıcı


        [StringLength(100)]
        public string Subject { get; set; }
        public string MessageContent { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime MessageDate { get; set; }
    }
}
