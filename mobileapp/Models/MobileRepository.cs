using Microsoft.EntityFrameworkCore;

namespace mobileapp.Models
{
    public class MobileRepository : IMobileRepository
    {
        private readonly ApplicationDbContext _context;
        public MobileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mobile>> GetAllAsync()
        {
            return await _context.Mobiles.ToListAsync();
        }
        public async Task<Mobile> GetByIdAsync(int id)
        {
            return await _context.Mobiles.FindAsync(id);
        }
        public async Task AddAsync(Mobile Mobile)
        {
            _context.Mobiles.Add(Mobile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Mobile Mobile)
        {
            _context.Mobiles.Update(Mobile);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var Mobile = await _context.Mobiles.FindAsync(id);
            _context.Mobiles.Remove(Mobile);
            await _context.SaveChangesAsync();
        }
    }
}
