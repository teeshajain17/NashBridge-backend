using Microsoft.EntityFrameworkCore;
using NashBridge.Data;
using NashBridge.Model;
using NashBridge.Repository.Interface;

namespace NashBridge.Repository.Implementation
{
    public class SlotRepository : ISlotRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SlotRepository(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<Slot> CreateAsync(Slot slot)
        {
            await dbContext.Slots.AddAsync(slot);
            await dbContext.SaveChangesAsync();
            return slot;
        }

        public async Task<IEnumerable<Slot>> GetAllTodaysSlotAsync(Guid mentorId)
        {
            var todaysDate = DateTime.Now;
            var todaysSlots = await dbContext.Slots.Where(x => x.SlotTime == todaysDate &&
            x.MentorId!= mentorId).ToListAsync();

            return todaysSlots;
        }
    }
}
