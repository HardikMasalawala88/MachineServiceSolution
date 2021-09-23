using ModuleServicePOS.Data.FormModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class SummaryOfReceivedMaster : BaseEntity
    {
        public SummaryOfReceivedMaster()
        {
            this.SummaryOfReceivedOrderDetails = new HashSet<SummaryOfReceivedOrderDetail>();
        }
        [Required]
        public string ItemName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<SummaryOfReceivedOrderDetail> SummaryOfReceivedOrderDetails { get; set; }
    }
}
