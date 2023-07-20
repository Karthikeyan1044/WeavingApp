using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalApplication.Database.Entities
{
    [Table("Street")]
    public class Street
    {
            [Key]
                public int Id { get; set; }
                public string Name { get; set; }
               public int nativeId { get; set; }
               public bool isActive { get; set; }
        }
    }

