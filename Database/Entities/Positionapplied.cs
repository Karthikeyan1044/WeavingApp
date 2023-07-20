using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    [Table("Positionapplied")]
    public class Positionapplied
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
