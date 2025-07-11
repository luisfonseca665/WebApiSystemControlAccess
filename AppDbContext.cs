﻿using Microsoft.EntityFrameworkCore;

namespace WebApiSystemControlAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<HistorialAcceso> HistorialAccesos { get; set; }

        public DbSet<Invitado> Invitados { get; set; }
    }
}
