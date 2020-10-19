using System;

namespace Assignment.Model
{
    public class UserChatDto
    {
        public long Chatid { get; set; }
        public string Connectionid { get; set; }
        public string Senderid { get; set; }
        public string Receiverid { get; set; }
        public string Message { get; set; }
        public string Messagestatus { get; set; }
        public DateTime? Messagedate { get; set; } = DateTime.Now;
        public bool? IsPrivate { get; set; }
    }
}
