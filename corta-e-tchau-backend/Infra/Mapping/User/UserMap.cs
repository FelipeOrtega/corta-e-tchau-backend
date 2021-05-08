using corta_e_tchau_backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corta_e_tchau_backend.Infra
{
    public class UserMap : MapBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            base.Configure(builder);
        }
    }
}
