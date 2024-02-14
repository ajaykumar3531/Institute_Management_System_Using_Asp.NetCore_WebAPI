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
    /// Interface for course-related business operations.
    /// </summary>
    public interface ICourseBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all course details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of Course objects.</returns>
        Task<List<Course>> getAllCourseDetails();

        /// <summary>
        /// Registers a new course based on the provided CourseDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing course information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> CourseRegistration(CourseDto dto);

        /// <summary>
        /// Retrieves course information by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetCourseByID(int id);

        /// <summary>
        /// Deletes course data by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course to delete.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> DeleteCourseData(int id);

        /// <summary>
        /// Updates course data based on the provided CourseUpdateDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated course information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> UpdateCourseData(CourseUpdateDto dto);
    }
}
