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
        public string FirstName { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = "LastName is mandatory")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is mandatory")]
        public string Gender { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Gmail is mandatory")]
        public string Gmail { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = "Programming Language is mandatory")]
        public string ProgrammingLanguage { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = "Adress is mandatory")]
        public string City { get; set; }
        
    }
}
