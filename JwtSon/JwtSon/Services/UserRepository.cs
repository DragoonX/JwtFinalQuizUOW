using JwtSon.Interfaces;
using JwtSon.Models;
using System.Linq;

namespace JwtSon.Services
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        readonly XContext _xcontext;

        public UserRepository(XContext xcontext):base(xcontext) //base(context)' i mutlaka ekle !!!
        {
            _xcontext = xcontext;
        }

        User IUserRepository.FindUsername(string username)
        {
            return _xcontext.Set<User>().FirstOrDefault(a=>a.username == username);
        }
    }
}
