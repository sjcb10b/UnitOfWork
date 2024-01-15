﻿using Microsoft.AspNetCore.Identity;

namespace UnitOfWork.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }


    }
}
