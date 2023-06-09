using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IUserData
    {
        Task<IEnumerable<UserModel>> GetUsers();

        Task DeleteUser(int id);
        Task<UserModel?> GetUser(int id);
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
    }
}