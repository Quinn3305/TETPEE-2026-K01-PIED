using Microsoft.EntityFrameworkCore;
using TetPee01.Repository;

namespace TetPee01.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Base.Response.PageResult<Response.GetUserResponse>> GetUsers(string? searchTerm, int pageIndex, int pageSize)
    {
        var query = _dbContext.Users.Where(u => true);
        if (searchTerm != null)
        {
            query = query.Where(u => u.Email.Contains(searchTerm) 
                                     || u.FirstName.Contains(searchTerm) 
                                     || u.LastName.Contains(searchTerm));
        }
        query = query.OrderBy(u => u.Email);
        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        
        var sellectedQuery = query
            .Select(u => new Response.GetUserResponse()
        {
            Id = u.Id,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            PhoneNumber = u.PhoneNumber,
            UrlImage = u.ImageUrl,
            Address =  u.Address,
            DateOfBirth =  u.DateOfBirth,
            Role =  u.Role,
        });
        var listResult = await sellectedQuery.ToListAsync();
        var totalItem = listResult.Count();
        var result = new Base.Response.PageResult<Response.GetUserResponse>
        {
            Items = listResult,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItems = totalItem,
        };
        return result;
    }

    public Task<Response.GetUserResponse?> GetUserById(Guid id)
    {
        var query = _dbContext.Users.Where(u => u.Id == id);
        var sellectionQuery = query.Select(u => new Response.GetUserResponse()
        {
            Id = u.Id,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            PhoneNumber = u.PhoneNumber,
            UrlImage = u.ImageUrl,
            Address =  u.Address,
            DateOfBirth =  u.DateOfBirth,
            Role =  u.Role,
        });
        var result

        return result;
    }
}