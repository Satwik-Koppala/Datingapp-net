using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API;


[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    private DataContext context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> Getusers(){

        var users= await context.Users.ToListAsync();

        return users;    
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> Getusers(int id){
        var user= await context.Users.FindAsync(id);

        if(user==null) return NotFound();

        return user;    
    }
}