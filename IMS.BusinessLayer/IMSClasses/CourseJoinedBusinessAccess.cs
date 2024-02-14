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
    public class CourseJoinedBusinessAccess : ICourseJoinedBusinessAccess
    {
        private readonly IMS_IDataAccess<CoursesJoined> _courseJoinedRepo;
        private readonly IMS_IDataAccess<Course> _courseRepo;
        private readonly IMS_IDataAccess<Student> _studentRepo;

        public CourseJoinedBusinessAccess(IMS_IDataAccess<CoursesJoined> courseJoinedRepo, IMS_IDataAccess<Course> courseRepo, IMS_IDataAccess<Student> studentRepo)
        {
            _courseJoinedRepo = courseJoinedRepo;
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
        }

        public async Task<List<CoursesJoined>> getAllCoursesJoinedDetails()
        {
            
            {
                var data = await _courseJoinedRepo.GetAll();
                return data;
            }
           
        }

        public async Task<Response> CoursesJoinedRegistration(CoursesJoinedDto dto)
        {
            try
            {
                bool courseIdExists = await _courseRepo.FindCourseId(dto.CourseId);
                bool studentIdExists = await _studentRepo.FindStudentId(dto.StudentId);

                if (courseIdExists && studentIdExists)
                {
                    CoursesJoined data = new CoursesJoined
                    {
                        StudentId = dto.StudentId,
                        CourseId = dto.CourseId,
                        Discount = dto.Discount,
                        CourseFee = dto.CourseFee,
                    };

                    _courseJoinedRepo.Add(data);

                    if (await _courseJoinedRepo.saveChnagesAsync())
                    {
                        return new Response(200, "OK", "CoursesJoined registration successful.", dto);
                    }
                    else
                    {
                        return new Response(500, "Internal Server Error", "Failed to save CoursesJoined data");
                    }
                }
                else
                {
                    return new Response(400, "Bad Request", "Invalid CourseId or StudentId");
                }
            }
            catch (Exception ex)
            {
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetCoursesJoinedByID(int id)
        {
            try
            {
                var data = await _courseJoinedRepo.GetById(id);
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
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }
    }
}
