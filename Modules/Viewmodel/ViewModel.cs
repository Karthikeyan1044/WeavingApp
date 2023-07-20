using System;

namespace Module.StudentViewModule
{
    public class ViewModel
    {
        public UserSignVeiwmodel userSignVeiwmodel { get; set; }
        public ForgotPasswordVeiwModel ForgotPasswordVeiwModels { get; set; }
        public userDetailsVeiwmodel userDetailsVeiwmodel { get; set; }
        public experience experience { get; set; }
        public int id { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int deptid { get; set; }
        public int? Age { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public string NativeName { get; set; }
        public int DepartmentID { get; set; }
        public int NativeID { get; set; }

    }

    public class ForgotPasswordVeiwModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class UserSignVeiwmodel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class userDetailsVeiwmodel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GenderId { get; set; }
        public string Email { get; set; }
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
    }

    public class departments
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class experience
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public int Year { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime ProbationStartDate { get; set; }
        public DateTime ProbationEndDate { get; set; }
    }

    public class positionapplied
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Native
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isAcitve { get; set; }
    }

    public class Streets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NativeId { get; set; }
        public bool isActive { get; set; }
    }
    public class responceViewModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
