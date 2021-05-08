using corta_e_tchau_backend.Infra;
using corta_e_tchau_backend.Model;

namespace corta_e_tchau_backend.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
