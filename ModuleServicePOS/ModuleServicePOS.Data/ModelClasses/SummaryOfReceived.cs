using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class SummaryOfReceived : BaseEntity
    {
        [Required]
        [Display(Name = "Summary Of Received: ")]
        public string ItemName { get; set; }
        public long OrderDetailId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
    }
}
