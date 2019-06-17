using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Repositories;
using FitnessApp.API.Domain.Services;
using FitnessApp.API.Domain.Services.Communication;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Services
{
    public class UserService  : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<UserResponse> AuthenticateAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserResponse> CreateAsync(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                
                return new UserResponse(user);
            }
            catch (Exception e)
            {
              return new UserResponse($"An error occured when creating this User: {e.Message}");
            }
            
        }

        public async Task<UserResponse> UpdateAsync(User user, string password = null)
        {
            var existingUser = await _userRepository.FindByIdAsync(user.id);
            
            if(existingUser == null)
                return new UserResponse("User not found");

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.UserName = user.UserName;

                 //refactor create password method

            try
            {
                _userRepository.UpdateAsync(user);
                _unitOfWork.CompleteAsync();
            
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occured while trying to update the User : {e.Message}");
            }
       
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {

            var existingUser = await _userRepository.FindByIdAsync(id);
            
            if(existingUser == null)
                return new UserResponse("User could not be found");

            try
            {
                _userRepository.DeleteAsync(existingUser);
                _unitOfWork.CompleteAsync();
                
                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occured trying to delete User : {e.Message}");
            }
            
        }
        
        //helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}