using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Models
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
