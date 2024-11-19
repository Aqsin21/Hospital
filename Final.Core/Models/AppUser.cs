using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Models
{
    public  class AppUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
