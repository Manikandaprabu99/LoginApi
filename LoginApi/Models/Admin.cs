using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class Admin
    {
        [Key]
        public string? Email { get; set; }

        public string? Pwd { get; set; }
    }
}
