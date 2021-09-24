using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class EstimateDetail : BaseEntity
    {
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        public DateTime? ItemAddDate { get; set; }
        public string SerialNo { get; set; }
        public bool? IsDelete { get; set; }

        [Display(Name = "Amount: ")]
        public decimal Amount { get; set; }
        public long OrderDetailId { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
