using Microsoft.AspNetCore.Mvc;
using TetPee01.Repository;

namespace TetPee01.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly AppDbContext _Dbcontext;
    
    public UserController(AppDbContext dbContext)
    {
        _Dbcontext = dbContext;
    }

    [HttpGet(" ")]
    public IActionResult GetUsers(string? searchTerm, int pageSize = 10, int pageIndex = 1)
    {
        var
        return Ok(_Dbcontext.Users)
    }
}