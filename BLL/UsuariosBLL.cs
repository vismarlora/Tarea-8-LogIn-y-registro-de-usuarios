using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tarea8LogIn.DAL;
using Tarea8LogIn.Entidades;

namespace Tarea8LogIn.BLL
{
    public class UsuariosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
            {
                return Insertar(usuario);
            }
            else
            {
                return Modificar(usuario);
            }
        }

        public static bool Insertar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();

            bool guardado = false;

            try
            {
                usuario.Contrasena = GetSHA256(usuario.Contrasena);

                if (contexto.Usuarios.Add(usuario) != null)
                {
                    guardado = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

        private static bool Modificar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();

            bool modificado = false;

            usuario.Contrasena = GetSHA256(usuario.Contrasena);

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;

                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();

            bool eliminado = false;

            try
            {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);

                    eliminado = (contexto.SaveChanges() > 0);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }
        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();

            Usuarios usuario = new Usuarios();

            try
            {
                usuario = contexto.Usuarios.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }
        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            Contexto contexto = new Contexto();

            List<Usuarios> Lista = new List<Usuarios>();

            try
            {
                Lista = contexto.Usuarios.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static List<Usuarios> GetUsuarios()
        {
            Contexto contexto = new Contexto();

            List<Usuarios> Lista = new List<Usuarios>();

            try
            {
                Lista = contexto.Usuarios.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static bool Validar(string nombre, string contrasena)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Usuarios.Any(u => u.Nombres.Equals(nombre) && u.Contrasena.Equals(GetSHA256(contrasena)));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        private static string GetSHA256(string contrasena)
        {
            SHA256 sha256 = SHA256Managed.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] stream = null;

            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(contrasena));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}
