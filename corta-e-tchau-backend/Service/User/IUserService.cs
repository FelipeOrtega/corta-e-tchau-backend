using corta_e_tchau_backend.Model;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Service
{
    public interface IUserService
    {
        List<User> Get();
        User Get(User user);
        User Get(int codigo);
        int Insert(User aluno);
        int Update(User aluno);
        int Delete(int id);
    }
}
