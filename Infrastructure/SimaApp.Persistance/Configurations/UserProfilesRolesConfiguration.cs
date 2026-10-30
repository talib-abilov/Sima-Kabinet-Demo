using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Persistance.Configurations
{
    public class UserProfilesRolesConfiguration : IEntityTypeConfiguration<UserProfilesRoles>
    {
        public void Configure(EntityTypeBuilder<UserProfilesRoles> builder)
        {
            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserProfilesRoles)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.UserProfile)
                .WithMany(x => x.UserProfilesRoles)
                .HasForeignKey(x => x.UserProfileId);
        }
    }
}
