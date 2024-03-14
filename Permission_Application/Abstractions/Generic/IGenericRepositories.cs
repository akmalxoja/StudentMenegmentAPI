namespace Permission_Application.Abstractions.Generic
{
    public interface IGenericRepositories<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
