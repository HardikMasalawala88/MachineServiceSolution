using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Data
{
    public class UserDetail : BaseEntity
    {
        [Required]
        [Display(Name = "Enter Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Enter User Name: ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Enter Password: ")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Select Gender: ")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Enter Age: ")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Enter City: ")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Enter Contact No: ")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Enter Email Id: ")]
        public string MailId { get; set; }
    }
}
