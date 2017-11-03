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

        //add hire date after talking to luce, recreate controller

        public string description { get; set; }

        public string coreValue { get; set; }

        public string comment { get; set; }

    }
}