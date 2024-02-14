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
    /// Interface for faculty-related business operations.
    /// </summary>
    public interface IFacultyBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all faculty details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of Faculty objects.</returns>
        Task<List<Faculty>> getAllFacultyDetails();

        /// <summary>
        /// Registers a new faculty member based on the provided FacultyDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing faculty information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> FacultyRegistration(FacultyDto dto);

        /// <summary>
        /// Retrieves faculty member information by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty member to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetFacultyByID(int id);

        /// <summary>
        /// Deletes faculty member data by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty member to delete.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> DeleteFacultyData(int id);

        /// <summary>
        /// Updates faculty member data based on the provided FacultyUpdateDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated faculty information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> UpdateFacultyData(FacultyUpdateDtp dto);
    }
}
