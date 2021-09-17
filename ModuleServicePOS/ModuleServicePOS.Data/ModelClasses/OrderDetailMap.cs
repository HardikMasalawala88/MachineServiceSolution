using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class OrderDetailMap
    {
        public OrderDetailMap(EntityTypeBuilder<OrderDetails> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ClientName).IsRequired();
            entityBuilder.Property(t => t.Address).IsRequired();
            entityBuilder.Property(t => t.MobileNo).IsRequired();
            entityBuilder.Property(t => t.SerialNo).IsRequired();
            entityBuilder.Property(t => t.Model).IsRequired();
            entityBuilder.Property(t => t.PreparedBy).IsRequired();
            entityBuilder.Property(t => t.DatePrepared).IsRequired();
            entityBuilder.Property(t => t.TechnicianNote).IsRequired();
            entityBuilder.Property(t => t.ProductStatus).IsRequired();
            entityBuilder.Property(t => t.SystemType).IsRequired();
            entityBuilder.Property(t => t.OrderStatus).IsRequired();
            entityBuilder.Property(o => o.SubTotal).HasColumnType("decimal(18,4)");
            entityBuilder.Property(o => o.GrandTotal).HasColumnType("decimal(18,4)");
            //entityBuilder.HasMany(t => t.SummaryOfReceived).WithOne(u => u.OrderDetails);

            //entityBuilder.HasOne(t => t.SummaryOfReceived)
            //             .WithOne(u => u.OrderDetails)
            //            .HasForeignKey<SummaryOfReceived>(x => x.OrderId).IsRequired();
        }
    }
}
