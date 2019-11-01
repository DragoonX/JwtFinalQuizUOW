using JwtSon.Models;

namespace JwtSon.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User FindUsername(string username);
    }
}
