using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GenderId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string ContactNumber { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentState { get; set; }
        public string CurrentZipcode { get; set; }
        public string Location { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Totalexperience { get; set; }
        public int ICUexperience { get; set; }
        public int PositionappliedId { get; set; }
        public int DepartmentId { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public int Year { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime ProbationStartDate { get; set; }
        public DateTime ProbationEndDate { get; set; }
    }
}
