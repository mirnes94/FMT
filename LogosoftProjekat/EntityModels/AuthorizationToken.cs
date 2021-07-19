﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.EntityModels
{
    public class AuthorizationToken
    {
        public int Id { get; set; }
        public string Value { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public Identity User { get; set; }
        public DateTime LoggedTime { get; set; }
        public string IpAddress { get; set; }
    }
}
