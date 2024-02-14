using IMS.DataAccessLayer.IMSDatabase;
using IMS.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.Classess
{
    public class IMS_DataAccess<T> : IMS_IDataAccess<T> where T : class
    {
        private readonly InstituteManagementSystemContext _context;

        public IMS_DataAccess(InstituteManagementSystemContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<string> FindByEmailAsync(string email)
        {
            // Find a user by email in the Students table.
            var user = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                return user.Email;
            }
            return null;
        }

        public async Task<string> FacultyByEmailAsync(string email, string num)
        {
            // Find a faculty by email or mobile number in the Faculties table.
            var user = await _context.Faculties.FirstOrDefaultAsync(x => x.Email == email || x.Mobile == num);

            if (user != null)
            {
                return user.Email;
            }
            return null;
        }

        public Task<bool> FindByPasswordAsync(string password, string email, string id)
        {
            // This method is not implemented in your code.
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            // Retrieve all entities of type T from the database.
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetById(int id)
        {
            // Retrieve an entity of type T by its ID from the database.
            var data = await _context.Set<T>().FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public Task<T> PostData(T data)
        {
            // This method is not implemented in your code.
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            // Remove an entity from the data store.
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> saveChnagesAsync()
        {
            // Save changes to the database asynchronously.
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            // Update an existing entity in the data store.
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> FindStudentId(object id)
        {
            // Find a student by their ID in the Students table.
            var data = await _context.Students.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindCourseId(object id)
        {
            // Find a course by its ID in the Courses table.
            var data = await _context.Courses.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindFacultyId(object id)
        {
            // Find a faculty by their ID in the Faculties table.
            var data = await _context.Faculties.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindCourseJoinId(object id)
        {
            // Find a course join record by its ID in the CoursesJoineds table.
            var data = await _context.CoursesJoineds.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindPaymentModeId(object id)
        {
            // Find a payment mode by its ID in the PaymentModes table.
            var data = await _context.PaymentModes.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FindStudentBillId(object id)
        {
            // Find a student bill by its ID in the StudentBills table.
            var data = await _context.StudentBills.FindAsync(id);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
