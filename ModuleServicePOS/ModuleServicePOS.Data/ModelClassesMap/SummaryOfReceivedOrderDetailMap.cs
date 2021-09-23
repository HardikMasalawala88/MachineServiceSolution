using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClassesMap
{
    public class SummaryOfReceivedOrderDetailMap
    {
        public SummaryOfReceivedOrderDetailMap(EntityTypeBuilder<SummaryOfReceivedOrderDetail> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.CompanyName).IsRequired();
            entityBuilder.Property(t => t.ModelNumber).IsRequired();
            entityBuilder.Property(t => t.SerialNumber).IsRequired();
        }
    }
}
