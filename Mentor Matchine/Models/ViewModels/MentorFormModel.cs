using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mentor_Matchine.Models.ViewModels
{
    public class MentorFormModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Surame")]
        public string Surname { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "When are you able to start helping?")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "How Many Mentees can you help?")]
        public int Mentees { get; set; }
        /*
        [Required(ErrorMessage = "*")]
        [Display(Name = "Are you able to hep someone with disability?")]
        public bool Disability { get; set; }
        [Display(Name = "Gender")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "What Languages do you speak?")]
        public List<string> Languages{get; set;}
        [Display(Name = "Any preferred nationalities of yur mentee?")]
        public List<string> Nationalities{get; set;}*/
    }
}