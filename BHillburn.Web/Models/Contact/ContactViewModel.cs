
namespace BHilburn.Web.Models.Contact
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;


    public class ContactViewModel
    {
        //[Required(AllowEmptyStrings=false, ErrorMessage = "Name is required")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Phone:")]
        public string Phone { get; set; }

        //[Required(AllowEmptyStrings=false, ErrorMessage="Email is required")]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        
        [Display(Name="Additional Information:")]
        public string Info { get; set; }
    }
}