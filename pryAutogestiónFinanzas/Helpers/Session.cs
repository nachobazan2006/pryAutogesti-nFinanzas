using System;
using System.Collections.Generic;
using System.Text;

namespace pryAutogestiónFinanzas.Helpers
{
    public static class Session
    {
        public static string Usuario { get; private set; } = "";

        public static bool Logueado => !string.IsNullOrWhiteSpace(Usuario);

        public static void Login(string usuario)
        {
            Usuario = usuario?.Trim() ?? "";
        }

        public static void Logout()
        {
            Usuario = "";
        }
    }
}
