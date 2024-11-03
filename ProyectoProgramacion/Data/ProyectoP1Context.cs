using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion.Models;

    public class ProyectoP1Context : DbContext
    {
        public ProyectoP1Context (DbContextOptions<ProyectoP1Context> options)
            : base(options)
        {
        }

        public DbSet<ProyectoProgramacion.Models.Membresias> Membresias { get; set; } = default!;
    }
