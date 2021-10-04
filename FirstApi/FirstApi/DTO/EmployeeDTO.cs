using System.ComponentModel.DataAnnotations;

namespace FirstApi.DTO
{
    public class EmployeeDTO : BaseDTO
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
