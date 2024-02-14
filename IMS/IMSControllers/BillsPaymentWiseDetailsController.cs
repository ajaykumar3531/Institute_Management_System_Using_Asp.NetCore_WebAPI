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
    public class BillsPaymentWiseDetailsController : Controller
    {
        private readonly IBillWisePaymentDetailsBusinessAccess _billsPaymentWiseRepo;

        public BillsPaymentWiseDetailsController(IBillWisePaymentDetailsBusinessAccess billsPaymentWiseRepo)
        {
            _billsPaymentWiseRepo = billsPaymentWiseRepo;
        }

        [Route("BillsPaymentWise-Data")]
        [HttpGet]
        public async Task<IActionResult> GetBillsPaymentWiseData()
        {
            try
            {
                // Attempt to get bills payment-wise data
                var data = await _billsPaymentWiseRepo.getAllBillsWiseDetails();

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
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching bills payment-wise data"));
            }
        }

        [Route("BillsPaymentWise-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostBillsPaymentWiseData(BillWisePayemetDetailsDto dto)
        {
            // Attempt to register bills payment-wise data
            var res = await _billsPaymentWiseRepo.BillsWiseRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("BillsPaymentWise-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetBillsPaymentWiseByID(int id)
        {
            // Attempt to get bills payment-wise data by ID
            var res = await _billsPaymentWiseRepo.GetBillsWiseByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }
    }
}
