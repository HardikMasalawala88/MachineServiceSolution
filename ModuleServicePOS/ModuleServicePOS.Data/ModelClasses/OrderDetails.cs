using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.ModelClasses
{
    public class OrderDetails : BaseEntity
    {

        public OrderDetails()
        {
            this.SummaryOfReceived = new HashSet<SummaryOfReceived>();
        }
        [Required]
        [Display(Name ="Client Name: ")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Address: ")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Mobile Number: ")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Prepared By: ")]
        public string PreparedBy { get; set; }

        [Required]
        [Display(Name = "Date Prepared: ")]
        public DateTime? DatePrepared { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Model: ")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "S/N: ")]
        public string SerialNo { get; set; }

        [Required]
        [Display(Name = "Technician Notes: ")]
        public string TechnicianNote { get; set; }

        [Display(Name = "Product Status: ")]
        [Required]
        public string ProductStatus { get; set; }
        public bool IsClosed { get; set; }

        public virtual ICollection<SummaryOfReceived> SummaryOfReceived { get; set; }
    }
}
