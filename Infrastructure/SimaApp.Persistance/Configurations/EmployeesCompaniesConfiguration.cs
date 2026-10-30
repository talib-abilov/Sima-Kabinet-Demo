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
    public class EmployeesCompaniesConfiguration : IEntityTypeConfiguration<EmployeesCompanies>
    {
        public void Configure(EntityTypeBuilder<EmployeesCompanies> builder)
        {
            builder.Property(x => x.Position).IsRequired();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeesCompanies)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x=>x.Company)
                .WithMany(x=>x.EmployeesCompanies)
                .HasForeignKey(x=>x.CompanyId);
        }
    }
}
