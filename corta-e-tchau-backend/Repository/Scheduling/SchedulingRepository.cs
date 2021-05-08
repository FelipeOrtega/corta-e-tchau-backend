using corta_e_tchau_backend.Infra;
using corta_e_tchau_backend.Model;

namespace corta_e_tchau_backend.Repository
{
    public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
