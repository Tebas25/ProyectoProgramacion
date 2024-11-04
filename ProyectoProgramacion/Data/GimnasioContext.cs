using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion.Models;

    public class GimnasioContext : DbContext
    {
        public GimnasioContext (DbContextOptions<GimnasioContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoProgramacion.Models.VisitaGuiada> VisitaGuiada { get; set; } = default!;
    }
