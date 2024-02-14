using IMS.DataAccessLayer.IMSEmployeesDatabase;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.EmployeeInterfaces
{
    public interface ITokenManager
    {
        /// <summary>
        /// Generates a token for the given employee.
        /// </summary>
        /// <param name="employee">The employee for whom the token will be generated.</param>
        /// <returns>A token as a string.</returns>
        Task<string> GenerateTokenAsync(Employee employee);
    }
}
