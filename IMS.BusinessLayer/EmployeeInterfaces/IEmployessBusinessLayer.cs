using IMS.Models.EmployeesDatabaseDtos;
using IMS.Models.EmployeesDatabaseDtos;
using IMS.Models.Responses;
using System.Threading.Tasks;

namespace IMS.BusinessLayer.EmployeeInterfaces
{
    public interface IEmployessBusinessLayer
    {
        /// <summary>
        /// Registers a new employee.
        /// </summary>
        /// <param name="dto">Employee registration data.</param>
        /// <returns>A response indicating the result of the registration.</returns>
        Task<Response> UserRegistration(EmployeeRegistrationDto dto);

        /// <summary>
        /// Logs in a user with provided credentials.
        /// </summary>
        /// <param name="loginDto">User login credentials.</param>
        /// <returns>A response indicating the result of the login attempt.</returns>
        Task<Response> UserLogin(EmployeeLoginDto loginDto);
    }
}
