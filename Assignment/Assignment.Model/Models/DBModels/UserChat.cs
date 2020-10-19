using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    [Table("UserChat")]
    public class UserChat
    {
        [Key]
        public long Chatid { get; set; }
        public string Connectionid { get; set; }
        public string Senderid { get; set; }
        public string Receiverid { get; set; }
        public string Message { get; set; }
        public string Messagestatus { get; set; }
        public DateTime? Messagedate { get; set; }
        public bool? IsPrivate { get; set; }
    }
}
