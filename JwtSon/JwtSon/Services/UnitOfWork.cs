using JwtSon.Interfaces;

namespace JwtSon.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly XContext _xcontext;

        public UnitOfWork(XContext xcontext)
        {
            _xcontext = xcontext;
            userRepository = new UserRepository(_xcontext); //BURASI EKLENECEK
        }

        public IUserRepository userRepository { get; set; }

        public int Complete()
        {
            return _xcontext.SaveChanges();
        }

        public void Dispose()
        {
            _xcontext.Dispose();
        }
    }
}
