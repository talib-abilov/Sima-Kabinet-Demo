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
    public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithOne(x => x.EmployeeDocument)
                .HasForeignKey<EmployeeDocument>(x => x.EmployeeId);   

            builder.Property(x => x.PIN)
                .IsRequired();

            //builder.Property(x => x.Serial)
            //    .IsRequired();

            //builder.Property(x => x.SerialNumber)
            //    .IsRequired();
        }
    }
}
