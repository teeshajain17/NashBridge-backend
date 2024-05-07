using NashBridge.Model;
using System.Net.Sockets;

namespace NashBridge.Repository.Interface
{
    public interface ISlotRepository
    {
        Task<Slot> CreateAsync(Slot ticket);

        Task<IEnumerable<Slot>> GetAllTodaysSlotAsync(Guid mentorId);

    }
}
