﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjecr.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
     //   public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City  { get; set; }
        public string? ImageUrl { get; set; }
        public string? WorkDepartment { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public bool Status { get; set; }
        public int WorkLocationId { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}
