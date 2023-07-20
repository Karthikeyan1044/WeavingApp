using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalApplication.Database.Entities
{
    [Table("Native")]
    public class Native
    {
      
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public bool isActive { get; set; }
    }
}
