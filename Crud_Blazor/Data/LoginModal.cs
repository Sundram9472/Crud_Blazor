using System.ComponentModel.DataAnnotations;

namespace Crud_Blazor.Data
{
    public class LoginModal
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
