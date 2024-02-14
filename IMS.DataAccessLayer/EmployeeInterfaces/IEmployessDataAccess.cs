using IMS.DataAccessLayer.IMSEmployeesDatabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccessLayer.EmployeeInterfaces
{
    public interface IEmployessDataAccess<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type T.
        /// </summary>
        Task<List<T>> GetAll();

        /// <summary>
        /// Retrieves an entity by its primary key.
        /// </summary>
        /// <param name="id">The primary key of the entity.</param>
        Task<T> GetById(object id);

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
        /// Finds a user by their email.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        Task<string> FindByEmailAsync(string email);

        /// <summary>
        /// Finds a user by their password, email, and ID.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <param name="email">The email address of the user.</param>

        Task<bool> FindByPasswordAsync(string password, string email);

        /// <summary>
        /// Finds a user by their password, email, and ID, returning the user entity.
        /// </summary>
        /// <param name="password">The password of the user.</param>
        /// <param name="email">The email address of the user.</param>
     
        Task<Employee> FindByPasswordEmailAndIdAsync(string password, string email);
    }
}
