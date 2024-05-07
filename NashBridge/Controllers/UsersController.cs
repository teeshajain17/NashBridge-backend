using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NashBridge.Data;
using NashBridge.Model;
namespace NashBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AuthDbContext authDb;

        public UsersController(UserManager<IdentityUser> userManager, AuthDbContext authDb)
        {
            this.userManager = userManager;
            this.authDb = authDb;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            //var users = await userManager.Users.ToListAsync();
            //List<UserDTO> result = new List<UserDTO>();

            //foreach (var user in users)
            //{
            //    var userRoles = await userManager.GetRolesAsync(user);
            //    var isAdmin = userRoles.Any(x => x.ToString().ToLower() == "writer");
            //    result.Add(new UserDTO
            //    {
            //        Id = user.Id,
            //        Name = user.UserName,
            //        Phone = user.PhoneNumber,
            //        Email = user.Email,
            //        IsAdmin = isAdmin
            //    });
            //}

            return Ok();

        }

        //[HttpGet]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        //{
        //    var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    var userRoles = await userManager.GetRolesAsync(user);
        //    var isAdmin = userRoles.Any(x => x.ToString().ToLower() == "writer");
        //    var response = new UserDTO
        //    {
        //        Id = user.Id,
        //        Name = user.UserName,
        //        Phone = user.PhoneNumber,
        //        Email = user.Email,
        //        IsAdmin = isAdmin

        //    };
        //    return Ok(response);
        //}

        //[HttpPut]
        //[Route("{id:guid}")]
        //[Authorize(Roles = "Writer")]

        //public async Task<IActionResult> UpdateUserById([FromRoute] Guid id, [FromBody] UpdateUserRequestDTO requestDTO)
        //{
        //    dto to domain

        //    var user = await userManager.FindByIdAsync(id.ToString());

        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    user.Id = id.ToString();
        //    user.UserName = requestDTO.Name;
        //    user.Email = requestDTO.Email;
        //    user.PhoneNumber = requestDTO.Phone;
        //    var result = await userManager.UpdateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest();
        //    }

        //    var existingRoles = await userManager.GetRolesAsync(user);
        //    var rolesToAdd = new List<string>();
        //    var rolesToRemove = new List<string>();
        //    if (requestDTO.IsAdmin && !existingRoles.Contains("Writer"))
        //    {
        //        rolesToAdd.Add("Writer");
        //        await userManager.AddToRolesAsync(user, rolesToAdd);
        //    }
        //    if (existingRoles.Contains("Writer") && !requestDTO.IsAdmin)
        //    {
        //        rolesToRemove.Add("Writer");
        //        await userManager.RemoveFromRolesAsync(user, rolesToRemove);

        //    }
        //    return Ok(result);

        //}

        //[HttpDelete]
        //[Route("{id:guid}")]
        //[Authorize(Roles = "Writer")]

        //public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        //{

        //    var deletedUser = await userManager.FindByIdAsync(id.ToString());
        //    if (deletedUser is null)
        //    {
        //        return NotFound(id);
        //    }
        //    var result = await userManager.DeleteAsync(deletedUser);
        //    if (result.Succeeded)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();

        //}

    }
}
