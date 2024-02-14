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
    public class StudentBillsController : Controller
    {
        private readonly IStudentBillBusinessAccess _studentBillsRepo;

        public StudentBillsController(IStudentBillBusinessAccess studentBillsRepo)
        {
            _studentBillsRepo = studentBillsRepo;
        }

        [Route("StudentBills-Data")]
        [HttpGet]
        public async Task<IActionResult> GetStudentBillsData()
        {
            try
            {
                // Attempt to get student bills data
                var data = await _studentBillsRepo.getAllStudentBillsJoinedDetails();

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
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching student bills data"));
            }
        }

        [Route("StudentBills-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostStudentBillsData(StudentBillsDto dto)
        {
            // Attempt to register student bills data
            var res = await _studentBillsRepo.StudentBillsRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("StudentBills-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetStudentBillsByID(int id)
        {
            // Attempt to get student bills data by ID
            var res = await _studentBillsRepo.GetStudentBillsByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }
    }
}
