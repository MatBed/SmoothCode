using RecordsBook.DataAccess.Models;

namespace RecordsBook.DataAccess.Data;

public interface IUserData
{
    Task DeleteUser(int id);

    Task<User?> GetUserById(int id);

    Task<IEnumerable<User>> GetUsers();

    Task InsertUser(User user);

    Task UpdateUser(User user);
}