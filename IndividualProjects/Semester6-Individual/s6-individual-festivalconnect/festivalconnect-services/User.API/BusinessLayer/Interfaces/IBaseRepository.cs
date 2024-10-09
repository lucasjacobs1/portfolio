
namespace BusinessLayer.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// Create a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        Task<bool> Create(T entity);

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
        /// <returns></returns>
        bool Update(T entity);
        /// <summary>
        /// Delete a item from a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        bool Delete(T entity);
        /// <summary>
        /// Delete all entity
        /// </summary>
        bool DeleteAll();
    }
}
