using corta_e_tchau_backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corta_e_tchau_backend.Infra
{
    public class SchedulingMap : MapBase<Scheduling>
    {
        public override void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.HasOne(s => s.user).WithMany(u => u.schedulings).HasForeignKey(su => su.user_id);
            builder.ToTable("scheduling");
            base.Configure(builder);
        }
    }
}
