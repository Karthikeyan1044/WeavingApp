using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    [Table("ForgotPassword")]
    public class ForgotPassword
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public int IsActive { get; set; }
    }
}
