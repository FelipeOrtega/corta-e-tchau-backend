using corta_e_tchau_backend.Model;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Repository
{
    public interface ISchedulingService
    {
        List<Scheduling> Get();
        Scheduling Get(int codigo);
        int Insert(Scheduling aluno);
        int Update(Scheduling aluno);
        int Delete(int id);
    }
}
