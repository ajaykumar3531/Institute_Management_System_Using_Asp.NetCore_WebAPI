using IMS.BusinessLayer.EmployeeInterfaces;
using IMS.DataAccessLayer.EmployeeInterfaces;
using IMS.DataAccessLayer.IMSEmployeesDatabase;
using IMS.Models.EmployeesDatabaseDtos;
using IMS.Models.EmployeesDatabaseDtos;
using IMS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessLayer.EmployeeClasses
{
    public class EmployessBusinessLayer : IEmployessBusinessLayer
    {
        private readonly IEmployessDataAccess<Employee> _employeeRepo;
        private readonly ITokenManager _token;

        public EmployessBusinessLayer(IEmployessDataAccess<Employee> employeeRepo, ITokenManager token)
        {
            _employeeRepo = employeeRepo;
            _token = token;
        }

        public async Task<Response> UserLogin(EmployeeLoginDto loginDto)
        {
            
            {
                bool res = await _employeeRepo.FindByPasswordAsync(loginDto.Password, loginDto.Email);

                Employee user = await _employeeRepo.FindByPasswordEmailAndIdAsync(loginDto.Password, loginDto.Email);

                if (res)
                {
                    var token = await _token.GenerateTokenAsync(user);
                    return new Response(200, HttpStatusCode.OK.ToString(), "User Logged Successfully", loginDto, token);
                }
                else
                {
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Invalid Login Details");
                }
            }
            
        }

        public async Task<Response> UserRegistration(EmployeeRegistrationDto dto)
        {
            try
            {
                var email = await _employeeRepo.FindByEmailAsync(dto.Email);

                if (email != null)
                {
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "User already Registered");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                Employee user = new Employee()
                {
                    Email = dto.Email,
                    Password = passwordHash,
                    FullName = dto.FullName,
                };

                _employeeRepo.Add(user);

                if (await _employeeRepo.saveChnagesAsync())
                {
                    return new Response(200, HttpStatusCode.OK.ToString(), "Employee Registered Successfully", dto);
                }
                else
                {
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Employee Registration failed");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, you can log it or return an error response
                return new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred during registration.");
            }
        }
    }
}
