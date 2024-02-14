using IMS.BusinessLayer.IMSInterfaces;

using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IMS.IMSControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourseJoinedController : Controller
    {
        private readonly ICourseJoinedBusinessAccess _courseJoinedRepo;

        public CourseJoinedController(ICourseJoinedBusinessAccess courseJoinedRepo)
        {
            _courseJoinedRepo = courseJoinedRepo;
        }

        [Route("CourseJoined-Data")]
        [HttpGet]
        public async Task<IActionResult> GetCourseJoinedData()
        {
            try
            {
                // Attempt to get course joined data
                var data = await _courseJoinedRepo.getAllCoursesJoinedDetails();

                if (data != null)
                {
                    // Return a success response with data
                    return Ok(new Response(200, HttpStatusCode.OK.ToString(), "Data Fetched Successfully", data));
                }
                else
                {
                    // Return a not found response
                    return NotFound(new Response(404, HttpStatusCode.NotFound.ToString(), "Data Not Found"));
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an internal server error response
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching course joined data"));
            }
        }

        [Route("CourseJoined-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostCourseJoinedData(CoursesJoinedDto dto)
        {
            // Attempt to register course joined data
            var res = await _courseJoinedRepo.CoursesJoinedRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("CourseJoined-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetCourseJoinedByID(int id)
        {
            // Attempt to get course joined data by ID
            var res = await _courseJoinedRepo.GetCoursesJoinedByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }
    }
}
