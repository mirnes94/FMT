using LogosoftProjekat.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.EF
{
    public class MojContext:DbContext
    {
        
        public MojContext(DbContextOptions<MojContext> options)
        : base(options)
        { }
        
        public DbSet<Identity> Identity { get; set; }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<AuthorizationToken> AuthorizationToken { get; set; }
        public DbSet<UsersToDo> UsersToDo { get; set; }

    }
}
