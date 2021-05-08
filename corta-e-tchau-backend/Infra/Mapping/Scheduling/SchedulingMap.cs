using corta_e_tchau_backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corta_e_tchau_backend.Infra
{
    public class SchedulingMap : MapBase<Scheduling>
    {
        public override void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("scheduling");
            base.Configure(builder);
        }
    }
}
