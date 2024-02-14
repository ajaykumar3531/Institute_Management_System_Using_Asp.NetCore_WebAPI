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
    public class StudentController : Controller
    {
        private readonly IStudentBusinessAccess _businessRepo;

        public StudentController(IStudentBusinessAccess businessRepo)
        {
            _businessRepo = businessRepo;
        }

        [Route("Student-Data")]
        [HttpGet]
        public async Task<IActionResult> GetStudentData()
        {
            try
            {
                // Attempt to get student data
                var data = await _businessRepo.getAllStudents();

                if (data != null)
                {
                    // Return a success response with data
                    return Ok(new Response(200, HttpStatusCode.OK.ToString(), "Student Data Fetched Successfully", data));
                }
                else
                {
                    // Return a not found response
                    return NotFound(new Response(404, HttpStatusCode.NotFound.ToString(), "Student Data Not Found"));
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an internal server error response
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching student data"));
            }
        }

        [Route("Student-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostStudentData(StudentDto dto)
        {
            // Attempt to register student data
            var res = await _businessRepo.StudentRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("Student-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            // Attempt to get student data by ID
            var res = await _businessRepo.GetStudentByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }

        [Route("Student-Data-Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateData(StudentUpdateDto dto)
        {
            // Attempt to update student data
            var res = await _businessRepo.UpdateStudentData(dto);

            // Return the result of the update
            return Ok(res);
        }
    }
}
