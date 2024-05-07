using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NashBridge.Data;
using NashBridge.Model;
using NashBridge.Repository.Interface;

namespace NashBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ISlotRepository slotRepository;

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext
            , ISlotRepository slotRepository)
        {
            this.applicationDbContext = applicationDbContext;
            this.slotRepository = slotRepository;
        }
        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetTodaysSlots(Guid userId)
        {

            var todaysSlots = slotRepository.GetAllTodaysSlotAsync(userId);
            return Ok();

        }

        [HttpPost]

        public async Task<IActionResult> CreateSlot(Slot slot)
        {
            await slotRepository.CreateAsync(slot);
            return Ok();
        }
    }
}
