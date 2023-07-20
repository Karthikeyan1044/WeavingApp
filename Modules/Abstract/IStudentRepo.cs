using InternalApplication.Modules.Viewmodel;
using Module.StudentViewModule;
using System.Threading.Tasks;

namespace Module.Abstract
{
    public interface IStudentRepo
    {
        Task<MessageViewModel> GetAllStudent();
        Task<MessageViewModel> GetDepartment();
        Task<MessageViewModel> GetGender();
        Task<MessageViewModel> GetPositionapplied();
        Task<MessageViewModel> InsertStudentDetails(ViewModel listData);
        Task<MessageViewModel> AddUserData(UserSignVeiwmodel Data);
        responceViewModel UserLogin(UserSignVeiwmodel Data);
        Task<MessageViewModel> InsertUserDetails(ViewModel listData);
        Task<MessageViewModel> DeleteStudent(int id);
        Task<MessageViewModel> EditStudent(ViewModel Data);
        Task<MessageViewModel> UpdateToken(UserSignVeiwmodel Data);
        Task<MessageViewModel> ForgotToken(ForgotPasswordVeiwModel Data);
        Task<MessageViewModel> insertOrUpdateDetails(ViewModel data);
        Task<MessageViewModel> ResetPassword(UserSignVeiwmodel data);
        Task<MessageViewModel> UserForgotPassword(ForgotPasswordVeiwModel data);
        Task<MessageViewModel> ProcessSalesDataMigration();

        #region EmployeeMAnagement
        Task<MessageViewModel> GetStreetDetails(int id);
        Task<MessageViewModel> GetNativeDetails();
        Task<MessageViewModel> GetAllEmployees();
        Task<MessageViewModel> insertOrUpdateEmployeeDetails(EmployeeManagementViewModel listData);
        Task<MessageViewModel> DeleteEmployes(int id);

        #endregion

    }
}
