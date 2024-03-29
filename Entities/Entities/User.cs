﻿using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{//Kullanıcı rolündekiler yanlızca sistemi görücek ama alış veriş yapamayacak
    public class User : CoreEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public Role? Role { get; set; }

        //Navigation Property
        public virtual Customer? Customer { get; set; }
    }
}
