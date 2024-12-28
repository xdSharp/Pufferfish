﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeFtItWk
{
    public class User
    {
        public User(
            string email,
            string name,
            string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
