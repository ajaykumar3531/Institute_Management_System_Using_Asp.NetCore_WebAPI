using IMS.BusinessLayer.EmployeeInterfaces;
using IMS.Models.EmployeesDatabaseDtos;
using IMS.Models.EmployeesDatabaseDtos;
using Microsoft.AspNetCore.Mvc;

namespace IMS.EmployeesControllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IEmployessBusinessLayer _businessAccess;

        public AccountController(IEmployessBusinessLayer businessAccess)
        {
            _businessAccess = businessAccess;
        }

        [Route("User Registration")]
        [HttpPost]

        public async Task<IActionResult> Register(EmployeeRegistrationDto dto)
        {
            var res = await _businessAccess.UserRegistration(dto);
            return Ok(res);
        }

        [Route("Login")]
        [HttpPost]

        public async Task<IActionResult> Login(EmployeeLoginDto dto)
        {
            var res = await _businessAccess.UserLogin(dto);
            return Ok(res);
        }
    }
}
