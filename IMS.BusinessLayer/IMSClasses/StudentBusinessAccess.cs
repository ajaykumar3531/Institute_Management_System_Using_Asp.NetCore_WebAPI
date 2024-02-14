using IMS.BusinessLayer.IMSInterfaces;
using IMS.DataAccessLayer.IMSDatabase;
using IMS.DataAccessLayer.Interfaces;
using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using System;
using System.Net;

namespace IMS.BusinessLayer.IMSClasses
{
    public class StudentBusinessAccess : IStudentBusinessAccess
    {
        private readonly IMS_IDataAccess<Student> _studentRepo;

        public StudentBusinessAccess(IMS_IDataAccess<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<Response> DeleteStudentData(int id)
        {
            try
            {
                var data = await _studentRepo.GetById(id);
                if (data != null)
                {
                    _studentRepo.Remove(data);
                    if (await _studentRepo.saveChnagesAsync())
                    {
                        return new Response(200, HttpStatusCode.OK.ToString(), "Data Deleted Successfully", data);
                    }
                }
                return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<Student>> getAllStudents()
        {
            
            {
                var studentData = await _studentRepo.GetAll();
                return studentData;
            }
            
        }

        public async Task<Response> GetStudentByID(int id)
        {
            try
            {
                var data = await _studentRepo.GetById(id);
                if (data != null)
                {
                    return new Response(200, HttpStatusCode.OK.ToString(), "Data Fetched Successfully", data);
                }
                else
                {
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> StudentRegistration(StudentDto dto)
        {
            try
            {
                var user = await _studentRepo.FindByEmailAsync(dto.Email);

                if (user != null)
                {
                    return new Response(400, "Bad Request", "User with this email already exists.");
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Email = dto.Email,
                        Surname = dto.Surname,
                        DateOfBirth = dto.DateOfBirth,
                        CreatedBy = dto.CreatedBy,
                        Mobile = dto.Mobile,
                        Address = dto.Address,
                        CityName = dto.CityName,
                        StateName = dto.StateName,
                    };

                    _studentRepo.Add(student);

                    if (await _studentRepo.saveChnagesAsync())
                    {
                        return new Response(200, "OK", "Student registration successful.", dto);
                    }
                    else
                    {
                        return new Response(500, "Internal Server Error", "Failed to save student registration.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> UpdateStudentData(StudentUpdateDto dto)
        {
            try
            {
                Student student = new Student()
                {
                    StudentId = dto.Id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Surname = dto.Surname,
                    DateOfBirth = dto.DateOfBirth,
                    CreatedBy = dto.CreatedBy,
                    Mobile = dto.Mobile,
                    Address = dto.Address,
                    CityName = dto.CityName,
                    StateName = dto.StateName,
                    Status = dto.Status,
                };

                _studentRepo.Update(student);

                if (await _studentRepo.saveChnagesAsync())
                {
                    return new Response(200, "OK", "Student Updated successful.", dto);
                }
                else
                {
                    return new Response(500, "Internal Server Error", "Failed to update student data.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }
    }
}
