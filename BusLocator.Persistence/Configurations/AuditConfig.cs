using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace BusLocator.Persistence.Configurations
{
    public class AuditConfig : ComplexTypeConfiguration<Audit>
    {
        public AuditConfig()
        {
            this.Property(a => a.CreatedBy).IsOptional().HasColumnName("CreatedBy");
            this.Property(a => a.CreatedDate).IsOptional().HasColumnName("CreatedDate");
            this.Property(a => a.ModifiedBy).IsOptional().HasColumnName("ModifiedBy");
            this.Property(a => a.ModifiedDate).IsOptional().HasColumnName("ModifiedDate");
            this.Property(a => a.RecordStateType).IsRequired().HasColumnName("RecordStateType");
        }
    }
}
