using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpCrudFinal.Dto;
using TpCrudFinal.EF;
using static System.Collections.Specialized.BitVector32;
using System.Web.SessionState;

namespace TpCrudFinal.Datos
{
    public class CLogin
    {
        public static UsuarioDto IniciarSesion(string alias, string clave)
        {
            UsuarioDto usuarioDto = new UsuarioDto();

            using (DBCrudPrograEntities db = new DBCrudPrograEntities())
            {
                var usuario = db.Usuario.Where(u => u.Alias == alias && u.Clave == clave).Select(u => u);
                
                if(usuario.Any())
                {
                    usuarioDto.Alias = usuario.First().Alias;
                    usuarioDto.UsuarioId = usuario.First().IdUsuario;
                }
                
                return usuarioDto;
            }
        }

    }
}