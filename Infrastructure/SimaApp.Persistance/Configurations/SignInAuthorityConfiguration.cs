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
    public class SignInAuthorityConfiguration : IEntityTypeConfiguration<SignInAuthority>
    {
        public void Configure(EntityTypeBuilder<SignInAuthority> builder)
        {
            builder.HasOne(x => x.EmployeesCompanies)
                .WithOne(x => x.SignInAuthority)
                .HasForeignKey<SignInAuthority>(x => x.EmployeesCompaniesId);
        }
    }
}
