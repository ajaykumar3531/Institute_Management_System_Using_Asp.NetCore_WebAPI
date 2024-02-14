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
    public class PaymentModeBusinessAccess : IPaymentModeBusinessAccess
    {
        private readonly IMS_IDataAccess<PaymentMode> _paymentModeRepo;

        public PaymentModeBusinessAccess(IMS_IDataAccess<PaymentMode> paymentModeRepo)
        {
            _paymentModeRepo = paymentModeRepo;
        }

        // For PaymentMode
        public async Task<List<PaymentMode>> getAllPaymentDetails()
        {
           
            {
                // Retrieve all payment mode data from the repository
                var paymentData = await _paymentModeRepo.GetAll();
                return paymentData;
            }
            
        }

        public async Task<Response> PaymentRegistration(PaymentDto dto)
        {
            try
            {
                PaymentMode payment = new PaymentMode()
                {
                    PaymentModeName = dto.PaymentModeName,
                };

                // Add the payment mode to the repository
                _paymentModeRepo.Add(payment);

                // Attempt to save changes
                if (await _paymentModeRepo.saveChnagesAsync())
                {
                    // Payment mode added successfully
                    return new Response(200, "OK", "Payment Added successfully.", dto);
                }
                else
                {
                    // Failed to add payment mode
                    return new Response(500, "Internal Server Error", "Failed to Add Payment Mode");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetPayementByID(int id)
        {
            try
            {
                // Retrieve payment mode data by ID from the repository
                var data = await _paymentModeRepo.GetById(id);
                if (data != null)
                {
                    // Payment mode data fetched successfully
                    return new Response(200, HttpStatusCode.OK.ToString(), "Payment Data Fetched Successfully", data);
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

        public async Task<Response> DeletePaymentData(int id)
        {
            try
            {
                // Retrieve payment mode data by ID from the repository
                var data = await _paymentModeRepo.GetById(id);
                if (data != null)
                {
                    // Remove the payment mode from the repository
                    _paymentModeRepo.Remove(data);
                    // Attempt to save changes
                    if (await _paymentModeRepo.saveChnagesAsync())
                    {
                        // Payment mode data deleted successfully
                        return new Response(200, HttpStatusCode.OK.ToString(), "Payment Data Deleted Successfully", data);
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

        public async Task<Response> UpdatePaymentData(PaymentUpdateDto dto)
        {
            try
            {
                PaymentMode payment = new PaymentMode()
                {
                    PaymentModeId = dto.Id,
                    PaymentModeName = dto.PaymentModeName,
                };

                // Update the payment mode in the repository
                _paymentModeRepo.Update(payment);

                // Attempt to save changes
                if (await _paymentModeRepo.saveChnagesAsync())
                {
                    // Payment mode data updated successfully
                    return new Response(200, "OK", "Payment Data Updated successfully.", dto);
                }
                else
                {
                    // Failed to update payment mode data
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
