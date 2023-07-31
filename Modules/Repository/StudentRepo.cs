using Database;
using Database.Entities;
using InternalApplication;
using InternalApplication.Database.Entities;
using InternalApplication.Modules.Viewmodel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Module.Abstract;
using Module.StudentViewModule;
using Newtonsoft.Json;
using OfficeOpenXml;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Module.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DBcontext _dbContext;
        private readonly ILogger _logger;

        public StudentRepo(DBcontext context, ILogger<StudentRepo> logger)
        {
            _logger = logger;
            _dbContext = context;
        }

        /// <summary>
        /// Get All Students Details
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetAllStudent()
        {
            try
            {
                _logger.LogInformation("GetAllStudent : Method Start");

                List<ViewModel> studentViewModels = await (from s in _dbContext.StudentDetails
                                                     join d in _dbContext.Department on s.deptid equals d.Id
                                                     join n in _dbContext.Natives on s.Native equals n.Id
                                                     where s.isActive
                                                     orderby s.Id descending
                                                     select new ViewModel
                                                     {
                                                         StudentID = s.Id,
                                                         StudentName = s.StudentName,
                                                         Age = s.Age,
                                                         DepartmentName = d.DepartmentName,
                                                         MobileNumber = s.MobileNumber,
                                                         deptid = d.Id,
                                                         NativeID = d.Id,
                                                         NativeName = n.Name,
                                                         Address = s.Address
                                                     }).ToListAsync();

                if (studentViewModels.Count <= 0)
                {
                    _logger.LogError("GetAllStudent Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetAllStudent Data Available.. ");
                _logger.LogInformation("GetAllStudent : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, studentViewModels);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllStudent Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.UnableToGetData, false);
            }
        }

        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetDepartment()
        {
            try
            {
                _logger.LogInformation($"[{DateTime.Now}] GetDepartment : Method Start");

                List<departments> Data = await _dbContext.Department.Where(l => l.isActive).Select(k => new departments { DepartmentID = k.Id, DepartmentName = k.DepartmentName }).ToListAsync();

                if (Data.Count <= 0)
                {
                    _logger.LogError("GetDepartment Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetDepartment Data Available.. ");
                _logger.LogInformation($"[{DateTime.Now}] GetDepartment : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, Data);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetDepartment Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.UnableToGetData, false);
            }
        }

        /// <summary>
        /// Get All Gender
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetGender()
        {
            try
            {
                _logger.LogInformation("GetGender : Method Start");

                var Data = await _dbContext.Gender.Where(l => l.isActive).Select(k => new gender { Id = k.Id, Name = k.Name }).ToListAsync();

                if (Data.Count <= 0)
                {
                    _logger.LogError("GetGender Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetGender Data Available.. ");
                _logger.LogInformation("GetGender : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, Data);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetGender Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.UnableToGetData, false);
            }
        }

        /// <summary>
        /// Get All Position form Position Table
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetPositionapplied()
        {
            try
            {
                _logger.LogInformation("GetPositionapplied : Method Start");

                var Data = await _dbContext.Positionapplied.Where(l => l.isActive).Select(k => new positionapplied { Id = k.Id, Name = k.Name }).ToListAsync();

                if (Data.Count <= 0)
                {
                    _logger.LogError("GetPositionapplied Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetPositionapplied Data Available.. ");
                _logger.LogInformation("GetPositionapplied : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, Data);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetPositionapplied Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.UnableToGetData, false);
            }
        }

        /// <summary>
        /// Insert Student Details Into StudentDetails 
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> InsertStudentDetails(ViewModel listData)
        {
            try
            {
                _logger.LogInformation("InsertStudentDetails : Method Start");

                var insertData = await _dbContext.StudentDetails.Where(l => l.Id == listData.id).FirstOrDefaultAsync();
                if (insertData != null)
                {
                    _logger.LogError("Data Already Exist");
                    return new MessageViewModel(CommonResource.DataExist, false);
                }

                StudentDetails sf = new StudentDetails();
                sf.StudentName = listData.StudentName;
                sf.Age = listData.Age;
                sf.deptid = listData.deptid;
                sf.MobileNumber = listData.MobileNumber;
                sf.Address = listData.Address;
                sf.isActive = true;
                _dbContext.StudentDetails.Add(sf);
                _dbContext.SaveChanges();

                if(sf != null)
                {
                    _logger.LogInformation("Data Inserted");
                    _logger.LogInformation("InsertStudentDetails : Method End");
                    return new MessageViewModel(CommonResource.DataInsert, true);
                }

                _logger.LogInformation("Data Not Inserted");
                _logger.LogInformation("InsertStudentDetails : Method End");
                return new MessageViewModel(CommonResource.DataNotInsert, true);

            }
            catch (Exception ex)
            {
                _logger.LogError("InsertStudentDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.UnableToGetData, false);
            }
        }

        // on click of forget pass
        /// <summary>
        /// User Forgot Password
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> UserForgotPassword(ForgotPasswordVeiwModel Data)
        {
            try
            {
                _logger.LogInformation("UserForgotPassword : Method Start");

                var CurrentUser = await _dbContext.UserSign.Where(u => u.Email == Data.Email).FirstOrDefaultAsync();
                if (CurrentUser == null)
                {
                    _logger.LogError("Data Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    if (CurrentUser.isBlocked)
                    {
                        var blocktime = CurrentUser.blockedtime?.AddMinutes(5);
                        var currtime = DateTime.Now;
                        if (blocktime <= currtime)
                        {
                            CurrentUser.isBlocked = false;
                            CurrentUser.passwordattemptedtimes = 0;
                            _dbContext.UserSign.Update(CurrentUser);
                            _dbContext.SaveChanges();
                            return new MessageViewModel(CommonResource.DataUpdate, true);
                        }
                        else
                        {
                            return new MessageViewModel(CommonResource.DataNotUpdate, false);
                        }
                    }
                    ForgotPassword us = new ForgotPassword();
                    us.Email = Data.Email;
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5000",
                        audience: "https://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    us.Token = tokenString;

                    _dbContext.ForgotPasswords.Add(us);
                    _dbContext.SaveChanges();

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("gokulkannansomu@gmail.com");
                        mail.To.Add("perumal.ps.2022@rkmshome.org");
                        mail.Subject = "Sign In";
                        mail.Body = "<a href=http://localhost:4200/fToken/" + tokenString + "/" + us.Email + ">click here to verify</a>";
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("perumal.ps.2022@rkmshome.org", "Perumal7@");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                            if (us.Email == Data.Email)
                            {
                                if (CurrentUser.passwordattemptedtimes >= 3)
                                {
                                    CurrentUser.isBlocked = true;
                                    CurrentUser.blockedtime = DateTime.Now;
                                    _dbContext.UserSign.Update(CurrentUser);
                                    _dbContext.SaveChanges();
                                    return new MessageViewModel(CommonResource.DataNotUpdate, false);
                                }
                                else
                                {
                                    CurrentUser.passwordattemptedtimes = CurrentUser.passwordattemptedtimes + 1;
                                    _dbContext.UserSign.Update(CurrentUser);
                                    _dbContext.SaveChanges();
                                    return new MessageViewModel(CommonResource.DataNotUpdate, false);
                                }
                            }
                        _logger.LogInformation("Data Updated");
                        _logger.LogInformation("UserForgotPassword : Method End");
                        return new MessageViewModel(CommonResource.DataUpdate, true);
                        }
                    }
                //return new MessageViewModel(CommonResource.DataUpdate, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("UserForgotPassword Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotUpdate, false);
            }
        }

        /// <summary>
        /// Add User Data Into UderDetails for Signing or Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> AddUserData(UserSignVeiwmodel Data)
        {
            try
            {
                _logger.LogInformation("AddUserData : Method Start");

                var CurrentUser = await _dbContext.UserSign.Where(u => u.Email == Data.Email).FirstOrDefaultAsync();

                if (CurrentUser != null)
                {
                    _logger.LogError("Data Already Exist");
                    return new MessageViewModel(CommonResource.DataExist, false);
                }
                    var providedPasswordHash = hashPassword(Data.Password);
                    var hashedpassword = Convert.ToBase64String(providedPasswordHash);
                    UserSign us = new UserSign();
                    us.Email = Data.Email;
                    us.Password = hashedpassword;
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5000",
                        audience: "https://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    us.Token = tokenString;
                    us.IsActive = Data.IsActive;
                    us.IsDelete = Data.IsDelete;
                    _dbContext.UserSign.Add(us);
                    _dbContext.SaveChanges();
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("gokulkannansomu@gmail.com");
                        mail.To.Add("perumal.ps.2022@rkmshome.org");
                        mail.Subject = "Sign In";
                        mail.Body = "<a href=http://localhost:4200/mailverify/" + tokenString + ">click here to verify</a>";
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("perumal.ps.2022@rkmshome.org", "Perumal7@");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                _logger.LogInformation("Data Inserted");
                _logger.LogInformation("AddUserData : Method End");
                return new MessageViewModel(CommonResource.DataInsert, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("AddUserData Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotInsert, false);
            }
        }

        private byte[] hashPassword(string password)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider hasher =
             new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// User Login Method for Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public responceViewModel UserLogin(UserSignVeiwmodel Data)
        {
            try
            {
                _logger.LogInformation("UserLogin : Method Start");

                var ul = _dbContext.UserSign.Where(item => item.Email == Data.Email).FirstOrDefault();
                if (ul != null)
                {
                    if (ul.isBlocked)
                    {
                        var blocktime = ul.blockedtime?.AddMinutes(5);
                        var currtime = DateTime.Now;
                        if (blocktime <= currtime)
                        {
                            ul.isBlocked = false;
                            ul.passwordattemptedtimes = 0;
                            _dbContext.UserSign.Update(ul);
                            _dbContext.SaveChanges();
                            return new responceViewModel { status = true, message = "Un Blocked successfully" };
                        }
                        else
                        {
                            return new responceViewModel { status = false, message = "Something Went Wrong" };
                        }
                    }
                    var providedPasswordHash = hashPassword(Data.Password);
                    var hashedpassword = Convert.ToBase64String(providedPasswordHash);
                    if (hashedpassword == ul.Password)
                    {
                        return new responceViewModel { status = true, message = "Password Matched" , token = ul.Token};
                    }
                    else
                    {
                        if (ul.passwordattemptedtimes >= 3)
                        {
                            ul.isBlocked = true;
                            ul.blockedtime = DateTime.Now;
                            _dbContext.UserSign.Update(ul);
                            _dbContext.SaveChanges();
                            return new responceViewModel { status = false, message = "Try Again After 24 hours" };
                        }
                        else
                        {
                            ul.passwordattemptedtimes = ul.passwordattemptedtimes + 1;
                            _dbContext.UserSign.Update(ul);
                            _dbContext.SaveChanges();
                            return new responceViewModel { status = false, message = "Wrong Password Count Increased" };
                        }
                    }
                }
                _logger.LogInformation("UserLogin : Method End");
                return new responceViewModel { status = true, message = "Successfully Logged In" };
            }
            catch (Exception ex)
            {
                _logger.LogError("UserLogin Exception :" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update Token While Logging
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> UpdateToken(UserSignVeiwmodel Data)
        {
            try
            {
                _logger.LogInformation("UpdateToken : Method Start");

                var sf = await _dbContext.UserSign.Where(item => item.Token == Data.Token).FirstOrDefaultAsync();
                if (sf == null)
                {
                    _logger.LogError("The Token Does Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                
                    sf.Token = null;
                    sf.IsActive = true;
                    _dbContext.UserSign.Update(sf);
                    _dbContext.SaveChanges();

                _logger.LogInformation("Data Inserted");
                _logger.LogInformation("UpdateToken : Method End");
                return new MessageViewModel(CommonResource.DataUpdate, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateToken Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotUpdate, false);
            }
        }

        /// <summary>
        /// Forgot PassWord Email Token
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> ForgotToken(ForgotPasswordVeiwModel Data)
        {
            try
            {
                _logger.LogInformation("ForgotToken : Method Start");

                var sf = await _dbContext.ForgotPasswords.Where(item => item.Token == Data.Token).FirstOrDefaultAsync();
                if (sf == null)
                {
                    _logger.LogError("The Token Does Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    sf.Token = null;
                    sf.IsActive = 1;

                    _dbContext.ForgotPasswords.Update(sf);
                    _dbContext.SaveChanges();

                    _logger.LogInformation("Data Updated");
                    _logger.LogInformation("ForgotToken : Method End");
                    return new MessageViewModel(CommonResource.DataUpdate, true);
                }
            catch (Exception ex)
            {
                _logger.LogError("ForgotToken Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotUpdate, false);
            }
        }

        /// <summary>
        /// Insert UserDetails
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> InsertUserDetails(ViewModel listData)
        {
            try
            {
                _logger.LogInformation("InsertUserDetails : Method Start");

                UserDetails ud = new UserDetails();
                if (listData.userDetailsVeiwmodel == null && listData.experience == null)
                {
                    _logger.LogError("The User Already Exist");
                    return new MessageViewModel(CommonResource.DataExist, false);
                }
                    ud.FirstName = listData.userDetailsVeiwmodel.FirstName;
                    ud.LastName = listData.userDetailsVeiwmodel.LastName;
                    ud.DateofBirth = listData.userDetailsVeiwmodel.DateofBirth;
                    ud.GenderId = listData.userDetailsVeiwmodel.GenderId;
                    ud.Email = listData.userDetailsVeiwmodel.Email;
                    ud.Address = listData.userDetailsVeiwmodel.Address;
                    ud.City = listData.userDetailsVeiwmodel.City;
                    ud.State = listData.userDetailsVeiwmodel.State;
                    ud.Zipcode = listData.userDetailsVeiwmodel.Zipcode;
                    ud.ContactNumber = listData.userDetailsVeiwmodel.ContactNumber;
                    ud.CurrentAddress = listData.userDetailsVeiwmodel.CurrentAddress;
                    ud.CurrentCity = listData.userDetailsVeiwmodel.CurrentCity;
                    ud.CurrentState = listData.userDetailsVeiwmodel.CurrentState;
                    ud.CurrentZipcode = listData.userDetailsVeiwmodel.CurrentZipcode;
                    ud.Location = listData.userDetailsVeiwmodel.Location;
                    ud.Height = listData.userDetailsVeiwmodel.Height;
                    ud.Weight = listData.userDetailsVeiwmodel.Weight;
                    ud.Totalexperience = listData.userDetailsVeiwmodel.Totalexperience;
                    ud.ICUexperience = listData.userDetailsVeiwmodel.ICUexperience;
                    ud.PositionappliedId = listData.userDetailsVeiwmodel.PositionappliedId;
                    ud.DepartmentId = listData.userDetailsVeiwmodel.DepartmentId;
                    ud.Degree = listData.experience.Degree;
                    ud.Institution = listData.experience.Institution;
                    ud.Year = listData.experience.Year;
                    ud.Organization = listData.experience.Organization;
                    ud.Designation = listData.experience.Designation;
                    ud.Department = listData.experience.Department;
                    ud.ProbationStartDate = listData.experience.ProbationStartDate;
                    ud.ProbationEndDate = listData.experience.ProbationEndDate;
                    _dbContext.UserDetails.Add(ud);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("Data Updated");
                    _logger.LogInformation("InsertUserDetails : Method End");
                    return new MessageViewModel(CommonResource.DataInsert, true);
                }
            catch (Exception ex)
            {
                _logger.LogError("InsertUserDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotInsert, false);
            }
        }

        /// <summary>
        /// Change IsActive Status False 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> DeleteStudent(int id)
        {
            try
            {
               _logger.LogInformation("DeleteStudent : Method Start");

                var sf = _dbContext.StudentDetails.FirstOrDefault(item => item.Id == id && item.isActive);

                if (sf == null)
                {
                    _logger.LogError("The User Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    sf.isActive = false;
                    _dbContext.StudentDetails.Update(sf);
                    await _dbContext.SaveChangesAsync();
                 
                    _logger.LogInformation("Data Updated");
                    _logger.LogInformation("DeleteStudent : Method End");
                    return new MessageViewModel(CommonResource.DataDelete, true);
                }
            catch (Exception ex)
            {
                _logger.LogError("DeleteStudent Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotDelete, false);
            }
        }

        /// <summary>
        /// Update Student Details From StudentDetails
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> EditStudent(ViewModel data)
        {
            try
            {
                _logger.LogInformation("EditStudent : Method Start");

                var sf = _dbContext.StudentDetails.FirstOrDefault(item => item.Id == data.StudentID);
                if (sf == null)
                {
                    _logger.LogError("The User Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    sf.StudentName = data.StudentName;
                    sf.Age = data.Age;
                    sf.MobileNumber = data.MobileNumber;
                    sf.Address = data.Address;
                    sf.deptid = data.deptid;
                    _dbContext.StudentDetails.Update(sf);
                    await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Data Updated");
                _logger.LogInformation("EditStudent : Method End");
                return new MessageViewModel(CommonResource.DataDelete, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("EditStudent Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotDelete, false);
            }
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> ResetPassword(UserSignVeiwmodel Data)
        {
            try
            {
                _logger.LogInformation("ResetPassword : Method Start");

                var rp = await _dbContext.UserSign.Where(item => item.Email == Data.Email).FirstOrDefaultAsync();
                if (rp == null)
                {
                    _logger.LogError("The User Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    var providedPasswordHash = hashPassword(Data.Password);
                    var hashedpassword = Convert.ToBase64String(providedPasswordHash);
                    rp.Password = hashedpassword;
                    _dbContext.UserSign.Update(rp);
                    _dbContext.SaveChanges();

                    _logger.LogInformation("Data Updated");
                    _logger.LogInformation("ResetPassword : Method End");
                    return new MessageViewModel(CommonResource.DataUpdate, true);
                }
            catch (Exception ex)
            {
                _logger.LogError("ResetPassword Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotUpdate, false);
            }
        }

        /// <summary>
        /// insert Or UpdateDetails from Student Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> insertOrUpdateDetails(ViewModel details)
        {
            try
            {
                _logger.LogInformation("insertOrUpdateDetails : Method Start");

                bool isExist = _dbContext.StudentDetails.Where(s => s.Id == details.StudentID).Any();

                if (isExist)
                {
                    var sf = _dbContext.StudentDetails.FirstOrDefault(item => item.Id == details.StudentID);
                    if (sf != null)
                    {
                        sf.StudentName = details.StudentName;
                        sf.Age = details.Age;
                        sf.MobileNumber = details.MobileNumber;
                        sf.Address = details.Address;
                        sf.deptid = details.deptid;
                        _dbContext.StudentDetails.Update(sf);
                        await _dbContext.SaveChangesAsync();

                        _logger.LogInformation("Data Updated");
                        _logger.LogInformation("insertOrUpdateDetails : Method End");
                        return new MessageViewModel(CommonResource.DataUpdate, true);
                    }
                    else
                    {
                        return new MessageViewModel(CommonResource.Unauthorized, false);
                    }
                }
                else
                {
                    StudentDetails sf = new StudentDetails();
                    sf.StudentName = details.StudentName;
                    sf.Age = details.Age;
                    sf.deptid = details.deptid;
                    sf.MobileNumber = details.MobileNumber;
                    sf.Address = details.Address;
                    sf.isActive = true;
                    _dbContext.StudentDetails.Add(sf);
                    _dbContext.SaveChanges();

                    _logger.LogInformation("Data Inserted");
                    _logger.LogInformation("insertOrUpdateDetails : Method End");

                    return new MessageViewModel(CommonResource.DataInsert, true);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("insertOrUpdateDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotInsert, false);
            }
        }

        /// <summary>
        /// Process Sales DataMigration
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> ProcessSalesDataMigration()
        {
            try
            {
                _logger.LogInformation("ProcessSalesDataMigration : Method Start");

                FileInfo existingFile = new FileInfo("C://Users//Fin Emp//Documents//DataMigration.xlsx");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    List<StudentDetails> patientLst = new List<StudentDetails>();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count
                    for (int row = 1; row <= rowCount; row++)
                    {
                        StudentDetails pat = new StudentDetails();
                        for (int col = 1; col <= colCount; col++)
                        {
                            string columnName = worksheet.Cells[1, col].Value?.ToString();

                            var value = worksheet.Cells[row, col].Value;
                            if (columnName != "" && row > 1)
                            {
                                Console.WriteLine($"Row : {row}, Column : {col},Column Name : {columnName} , Value : {value} \n");
                                switch (columnName)
                                {

                                    case "StudentID":
                                        pat.Id = Convert.ToInt32(value);
                                        break;

                                    case "StudentName":
                                        pat.StudentName = value.ToString();
                                        break;

                                    case "deptid":
                                        pat.deptid = Convert.ToInt32(value);
                                        break;

                                    case "Age":
                                        pat.Age = Convert.ToInt32(value);
                                        break;

                                    case "MobileNumber":
                                        pat.MobileNumber = value.ToString();
                                        break;

                                    case "Address":
                                        pat.Address = value.ToString();
                                        break;

                                    case "is_active":
                                        pat.isActive = true;
                                        break;
                                }
                            }
                        }
                        if (row > 1)
                        {
                            patientLst.Add(pat);
                        }

                        //if (row > 1)
                        //{
                        //    StudentDetails user = new StudentDetails();
                        //    user.StudentID = pat.DepartmentID;
                        //    user.StudentName = $"{pat.DepartmentName} {pat.DepartmentName}";
                        //    user.IsRegistered = true;
                        //    user.UserEmail = pat.PatientEmailAddress;
                        //    user.IsActive = true;
                        //    user.CreatedOn = DateTime.Now;
                        //    user.CreatedBy = pat.CreatedBy;
                        //    userLst.Add(user);
                        //    patientLst.Add(pat);
                        //}

                    }
                    //Console.WriteLine($"User List : {JsonConvert.SerializeObject(userLst).ToString()} \n");
                    Console.WriteLine($"Patient List : {JsonConvert.SerializeObject(patientLst).ToString()} \n");
                    //_dbContext.StudentDetails.AddRange(userLst);
                    //_dbContext.SaveChanges();

                    _dbContext.StudentDetails.AddRange(patientLst);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("Data Inserted");
                    _logger.LogInformation("ProcessSalesDataMigration : Method End");

                    return new MessageViewModel(CommonResource.DataInsert, true);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("ProcessSalesDataMigration Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotInsert, false);
            }
        }


        #region EmployeeMAnagement

        /// <summary>
        /// Get Native Details
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetNativeDetails()
        {
            try
            {
                _logger.LogInformation("GetNativeDetails : Method Start");

                var nativeDetails = await _dbContext.Natives.Where(l => l.isActive).Select(l => new MasterViewModel { Id = l.Id, Name = l.Name }).ToListAsync();

                if (nativeDetails.Count <= 0)
                {
                    _logger.LogError("GetNativeDetails Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetNativeDetails Data Available.. ");
                _logger.LogInformation("GetNativeDetails : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, nativeDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetNativeDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotFound, false);
            }
        }

        /// <summary>
        /// Get Streets By Native Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> GetStreetDetails(int id)
        {
            try
            {
                _logger.LogInformation("GetNativeDetails : Method Start");

                var streetDetails = await _dbContext.Streets.Where(l => l.isActive && l.nativeId == id).Select(l => new StreetViewModel { Id = l.Id, Name = l.Name }).ToListAsync();

                if (streetDetails.Count <= 0)
                {
                    _logger.LogError("GetStreetDetails Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, true);
                };

                _logger.LogInformation("GetStreetDetails Data Available.. ");
                _logger.LogInformation("GetStreetDetails : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, streetDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetStreetDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotFound, false);
            }
        }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        public async Task<MessageViewModel> GetAllEmployees()
        {
            try
            {
                _logger.LogInformation("GetAllEmployees : Method Start");

                List<EmployeeManagementViewModel> EmployeeDetails =await (from e in _dbContext.EmployeeManagements
                                                     join n in _dbContext.Natives on e.NativeId equals n.Id
                                                     join s in _dbContext.Streets on e.StreetId equals s.Id
                                                     where e.isActive
                                                     orderby e.Id descending
                                                     select new EmployeeManagementViewModel
                                                     {
                                                         Id = e.Id,
                                                         EmployeeName = e.EmployeeName,
                                                         Item = e.Item,
                                                         Color = e.Color,
                                                         NativeId = n.Id,
                                                         NativeName = n.Name,
                                                         StreetId = s.Id,
                                                         StreetName = s.Name,
                                                         MobileNumber = e.MobileNumber
                                                     }).ToListAsync();

                if (EmployeeDetails.Count <= 0)
                {
                    _logger.LogError("GetAllEmployees Data Not Available.. ");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                };

                _logger.LogInformation("GetAllEmployees Data Available.. ");
                _logger.LogInformation("GetAllEmployees : Method End");
                return new MessageViewModel(CommonResource.DataFound, true, string.Empty, EmployeeDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllEmployees Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotFound, false);
            }
        }

        /// <summary>
        /// Add and Update Data from Employees
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> insertOrUpdateEmployeeDetails(EmployeeManagementViewModel details)
        {
            try
            {
                _logger.LogInformation("insertOrUpdateEmployeeDetails : Method Start");

                bool isExist = _dbContext.EmployeeManagements.Where(s => s.Id == details.Id).Any();

                if (isExist)
                {
                    var employeeDetails = _dbContext.EmployeeManagements.FirstOrDefault(item => item.Id == details.Id);
                    if (employeeDetails != null)
                    {
                        employeeDetails.EmployeeName = details.EmployeeName;
                        employeeDetails.Item = details.Item;
                        employeeDetails.Color = details.Color;
                        employeeDetails.NativeId = details.NativeId;
                        employeeDetails.StreetId = details.StreetId;
                        employeeDetails.MobileNumber = details.MobileNumber;
                        employeeDetails.UpdatedAt = DateTime.Now;
                        employeeDetails.UpdatedBy = 1;
                        _dbContext.EmployeeManagements.Update(employeeDetails);
                        await _dbContext.SaveChangesAsync();
                        _logger.LogInformation("Data Updated");
                        _logger.LogInformation("insertOrUpdateEmployeeDetails : End");
                        return new MessageViewModel(CommonResource.DataUpdate, true);
                    }
                    else
                    {
                        _logger.LogError("Update EmployeeDetails Exception :");
                        return new MessageViewModel(CommonResource.UnableToGetData, false);
                    }
                }
                else
                {
                    EmployeeManagement empManage = new EmployeeManagement();
                    empManage.EmployeeName = details.EmployeeName;
                    empManage.Item = details.Item;
                    empManage.Color = details.Color;
                    empManage.NativeId = details.NativeId;
                    empManage.StreetId = details.StreetId;
                    empManage.MobileNumber = details.MobileNumber;
                    empManage.CreatedBy = 1;
                    empManage.CreatedAt = DateTime.Now;
                    empManage.isActive = true;
                    _dbContext.EmployeeManagements.Add(empManage);
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation("Date Inserted");
                    _logger.LogInformation("insertOrUpdateEmployeeDetails : Method End");
                    return new MessageViewModel(CommonResource.DataInsert, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("insertOrUpdateEmployeeDetails Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotInsert, false);
            }
        }

        /// <summary>
        /// Change IsActive Status from Employes Db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageViewModel> DeleteEmployes(int id)
        {
            try
            {
                _logger.LogInformation("DeleteEmployes : Method Start");

                var emp = _dbContext.EmployeeManagements.FirstOrDefault(item => item.Id == id && item.isActive);

                if (emp == null)
                {
                    _logger.LogError("The User Not Exist");
                    return new MessageViewModel(CommonResource.DataNotFound, false);
                }
                    emp.isActive = false;
                    emp.DeletedBy = 1;
                    emp.DeletedAt = DateTime.Now; 
                    _dbContext.EmployeeManagements.Update(emp);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogInformation("Data Deleted");
                    _logger.LogInformation("DeleteEmployes : Method End");

                    return new MessageViewModel(CommonResource.DataDelete, true);

                }
            catch (Exception ex)
            { 
                _logger.LogError("DeleteEmployes Exception :" + ex.Message);
                return new MessageViewModel(CommonResource.DataNotDelete, false);
            }
        }
        #endregion

    }
}
