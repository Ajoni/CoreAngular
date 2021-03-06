﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.User;
using Entities.User.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repos.Interfaces
{
    public interface IAccountRepo
    {
        Task<IdentityResult> Register(IdentityUser user, string password);
        Task<ObjectResult> Login(LoginVM vm);
    }
}
