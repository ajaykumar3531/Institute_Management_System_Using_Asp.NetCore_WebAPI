using IMS.BusinessLayer.IMSInterfaces;
using IMS.DataAccessLayer.IMSDatabase;
using IMS.DataAccessLayer.Interfaces;
using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessLayer.IMSClasses
{
    public class StudentBillBusinessAccess : IStudentBillBusinessAccess
    {
        private readonly IMS_IDataAccess<Course> _courseRepo;
        private readonly IMS_IDataAccess<Student> _studentRepo;
        private readonly IMS_IDataAccess<CoursesJoined> _courseJoinedRepo;
        private readonly IMS_IDataAccess<StudentBill> _studentBillRepo;

        public StudentBillBusinessAccess(IMS_IDataAccess<Course> courseRepo, IMS_IDataAccess<Student> studentRepo, IMS_IDataAccess<CoursesJoined> courseJoinedRepo, IMS_IDataAccess<StudentBill> studentBillRepo)
        {
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
            _courseJoinedRepo = courseJoinedRepo;
            _studentBillRepo = studentBillRepo;
        }

        public async Task<List<StudentBill>> getAllStudentBillsJoinedDetails()
        {
            
            {
                // Retrieve all student bill data from the repository
                var data = await _studentBillRepo.GetAll();
                return data;
            }
           
        }

        public async Task<Response> StudentBillsRegistration(StudentBillsDto dto)
        {
            try
            {
                bool courseIdExists = await _courseRepo.FindCourseId(dto.CourseId);
                bool studentIdExists = await _studentRepo.FindStudentId(dto.StudentId);
                bool coursejoinedIdExists = await _courseJoinedRepo.FindCourseJoinId(dto.CoursesJoinedId);

                if (courseIdExists && studentIdExists && coursejoinedIdExists)
                {
                    StudentBill data = new StudentBill
                    {
                        CoursesJoinedId = dto.CoursesJoinedId,
                        StudentId = dto.StudentId,
                        CourseId = dto.CourseId,
                        DueDate = dto.DueDate,
                        BillAmount = dto.BillAmount,
                        Status = dto.Status,
                    };

                    // Add the student bill to the repository
                    _studentBillRepo.Add(data);

                    // Attempt to save changes
                    if (await _studentBillRepo.saveChnagesAsync())
                    {
                        // Registration successful
                        return new Response(200, "OK", "Registration successful.", dto);
                    }
                    else
                    {
                        // Failed to save student bill data
                        return new Response(500, "Internal Server Error", "Failed to save student bill data");
                    }
                }
                else
                {
                    // Invalid CourseId, StudentId, or CourseJoinedId
                    return new Response(400, "Bad Request", "Invalid CourseId, StudentId, or CourseJoinedId");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetStudentBillsByID(int id)
        {
            try
            {
                // Retrieve student bill data by ID from the repository
                var data = await _studentBillRepo.GetById(id);
                if (data != null)
                {
                    // Data fetched successfully
                    return new Response(200, HttpStatusCode.OK.ToString(), "Data Fetched Successfully", data);
                }
                else
                {
                    // Data not found
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
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
