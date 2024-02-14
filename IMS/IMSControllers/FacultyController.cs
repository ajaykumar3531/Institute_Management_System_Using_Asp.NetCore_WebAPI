using IMS.BusinessLayer.IMSInterfaces;

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
    public class FacultyController : Controller
    {
        private readonly IFacultyBusinessAccess _facultyRepo;

        public FacultyController(IFacultyBusinessAccess facultyRepo)
        {
            _facultyRepo = facultyRepo;
        }

        [Route("Faculty-Data")]
        [HttpGet]
        public async Task<IActionResult> GetFacultyData()
        {
            try
            {
                // Attempt to get faculty data
                var data = await _facultyRepo.getAllFacultyDetails();

                if (data != null)
                {
                    // Return a success response with data
                    return Ok(new Response(200, HttpStatusCode.OK.ToString(), "Faculty Data Fetched Successfully", data));
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
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching faculty data"));
            }
        }

        [Route("Faculty-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostFacultyData(FacultyDto dto)
        {
            // Attempt to register faculty data
            var res = await _facultyRepo.FacultyRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [HttpGet("Faculty-Data-GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            // Attempt to get faculty data by ID
            var res = await _facultyRepo.GetFacultyByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }

        [Route("Faculty-Data-Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateData(FacultyUpdateDtp dto)
        {
            // Attempt to update faculty data
            var res = await _facultyRepo.UpdateFacultyData(dto);

            // Return the result of the update
            return Ok(res);
        }
    }
}
