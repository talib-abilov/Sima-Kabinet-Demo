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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasOne(x => x.Company)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.UserId);

        }
    }
}
