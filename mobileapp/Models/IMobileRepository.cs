namespace mobileapp.Models
{
    public interface IMobileRepository
    {
        Task<IEnumerable<Mobile>> GetAllAsync();
        Task<Mobile> GetByIdAsync(int id);
        Task AddAsync(Mobile mobile);
        Task UpdateAsync(Mobile mobile);
        Task DeleteAsync(int id);
    }
}
