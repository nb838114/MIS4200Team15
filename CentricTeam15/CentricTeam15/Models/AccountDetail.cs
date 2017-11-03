using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CentricTeam15.Models
{
    public class AccountDetail
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Bussiness Unit")]
        public string bussinessUnit { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        public string photo { get; set; }

        public string description { get; set; }

        public string coreValue { get; set; }

        public string comment { get; set; }

    }
}