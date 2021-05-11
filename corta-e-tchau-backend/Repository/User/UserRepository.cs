using corta_e_tchau_backend.Infra;
using corta_e_tchau_backend.Model;
using System.Linq;

namespace corta_e_tchau_backend.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public User Get(string phone, string password)
        {
            User user = context.Set<User>().Where(x => x.phone.ToLower() == phone.ToLower() && x.password == password).FirstOrDefault();
            return user;
        }
    }
}
