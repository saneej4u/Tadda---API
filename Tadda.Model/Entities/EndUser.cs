using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadda.Model.Entities
{
    public class EndUser
    {
        public EndUser()
        {
            DateTimeCreated = DateTime.Now;
            DateOfBirth = DateTime.Now;
        }
        public int EndUserId { get; set; }


        [Required(ErrorMessage = "First name is missing")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is missing")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Company is missing")]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "Email is missing")]
        public string EmailAddress { get; set; }

        public string ProfilePicUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string IOSDeviceId { get; set; }

        public string AndroidDeviceId { get; set; }

        [Range(0, 9,ErrorMessage = "Value must be between 0-9.")]
        public int PassOne { get; set; }

        [Range(0, 9, ErrorMessage = "Value must be between 0-9.")]
        public int PassTwo { get; set; }

        [Range(0, 9, ErrorMessage = "Value must be between 0-9.")]
        public int PassThree { get; set; }

        [Range(0, 9, ErrorMessage = "Value must be between 0-9.")]
        public int PassFour { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public virtual Address Addresses { get; set; }

    }
}
