﻿

using Microsoft.AspNetCore.Identity;

namespace OngPetCare.infra.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
    }
}


