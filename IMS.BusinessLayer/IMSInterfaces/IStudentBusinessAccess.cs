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
    /// Interface for student-related business operations.
    /// </summary>
    public interface IStudentBusinessAccess
    {
        /// <summary>
        /// Retrieves a list of all student details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of Student objects.</returns>
        Task<List<Student>> getAllStudents();

        /// <summary>
        /// Registers a new student based on the provided StudentDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing student information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> StudentRegistration(StudentDto dto);

        /// <summary>
        /// Retrieves student information by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> GetStudentByID(int id);

        /// <summary>
        /// Deletes student data by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to delete.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> DeleteStudentData(int id);

        /// <summary>
        /// Updates student data based on the provided StudentUpdateDto.
        /// </summary>
        /// <param name="dto">The data transfer object containing updated student information.</param>
        /// <returns>A task representing the asynchronous operation that returns a Response object.</returns>
        Task<Response> UpdateStudentData(StudentUpdateDto dto);
    }
}
