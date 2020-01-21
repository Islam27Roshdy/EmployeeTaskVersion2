using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Insert Your FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Insert Your LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please Insert Your BirthDay")]
        public DateTime BirthDay { get; set; }
        
    }
}
