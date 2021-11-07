using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea8LogIn.Entidades;

namespace Tarea8LogIn.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source = DATA\Tarea8Login.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1, Nombres = "Vismar", Apellidos = "Lora Muñoz", NombreUsuario = "administrador",

                Contrasena = "dc98bb137be12f4927a02942f89159e8fa6fb049d250b6077f26bac85f39f2ec"

                //Contrasena: vismar
            });
        }
    }
}
