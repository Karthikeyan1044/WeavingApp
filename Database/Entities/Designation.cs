using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalApplication.Database.Entities
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DesignationName { get; set; }
        public bool isActive { get; set; }
    }
}
