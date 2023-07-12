using _23CVProyecto_Final.Context;
using _23CVProyecto_Final.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace _23CVProyecto_Final.Services
{
    public class UsuarioService
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())  //cadena de conexio
                    {
                        Usuario res = new Usuario();
                        res.Nombre = request.Nombre;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        res.FkRol = request.FkRol;
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
    
        }
        public List <Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();

                    usuarios = _context.Usuarios.Include(x=> x.Roles).ToList();

                    return usuarios;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
        }

        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles =_context
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}
