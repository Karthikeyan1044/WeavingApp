using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    [Table("StudentDetails")]
    public class StudentDetails
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int deptid { get; set; }
        public int? Age { get; set; }
        public int Native { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }

    }
}
