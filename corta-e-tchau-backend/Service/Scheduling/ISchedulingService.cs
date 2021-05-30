using corta_e_tchau_backend.Model;
using System;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Service
{
    public interface ISchedulingService
    {
        List<SchedulingGetDTO> Get(DateTime data);
        Scheduling Get(int codigo);
        int Insert(Scheduling aluno);
        int Update(Scheduling aluno);
        int Delete(int id);
    }
}
