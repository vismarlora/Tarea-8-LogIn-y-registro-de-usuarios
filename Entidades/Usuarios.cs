using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea8LogIn.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;

            Nombres = string.Empty;

            Apellidos = string.Empty;

            NombreUsuario = string.Empty;

            Contrasena = string.Empty;
        }
    }
}
