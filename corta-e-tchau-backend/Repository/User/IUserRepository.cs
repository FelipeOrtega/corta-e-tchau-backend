using corta_e_tchau_backend.Model;

namespace corta_e_tchau_backend.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public User Get(string phone, string password);

    }

}
