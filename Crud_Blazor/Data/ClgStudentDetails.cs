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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Gmail { get; set; }
        public string ProgrammingLanguage { get; set; }
        public string City { get; set; }
        
    }
}
