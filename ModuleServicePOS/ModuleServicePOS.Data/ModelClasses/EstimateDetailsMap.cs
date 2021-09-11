using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class EstimateDetailsMap
    {
        public EstimateDetailsMap(EntityTypeBuilder<EstimateDetails> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Description).IsRequired();
            entityBuilder.Property(t => t.ItemAddDate).IsRequired();
            entityBuilder.Property(t => t.Amount).IsRequired();
        }
    }
}
