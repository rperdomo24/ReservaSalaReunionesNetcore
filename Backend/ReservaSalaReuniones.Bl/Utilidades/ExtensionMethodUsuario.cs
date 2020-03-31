using ReservaSalaReuniones.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservaSalaReuniones.Bl.Utilidades
{
    public static class ExtensionMethodUsuario
    {
        public static List<Usuario> WithoutPasswords(this IEnumerable<Usuario> users)
        {
            return users.Select(x => x.WithoutPassword()).ToList();
        }

        public static Usuario WithoutPassword(this Usuario user)
        {
            user.Password = null;
            return user;
        }
    }
}
