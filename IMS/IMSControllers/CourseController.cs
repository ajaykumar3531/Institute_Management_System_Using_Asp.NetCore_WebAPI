using IMS.BusinessLayer.IMSInterfaces;

using IMS.DataAccessLayer.IMSDatabase;
using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IMS.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseBusinessAccess _courseRepo;

        public CourseController(ICourseBusinessAccess courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [Route("Course-Data")]
        [HttpGet]
        public async Task<IActionResult> GetCourseData()
        {
            try
            {
                // Attempt to get course data
                var data = await _courseRepo.getAllCourseDetails();

                if (data != null)
                {
                    // Return a success response with data
                    return Ok(new Response(200, HttpStatusCode.OK.ToString(), "Course Data Fetched Successfully", data));
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
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching course data"));
            }
        }

        [Route("Course-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostCourseData(CourseDto dto)
        {
            // Attempt to register course data
            var res = await _courseRepo.CourseRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("Course-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            // Attempt to get course data by ID
            var res = await _courseRepo.GetCourseByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }

        [Route("Course-Data-Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateData(CourseUpdateDto dto)
        {
            // Attempt to update course data
            var res = await _courseRepo.UpdateCourseData(dto);

            // Return the result of the update
            return Ok(res);
        }
    }
}
