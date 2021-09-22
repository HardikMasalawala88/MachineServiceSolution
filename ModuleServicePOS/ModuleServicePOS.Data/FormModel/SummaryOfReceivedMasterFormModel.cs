using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data.FormModel
{
    public class SummaryOfReceivedMasterFormModel : BaseEntity
    {
        [Required]
        [Display(Name = "Item Name: ")]
        public string ItemName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDelete { get; set; }
    }
}
