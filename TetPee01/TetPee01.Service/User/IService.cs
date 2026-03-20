namespace TetPee01.Service.User;

public interface IService
{
    public Task<Base.Response.PageResult<Response.GetUserResponse>> GetUsers(string? searchTerm , int pageIndex, int pageSize);
    
    public Task<Response.GetUserResponse?> GetUserById(Guid id);
    
}