﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName {  get; set; }
    }
}