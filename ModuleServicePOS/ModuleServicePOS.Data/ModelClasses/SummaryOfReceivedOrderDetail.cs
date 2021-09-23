using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class SummaryOfReceivedOrderDetail : BaseEntity
    {
        public long OrderDetailId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public long SummaryOfReceivedMasterId { get; set; }
        public virtual SummaryOfReceivedMaster SummaryOfReceivedMasters { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        public string SerialNumber { get; set; }
    }
}
