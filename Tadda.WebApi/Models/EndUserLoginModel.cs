using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tadda.WebApi.Models
{
    public class EndUserLoginModel
    {
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Passcode1 { get; set; }
        public int Passcode2 { get; set; }
        public int Passcode3 { get; set; }
        public int Passcode4 { get; set; }
    }
}