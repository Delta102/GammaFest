using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GAMMAFEST.Models;
using System;

namespace GAMMAFEST.Data
{
    public class ContextoDb:IdentityDbContext
    {
        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options) {
        }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Promotor> Promotor { get; set; }

    }
}
