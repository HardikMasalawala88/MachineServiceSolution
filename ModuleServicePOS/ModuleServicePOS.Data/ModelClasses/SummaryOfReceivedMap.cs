using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class SummaryOfReceivedMap
    {
        public SummaryOfReceivedMap(EntityTypeBuilder<SummaryOfReceived> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ItemName).IsRequired();

            //entityBuilder.HasOne(t => t.OrderDetails).WithMany();
                       // .WithOne(u => u.SummaryOfReceived)
                       //.HasForeignKey<OrderDetails>(x => x.Id).IsRequired();
        }
    }
}
