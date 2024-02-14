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
    /// Interface for operations related to student bills.
    /// </summary>
    public interface IStudentBillBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all student bill details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of StudentBill objects.</returns>
        Task<List<StudentBill>> getAllStudentBillsJoinedDetails();

        /// <summary>
        /// Registers a student bill based on the provided StudentBillsDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing student bill information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> StudentBillsRegistration(StudentBillsDto dto);

        /// <summary>
        /// Retrieves student bill information by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student bill to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetStudentBillsByID(int id);
    }
}
