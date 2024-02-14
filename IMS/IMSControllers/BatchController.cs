using IMS.BusinessLayer.IMSInterfaces;

using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace IMS.IMSControllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class BtachController : Controller
    {
        private readonly IBatchBusinessAccess _batchRepo;

        public BtachController(IBatchBusinessAccess batchRepo)
        {
            _batchRepo = batchRepo;
        }
     
        [Route("Batch-Data")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBatchData()
        {
            try
            {
                // Attempt to get batch data
                var data = await _batchRepo.getAllBatchDetails();

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
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching batch data"));
            }
        }
       
        [Route("Batch-Reg")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostBatchData(BatchDto dto)
        {
            // Attempt to register a batch
            var res = await _batchRepo.BatchRegistration(dto);

            // Return the result of the batch registration
            return Ok(res);
        }

        
        [Route("Batch-Data-GetByID")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByID(int id)
        {
            // Attempt to get batch data by ID
            var res = await _batchRepo.GetBatchByID(id);

            // Return the result of the batch retrieval by ID
            return Ok(res);
        }
    }
}
