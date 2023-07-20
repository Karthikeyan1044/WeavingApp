using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalApplication.Database.Entities
{
    [Table("EmployeeManagement")]
    public class EmployeeManagement
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Item { get; set; }
        public string Color { get; set; }
        public int NativeId { get; set; }
        public int StreetId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
        public bool isActive { get; set; }
    }
}
