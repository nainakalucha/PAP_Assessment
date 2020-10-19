using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
    }
}
