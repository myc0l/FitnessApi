using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Services.Communication;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Domain.Services
{
    public interface IUserService
    {
       Task<UserResponse> AuthenticateAsync(string username, string password);
       Task<UserResponse> CreateAsync(User user, string password);
       Task<UserResponse> UpdateAsync(User user, string password = null);
       Task<UserResponse> DeleteAsync(int id);

    }
}
//todo
//change resources to responses !!!