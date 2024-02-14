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
    /// Interface for operations related to courses joined by users.
    /// </summary>
    public interface ICourseJoinedBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all courses joined by users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of CoursesJoined objects.</returns>
        Task<List<CoursesJoined>> getAllCoursesJoinedDetails();

        /// <summary>
        /// Registers a user's participation in a course based on the provided CoursesJoinedDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing course participation information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> CoursesJoinedRegistration(CoursesJoinedDto dto);

        /// <summary>
        /// Retrieves information about a user's participation in a course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course participation record to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetCoursesJoinedByID(int id);
    }
}
