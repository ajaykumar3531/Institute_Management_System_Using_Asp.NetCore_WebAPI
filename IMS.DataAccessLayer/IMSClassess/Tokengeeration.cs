using IMS.DataAccessLayer.EmployeeClasses;
using IMS.DataAccessLayer.EmployeeInterfaces;
using IMS.DataAccessLayer.IMSEmployeesDatabase;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.IMSClassess
{
    public class Tokengeeration : ITokenManager
    {
        // Private fields to store the secret key and token configuration
        private readonly string _key;
        private readonly byte[] _secret;
        private readonly JwtTokenConfig _jwtTokenConfig;

        // Database context for interacting with the Employees database
        private readonly EmployeesContext _context;

        public Tokengeeration(JwtTokenConfig jwtTokenConfig, EmployeesContext context)
        {
            // Initialize private fields with provided values
            _key = jwtTokenConfig.Secret;
            
            _jwtTokenConfig= jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
            _context = context;
        }

        public Task<string> GenerateTokenAsync(Employee user)
        {
            // Create a JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create a byte array from the secret key
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            // Create a SecurityTokenDescriptor that defines the token's properties
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    // Add claims such as user's email, first name, and username to the token
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                    new Claim(JwtRegisteredClaimNames.Actort, user.FullName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.EmployeeId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time (1 hour)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256),
            };

            // Create a token based on the descriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the generated token as a string
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
