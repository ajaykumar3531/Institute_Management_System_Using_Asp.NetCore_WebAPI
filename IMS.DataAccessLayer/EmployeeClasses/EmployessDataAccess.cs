using IMS.DataAccessLayer.EmployeeInterfaces;
using IMS.DataAccessLayer.IMSEmployeesDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.EmployeeClasses
{
    public class EmployessDataAccess<T> : IEmployessDataAccess<T> where T : class
    {
        private readonly EmployeesContext _context;

        public EmployessDataAccess(EmployeesContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            // Add an entity to the context for later saving.
            _context.Set<T>().Add(entity);
        }

        public async Task<string> FindByEmailAsync(string email)
        {
            // Find an employee by email.
            var user = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);

            if (user != null)
            {
                return user.Email;
            }

            // Return null if the user is not found.
            return null;
        }

        public async Task<bool> FindByPasswordAsync(string password, string email)
        {
            // Find an employee by email and ID.
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                // Verify the password using BCrypt.
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<Employee> FindByPasswordEmailAndIdAsync(string password, string email)
        {
            // Find an employee by email and ID.
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                return user;
            }

            return null; // Return null if the user is not found.
        }

        public async Task<List<T>> GetAll()
        {
            // Retrieve all entities of type T from the context.
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetById(object id)
        {
            // Retrieve an entity by its primary key (id).
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            // Remove an entity from the context for later saving.
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> saveChnagesAsync()
        {
            // Save changes asynchronously and return a boolean indicating success.
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            // Update an entity in the context for later saving.
            _context.Set<T>().Update(entity);
        }
    }
}
