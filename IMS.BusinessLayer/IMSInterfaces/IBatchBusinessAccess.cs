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
    /// Interface for batch-related business operations.
    /// </summary>
    public interface IBatchBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all batch details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of Batch objects.</returns>
        Task<List<Batch>> getAllBatchDetails();

        /// <summary>
        /// Registers a new batch based on the provided BatchDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing batch information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> BatchRegistration(BatchDto dto);

        /// <summary>
        /// Retrieves batch information by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the batch to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetBatchByID(int id);
    }
}
