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
    public class PaymentModeController : Controller
    {
        private readonly IPaymentModeBusinessAccess _paymentRepo;

        public PaymentModeController(IPaymentModeBusinessAccess paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [Route("PaymentMode-Data")]
        [HttpGet]
        public async Task<IActionResult> GetPaymentData()
        {
            try
            {
                // Attempt to get payment data
                var data = await _paymentRepo.getAllPaymentDetails();

                if (data != null)
                {
                    // Return a success response with data
                    return Ok(new Response(200, HttpStatusCode.OK.ToString(), "Payment Data Fetched Successfully", data));
                }
                else
                {
                    // Return a not found response
                    return NotFound(new Response(404, HttpStatusCode.NotFound.ToString(), "Payment Data Not Found"));
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an internal server error response
                return StatusCode(500, new Response(500, HttpStatusCode.InternalServerError.ToString(), "An error occurred while fetching payment data"));
            }
        }

        [Route("Payment-Reg")]
        [HttpPost]
        public async Task<IActionResult> PostPaymentData(PaymentDto dto)
        {
            // Attempt to register payment data
            var res = await _paymentRepo.PaymentRegistration(dto);

            // Return the result of the registration
            return Ok(res);
        }

        [Route("Payment-Data-GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            // Attempt to get payment data by ID
            var res = await _paymentRepo.GetPayementByID(id);

            // Return the result of the retrieval by ID
            return Ok(res);
        }

        [Route("Payment-Data-Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateData(PaymentUpdateDto dto)
        {
            // Attempt to update payment data
            var res = await _paymentRepo.UpdatePaymentData(dto);

            // Return the result of the update
            return Ok(res);
        }
    }
}
