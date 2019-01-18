using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mentor_Matchine.Models.ViewModels
{
    public class MenteeFormModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Surame")]
        public string Surname { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Nationality")]
        public string Nationality{get; set;}
        [Display(Name = "Arrival Date")]
        public string ArrivalDate { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        /*[Display(Name = "Are you disabled?")]
        public bool Disability { get; set; }
        [Display(Name = "Gender")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "What Languages do you speak?")]
        public List<string> Languages{get; set;}*/
    }
}