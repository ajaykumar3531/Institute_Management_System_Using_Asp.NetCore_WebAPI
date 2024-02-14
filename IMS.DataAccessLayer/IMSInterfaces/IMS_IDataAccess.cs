using IMS.DataAccessLayer.IMSDatabase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.Interfaces
{
    public interface IMS_IDataAccess<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type T.
        /// </summary>
        Task<List<T>> GetAll();

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        Task<T> GetById(int id);

        /// <summary>
        /// Adds an entity to the data store and returns the added entity.
        /// </summary>
        /// <param name="data">The entity to be added.</param>
        Task<T> PostData(T data);

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        void Add(T entity);

        /// <summary>
        /// Removes an entity from the data store.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        void Remove(T entity);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Saves changes to the data store asynchronously.
        /// </summary>
        Task<bool> saveChnagesAsync();

        /// <summary>
        /// Finds a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to find.</param>
        Task<string> FindByEmailAsync(string email);

        /// <summary>
        /// Finds a faculty by their email address and faculty number.
        /// </summary>
        /// <param name="email">The email address of the faculty.</param>
        /// <param name="num">The faculty number of the faculty.</param>
        Task<string> FacultyByEmailAsync(string email, string num);

        /// <summary>
        /// Checks if a user with the given password, email, and ID exists.
        /// </summary>
        /// <param name="password">The user's password.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="id">The user's ID.</param>
        Task<bool> FindByPasswordAsync(string password, string email, string id);

        // Additional methods to find entities by ID for various types.

        Task<bool> FindStudentId(object id);
        Task<bool> FindCourseId(object id);
        Task<bool> FindFacultyId(object id);
        Task<bool> FindCourseJoinId(object id);
        Task<bool> FindPaymentModeId(object id);
        Task<bool> FindStudentBillId(object id);
    }
}
