using corta_e_tchau_backend.Infra;
using corta_e_tchau_backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace corta_e_tchau_backend.Repository
{
    public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(ApplicationDBContext context) : base(context)
        {
        }

        public List<Scheduling> FullList(DateTime data)
        {
            List<Scheduling> scheduling = context.Set<Scheduling>().Include(s => s.user).OrderBy(s => s.date_time)
                                                                   .Where(s => s.date_time.Date == data.Date).ToList();
            return scheduling;
        }
    }
}
