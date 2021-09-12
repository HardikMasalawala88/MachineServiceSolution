using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.FormModel
{
    public class EstimateDetailsFormModel : BaseEntity
    {
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "SerialNo")]
        public string SerialNo { get; set; }
        public DateTime? ItemAddDate { get; set; }
        public bool? IsDelete { get; set; }
        public long OrderDetailId { get; set; }
        public virtual OrderDetails OrderDetail { get; set; }
    }
}
