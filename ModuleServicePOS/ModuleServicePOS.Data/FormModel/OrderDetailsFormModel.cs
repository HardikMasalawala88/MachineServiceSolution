using ModuleServicePOS.Data.FormModel;
using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModuleServicePOS.Data
{
    public class OrderDetailsFormModel : BaseEntity
    {
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }

        [Required]
        [Display(Name = "Date Prepared")]
        public DateTime? DatePrepared { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }

        [Required]
        [Display(Name = "Serial No.")]
        public string SerialNo { get; set; }

        [Required]
        [Display(Name = "Technician Notes")]
        public string TechnicianNote { get; set; }
    
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
      
        [Display(Name = "Grand Total")]
        public decimal GrandTotal { get; set; }
        public bool IsClosed { get; set; }

        [Required]
        [Display(Name = "System Password")]
        public string SystemPassword { get; set; }

        [Required]
        [Display(Name = "System Type")]
        public SystemType SystemType { get; set; }
        public string SummaryOfReceivedOrderDetailsJSON { get; set; }
        [Required]
        public virtual IEnumerable<string> ProductStatusList { get; set; }
        public virtual IEnumerable<string> SummaryOfReceivedList { get; set; }
        public virtual EstimateDetailsFormModel EstimateDetails { get; set; }
        public virtual IEnumerable<EstimateDetailsFormModel> EstimateDetailsList { get; set; }
        public virtual IEnumerable<SummaryOfReceivedMaster> SummaryDetailsList { get; set; }
        public virtual IEnumerable<SummaryOfReceivedOrderDetailFromModel> SummaryOfReceivedOrderDetails { get; set; }
        
    }
}
