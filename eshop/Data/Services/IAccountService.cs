using eshop.Models;
using eshop.Views.Account;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Services;

public interface IAccountService
{
    Task<List<ApplicationUser>> GetAllAsync();

    Task<ApplicationUser> GetByIdAsync(string id);

    Task AddAsync(Users users);
    
    Task<ApplicationUser> UpdateAsync(string id, ApplicationUser newUser);

    Task DeleteAsync(string id);

}