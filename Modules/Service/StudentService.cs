using InternalApplication.Modules.Viewmodel;
using Module.Abstract;
using Module.StudentViewModule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Service
{
    public class StudentService
    {
        public class StudentSevice : IStudentService
        {
            private readonly IStudentRepo _studentRepository;

            public StudentSevice(IStudentRepo studentrep)
            {
                _studentRepository = studentrep;
            }

            /// <summary>
            /// Get All Students Details
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetAllStudent()
            {
                return await _studentRepository.GetAllStudent();
            }

            /// <summary>
            /// Get All Departments
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetDepartment()
            {
                return await _studentRepository.GetDepartment();
            }

            /// <summary>
            /// Get All Gender
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetGender()
            {
                return await _studentRepository.GetGender();
            }

            /// <summary>
            /// Update Token While Logging
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> UpdateToken(UserSignVeiwmodel Data)
            {
                return await _studentRepository.UpdateToken(Data);
            }
            /// <summary>
            /// Forgot PassWord Email Token
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> ForgotToken(ForgotPasswordVeiwModel Data)
            {
                return await _studentRepository.ForgotToken(Data);
            }

            /// <summary>
            /// Get All Position form Position Table
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetPositionapplied()
            {
                return await _studentRepository.GetPositionapplied();
            }

            /// <summary>
            /// Insert Student Details Into StudentDetails 
            /// </summary>
            /// <param name="listData"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> InsertStudentDetails(ViewModel listData)
            {
                return await _studentRepository.InsertStudentDetails(listData);
            }

            /// <summary>
            /// Add User Data Into UderDetails for Signing or Logging
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> AddUserData(UserSignVeiwmodel Data)
            {
                return await _studentRepository.AddUserData(Data);
            }

            /// <summary>
            /// User Login Method for Logging
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public responceViewModel UserLogin(UserSignVeiwmodel Data)
            {
                return _studentRepository.UserLogin(Data);
            }

            /// <summary>
            /// Insert UserDetails
            /// </summary>
            /// <param name="listData"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> InsertUserDetails(ViewModel listData)
            {
                return await _studentRepository.InsertUserDetails(listData);
            }

            /// <summary>
            /// Change IsActive Status False 
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> DeleteStudent(int id)
            {
                return await _studentRepository.DeleteStudent(id);
            }

            /// <summary>
            /// Update Student Details From StudentDetails
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> EditStudent(ViewModel Data)
            {
                return await _studentRepository.EditStudent(Data);
            }

            /// <summary>
            /// insert Or UpdateDetails from Student Details
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> insertOrUpdateDetails(ViewModel Data)
            {
                return await _studentRepository.insertOrUpdateDetails(Data);
            }

            /// <summary>
            /// Reset Password
            /// </summary>
            /// <param name="Data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> ResetPassword(UserSignVeiwmodel Data)
            {
                return await _studentRepository.ResetPassword(Data);
            }

            /// <summary>
            /// User Forgot Password
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> UserForgotPassword(ForgotPasswordVeiwModel data)
            {
                return await _studentRepository.UserForgotPassword(data);
            }

            /// <summary>
            /// Process Sales DataMigration
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> ProcessSalesDataMigration()
            {
                return await _studentRepository.ProcessSalesDataMigration();
            }

            #region EmployeeManagement

            /// <summary>
            /// Get Native Details
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetNativeDetails()
            {
                return await _studentRepository.GetNativeDetails();
            }

            /// <summary>
            /// Get Streets By Native Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> GetStreetDetails(int id)
            {
                return await _studentRepository.GetStreetDetails(id);
            }

            /// <summary>
            /// Get All Employees
            /// </summary>
            /// <returns></returns>
            public async Task<MessageViewModel> GetAllEmployees()
            {
                return await _studentRepository.GetAllEmployees();
            }

            /// <summary>
            /// Add and Update Data from Employees
            /// </summary>
            /// <param name="listData"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> insertOrUpdateEmployeeDetails(EmployeeManagementViewModel listData)
            {
                return await _studentRepository.insertOrUpdateEmployeeDetails(listData);
            }

            /// <summary>
            /// Change IsActive Status from Employes Db
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<MessageViewModel> DeleteEmployes(int id)
            {
                return await _studentRepository.DeleteEmployes(id);
            }

            #endregion

        }
    }
}

