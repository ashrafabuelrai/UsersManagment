using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManagment.Application.Common.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
       
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

       
    }
}
