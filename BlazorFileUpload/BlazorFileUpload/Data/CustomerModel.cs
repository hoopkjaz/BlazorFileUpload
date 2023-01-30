using System.ComponentModel.DataAnnotations;

namespace BlazorFileUpload.Data
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "khooper";

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? FileName { get; set; }
    }
}
