using DataAccess.Data.Interfaces;
using DataAccess.DbAccess;
using DataAccess.Models;


namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _dataAccess;

        public UserData(ISqlDataAccess dataAccess)
        {
            _dataAccess=dataAccess;
        }

        public Task<IEnumerable<UserModel>> GetUsers() => _dataAccess.LoadData<UserModel, dynamic>("[dbo].[GetAllUsers]", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _dataAccess.LoadData<UserModel, dynamic>("[dbo].[GetUserByID]", new { ID = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user)
        {
            return _dataAccess.SaveData("[dbo].[InsertUser]", new { user.FirstName, user.LastName });
        }

        public Task UpdateUser(UserModel user) => _dataAccess.SaveData("[dbo].[UpdateUserByID]", user);

        public Task DeleteUser(int id)
        {
            return _dataAccess.SaveData("[dbo].[DeleteUserByID]", new { Id = id });
        }
    }
}
