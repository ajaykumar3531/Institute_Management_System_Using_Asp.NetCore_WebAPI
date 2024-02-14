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
    /// Interface for bill-wise payment details related business operations.
    /// </summary>
    public interface IBillWisePaymentDetailsBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all bill-wise payment details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of BillWisePaymentDetail objects.</returns>
        Task<List<BillWisePaymentDetail>> getAllBillsWiseDetails();

        /// <summary>
        /// Registers new bill-wise payment details based on the provided BillWisePaymentDetailsDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing bill-wise payment details information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> BillsWiseRegistration(BillWisePayemetDetailsDto dto);

        /// <summary>
        /// Retrieves bill-wise payment details by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the bill-wise payment details to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetBillsWiseByID(int id);
    }
}
