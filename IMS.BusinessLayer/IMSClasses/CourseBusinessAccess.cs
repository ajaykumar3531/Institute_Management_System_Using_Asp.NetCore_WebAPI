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
    public class CourseBusinessAccess : ICourseBusinessAccess
    {
        private readonly IMS_IDataAccess<Course> _courseRepo;

        public CourseBusinessAccess(IMS_IDataAccess<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }

        // For Courses

        public async Task<List<Course>> getAllCourseDetails()
        {
            
            {
                // Retrieve all course data from the repository
                var CourseData = await _courseRepo.GetAll();
                return CourseData;
            }
           
        }

        public async Task<Response> CourseRegistration(CourseDto dto)
        {
            try
            {
                // Create a new Course object using the CourseDto
                Course course = new Course()
                {
                    CourseName = dto.CourseName,
                    CourseType = dto.CourseType,
                    CourseDuration = dto.CourseDuration,
                    CourseFee = dto.CourseFee,
                    CourseContent = dto.CourseContent,
                };

                // Add the course to the repository
                _courseRepo.Add(course);

                // Attempt to save changes
                if (await _courseRepo.saveChnagesAsync())
                {
                    // Course added successfully
                    return new Response(200, "OK", "Course Added successfully.", dto);
                }
                else
                {
                    // Failed to add course
                    return new Response(500, "Internal Server Error", "Failed to Add Course");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetCourseByID(int id)
        {
            try
            {
                // Retrieve course data by ID from the repository
                var data = await _courseRepo.GetById(id);
                if (data != null)
                {
                    // Course data fetched successfully
                    return new Response(200, HttpStatusCode.OK.ToString(), "Course Data Fetched Successfully", data);
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

        public async Task<Response> DeleteCourseData(int id)
        {
            try
            {
                // Retrieve course data by ID from the repository
                var data = await _courseRepo.GetById(id);
                if (data != null)
                {
                    // Remove the course from the repository
                    _courseRepo.Remove(data);
                    // Attempt to save changes
                    if (await _courseRepo.saveChnagesAsync())
                    {
                        // Course data deleted successfully
                        return new Response(200, HttpStatusCode.OK.ToString(), "Course Data Deleted Successfully", data);
                    }
                }

                // Data not found
                return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> UpdateCourseData(CourseUpdateDto dto)
        {
            try
            {
                // Create a new Course object using the CourseUpdateDto
                Course course = new Course()
                {
                    CourseId = dto.Id,
                    CourseName = dto.CourseName,
                    CourseType = dto.CourseType,
                    CourseDuration = dto.CourseDuration,
                    CourseFee = dto.CourseFee,
                    CourseContent = dto.CourseContent,
                };

                // Update the course in the repository
                _courseRepo.Update(course);

                // Attempt to save changes
                if (await _courseRepo.saveChnagesAsync())
                {
                    // Course data updated successfully
                    return new Response(200, "OK", "Course Data Updated successfully.", dto);
                }
                else
                {
                    // Failed to update course data
                    return new Response(500, "Internal Server Error", "Failed to update Data.");
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
