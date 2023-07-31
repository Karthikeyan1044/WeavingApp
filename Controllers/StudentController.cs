using INTERNAL.APPLICATION.Controllers;
using InternalApplication;
using InternalApplication.Modules.Viewmodel;
using InternarApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Module.Abstract;
using Module.StudentViewModule;
using System;
using System.Threading.Tasks;

namespace ApiCall.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseApiController<StudentController, IStudentService>
    {
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentser, IStringLocalizer<CommonResource> commonResourceLocalizer) : base(logger, studentser, commonResourceLocalizer)
        {
            _studentService = studentser;
        }

        /// <summary>
        /// Get All Students Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            Logger.LogInformation("GetStudent : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }
            var result = await _studentService.GetAllStudent();

            Logger.LogInformation("GetStudent : Method End");

            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            // Logger.LogInformation("GetDepartment :  Method Start");
            Logger.LogInformation($"[{DateTime.Now}] GetDepartment : Method Start");

            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetDepartment();

            Logger.LogInformation("GetDepartment : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
           
        }

        /// <summary>
        /// Get All Gender
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGender()
        {
            Logger.LogInformation("GetGender :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetGender();
            Logger.LogInformation("GetGender : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Get All Position form Position Table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPositionapplied()
        {
            Logger.LogInformation("GetPositionapplied :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetPositionapplied();

            Logger.LogInformation("GetPositionapplied : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Insert Student Details Into StudentDetails 
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertStudentDetails([FromBody] ViewModel listData)
        {
            Logger.LogInformation("InsertStudentDetails : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.InsertStudentDetails(listData);

            Logger.LogInformation("InsertStudentDetails : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataInsert), result.Status, StatusCodes.Status200OK, result.Data));
            }
            if (result.MessageKey == CommonResource.DataExist)
            {
                return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataExist), result.Status, StatusCodes.Status409Conflict, null));
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotInsert), result.Status, StatusCodes.Status409Conflict, null));
            
        }

        /// <summary>
        /// Add User Data Into UderDetails for Signing or Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserData([FromBody] UserSignVeiwmodel Data)
        {
            Logger.LogInformation("AddUserData : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.AddUserData(Data);

            Logger.LogInformation("AddUserData : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataInsert), result.Status, StatusCodes.Status200OK, result.Data));
            }
            if (result.MessageKey == CommonResource.DataExist)
            {
                return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataExist), result.Status, StatusCodes.Status409Conflict, null));
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotInsert), result.Status, StatusCodes.Status409Conflict, null));
           
        }

        /// <summary>
        /// User Login Method for Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public responceViewModel UserLogin([FromBody] UserSignVeiwmodel Data)
        {
            //Logger.LogInformation("UserLogin :  Method Start");
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            //}

            var result = _studentService.UserLogin(Data);

            //Logger.LogInformation("UserLogin : Method End");
            //if (result.Status)
            //{
            //    if (result.MessageKey == CommonResource.DataNotFound)
            //    {
            //        return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
            //    }
            //    else
            //    {
            //        return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
            //    }
            //}

            //return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
            return result;
        }

        /// <summary>
        /// Insert UserDetails
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertUserDetails([FromBody] ViewModel listData)
        {
            Logger.LogInformation("InsertUserDetails : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.InsertUserDetails(listData);

            Logger.LogInformation("InsertUserDetails : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataInsert), result.Status, StatusCodes.Status200OK, result.Data));
            }
            if (result.MessageKey == CommonResource.DataExist)
            {
                return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataExist), result.Status, StatusCodes.Status409Conflict, null));
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotInsert), result.Status, StatusCodes.Status409Conflict, null));
           
        }

        /// <summary>
        /// Change IsActive Status False 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Logger.LogInformation("GetCustomerDetailsByCustomercode : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }
            var result = await _studentService.DeleteStudent(id);
            Logger.LogInformation("DeleteByDepositDetails : Method End");

            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataDelete), true, StatusCodes.Status200OK, result.Data));
            }
            else
            {

                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return NotFound(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), false, StatusCodes.Status404NotFound, null));
                }

                return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotDelete), false, StatusCodes.Status409Conflict, null));
            }
        }

        /// <summary>
        /// Update Student Details From StudentDetails
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditStudent([FromBody] ViewModel Data)
        {
            Logger.LogInformation("EditStudent : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.EditStudent(Data);

            Logger.LogInformation("EditStudent : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataUpdate), true, StatusCodes.Status200OK, result.Data));
            }
            if (result.MessageKey == CommonResource.DataNotFound)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), result.Status, StatusCodes.Status204NoContent, null));
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotUpdate), result.Status, StatusCodes.Status409Conflict, null));
          
        }

        /// <summary>
        /// Update Token While Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateToken(UserSignVeiwmodel Data)
        {
            Logger.LogInformation("UpdateToken :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.UpdateToken(Data);

            Logger.LogInformation("UpdateToken : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
            
        }

        /// <summary>
        /// Forgot PassWord Email Token
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> ForgotToken(ForgotPasswordVeiwModel Data)
        {
            Logger.LogInformation("ForgotToken :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.ForgotToken(Data);
            Logger.LogInformation("ForgotToken : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
            
        }

        /// <summary>
        /// insert Or UpdateDetails from Student Details
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> insertOrUpdateDetails([FromBody] ViewModel Data)
        {
            Logger.LogInformation("insert Or Update Details : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.insertOrUpdateDetails(Data);

            Logger.LogInformation("insert Or Update Details : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataInsert), result.Status, StatusCodes.Status200OK, result.Data));
            }
            else
            {
                return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotInsert), result.Status, StatusCodes.Status409Conflict, null));
            }
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] UserSignVeiwmodel Data)
        {
            Logger.LogInformation("ResetPassword :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.ResetPassword(Data);

            Logger.LogInformation("ResetPassword : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
           
        }

        /// <summary>
        /// User Forgot Password
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserForgotPassword([FromBody] ForgotPasswordVeiwModel Data)
        {
            Logger.LogInformation("UserForgotPassword :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.UserForgotPassword(Data);
            Logger.LogInformation("UserForgotPassword : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
           
        }

        /// <summary>
        /// Process Sales DataMigration
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ProcessSalesDataMigration()
        {
            Logger.LogInformation("ProcessSalesDataMigration :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.ProcessSalesDataMigration();
            Logger.LogInformation("ProcessSalesDataMigration : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        #region EmployeeManagement

        /// <summary>
        /// Get Native Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNativeDetails()
        {
            Logger.LogInformation("GetNativeDetails :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetNativeDetails();
            Logger.LogInformation("GetNativeDetails : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }

                return NotFound(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));

            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Get Streets By Native Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStreetDetails(int id)
        {
            Logger.LogInformation("GetStreetDetails :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetStreetDetails(id);
            Logger.LogInformation("GetStreetDetails : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }
            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            Logger.LogInformation("GetAllEmployees :  Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.GetAllEmployees();
            Logger.LogInformation("GetAllEmployees : Method End");
            if (result.Status)
            {
                if (result.MessageKey == CommonResource.DataNotFound)
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), true, StatusCodes.Status204NoContent, null));
                }
                else
                {
                    return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataFound), true, StatusCodes.Status200OK, result.Data));
                }
            }
            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.UnableToGetData), result.Status, StatusCodes.Status409Conflict, null));
        }

        /// <summary>
        /// Add and Update Data from Employees
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        [HttpPut,HttpPost]
        public async Task<IActionResult> insertOrUpdateEmployeeDetails([FromBody] EmployeeManagementViewModel listData)
        {

            Logger.LogInformation("insert Or Update EmployeeDetails : Method Start");
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }

            var result = await _studentService.insertOrUpdateEmployeeDetails(listData);

            Logger.LogInformation("insert Or Update EmployeeDetails : Method End");
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataInsert), result.Status, StatusCodes.Status200OK, result.Data));
            }
            
            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotInsert), result.Status, StatusCodes.Status409Conflict, null));
             
        }

        /// <summary>
        /// Change IsActive Status from Employes Db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployes(int id)
        {
            Logger.LogInformation("Delete Employes : Method Start");

            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.BadRequest), false, StatusCodes.Status400BadRequest, null));
            }
            Logger.LogInformation("Delete Employes : Method End");

            var result = await _studentService.DeleteEmployes(id);
            if (result.Status)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataDelete), true, StatusCodes.Status200OK, result.Data));
            }
            if (result.MessageKey == CommonResource.DataNotFound)
            {
                return Ok(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotFound), result.Status, StatusCodes.Status204NoContent, null));
            }

            return Conflict(new APIResponse(CommonResourceLocalizer.GetString(CommonResource.DataNotDelete), false, StatusCodes.Status409Conflict, null));
        }
        #endregion
       
    }
}