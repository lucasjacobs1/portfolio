using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Create a entity
        /// </summary>
        /// <param name="entity"></param>
        bool Create(T entity);

        /// <summary>
        /// Get a item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// object
        /// </returns>
        T GetById(object id);

        /// <summary>
        /// Get all the items
        /// </summary>
        /// <returns>
        /// IEnumerable<typeparamref name="T"/>
        /// </returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity"></param>
        bool Update(T entity);
        /// <summary>
        /// Delete a item from a entity
        /// </summary>
        /// <param name="entity"></param>
        bool Delete(T entity);
        /// <summary>
        /// Delete all entity
        /// </summary>
        bool DeleteAll();
    }
}
