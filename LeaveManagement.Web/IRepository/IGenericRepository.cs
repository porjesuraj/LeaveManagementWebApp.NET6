namespace LeaveManagement.Web.IRepository
{
    public interface IGenericRepository<T> where T : class 
    {

        Task<List<T>> GetAllAsnyc();

        Task<T> GetAsync(int? id);
        Task<bool> ExistAsync(int? id);

        Task<T> AddAsync(T entity);
        Task<int> AddRangeAsync(List<T> entities);
        Task<int> UpdateAsync(int? id, T entity);

        Task<int> DeleteAsync(int? id);

       
    }
}
