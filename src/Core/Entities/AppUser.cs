using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppUser: IdentityUser, IAggregateRoot
    {
        public AppUser()
        {

        }
        public string FullNameFa { get;set; }
        public string FullNameEn { get;set; }
        public string Picture { get;set; }
        public string Mobile { get; set; }

    }
}
