using corta_e_tchau_backend.Model;
using System;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Repository
{
    public interface ISchedulingRepository : IRepositoryBase<Scheduling>
    {
        public List<Scheduling> FullList(DateTime data);
        public bool isShedulingEmpty(Scheduling scheduling);
    }

}
