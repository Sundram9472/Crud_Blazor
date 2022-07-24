using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Blazor.Data
{
    public class ClgStudentDetails
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = "FirstName is mandatory")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Gmail is mandatory")]
        public string Gmail { get; set; }

        [MinLength(2)]
        [Display(Name = "Programming Language")]
        [Required(ErrorMessage = "Programming Language is mandatory")]
        public string ProgrammingLanguage { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = "Address is mandatory")]
        public string City { get; set; }
        
    }
}
