using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace web.Identity
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext()
        {
        }
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SELCUK;Initial Catalog=KanBagisDb;Integrated Security=SSPI;");
            }
        }
    }
}