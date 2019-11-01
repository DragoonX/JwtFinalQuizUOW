using System;

namespace JwtSon.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository userRepository { get; set; }
        int Complete();
    }
}
