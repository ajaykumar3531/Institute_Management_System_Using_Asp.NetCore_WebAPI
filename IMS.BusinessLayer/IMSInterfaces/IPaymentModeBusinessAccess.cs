using IMS.DataAccessLayer.IMSDatabase;
using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessLayer.IMSInterfaces
{
    /// <summary>
    /// Interface for payment mode-related business operations.
    /// </summary>
    public interface IPaymentModeBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all payment mode details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of PaymentMode objects.</returns>
        Task<List<PaymentMode>> getAllPaymentDetails();

        /// <summary>
        /// Registers a new payment mode based on the provided PaymentDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing payment mode information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> PaymentRegistration(PaymentDto dto);

        /// <summary>
        /// Retrieves payment mode information by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the payment mode to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetPayementByID(int id);

        /// <summary>
        /// Deletes payment mode data by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the payment mode to delete.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> DeletePaymentData(int id);

        /// <summary>
        /// Updates payment mode data based on the provided PaymentUpdateDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated payment mode information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> UpdatePaymentData(PaymentUpdateDto dto);
    }
}
