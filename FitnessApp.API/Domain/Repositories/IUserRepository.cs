using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;

namespace FitnessApp.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindByIdAsync(int id);
        Task AddAsync(User user);
        void UpdateAsync(User user);
        void DeleteAsync(User user);
        
    }
}

/*


        ==== service ====

      Task<UserResource> Authenticate(string username, string password);
     ff  Task<IEnumerable<UserResource>> GetAll(); ==
       Task<UserResource> GetById(int id);  ==
       Task<UserResource> Create(User user, string password);  ==
       void Update(User user, string password = null);  ==
       void Delete(int id);

         ====== repository =====
            
        Task<IEnumerable<Excercise>> ListAsync();     
        Task AddAsync(Excercise excercise);
        Task<Excercise> FindByIdAsync(int id);
        void Update(Excercise excercise);
        void Remove(Excercise excercise);
        
        
        
        
        ====== service =======
        
        Task<IEnumerable<Excercise>> ListAsync();        
        Task<ExerciseResponse> SaveAsync(Excercise excercise);
        Task<ExerciseResponse> UpdateAsync(int id, Excercise excercise);
        Task<ExerciseResponse> DeleteAsync(int id);



*/