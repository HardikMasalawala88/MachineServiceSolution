using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class SummaryOfReceivedMasterMap
    {
        public SummaryOfReceivedMasterMap(EntityTypeBuilder<SummaryOfReceivedMaster> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ItemName).IsRequired();
        }
    }
}
